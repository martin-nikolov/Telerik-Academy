window.onload = function() {
    var stage = initializeStage();
    var layer = initializeLayer();

    var data = parseData(Data.familyMembers);
    var dictionary = buildDictionary(data);
    var root = findRoot(data, dictionary);

    drawFamilyTree(layer, root);
    stage.add(layer);
};

var nodeWidth = 115;
var nodeHeight = 40;
var fontSize = 11;

var levelStartHeight = 10;
var levelStep = 65;

var widthStep = nodeWidth + 20;
var posX = 450;
var posXStep = 2 * widthStep;

function initializeStage() {
    var stage = new Kinetic.Stage({
        container: 'kinetic-container',
        width: 1300,
        height: 1100
    });

    return stage;
}

function initializeLayer() {
    var layer = new Kinetic.Layer({
        draggable: true
    });

    layer.on("mousemove", function() {
        document.body.style.cursor = 'pointer';
    });

    layer.on("mouseout", function() {
        document.body.style.cursor = 'default';
    });

    return layer;
}

function parseData(data) {
    var result = [];
    for (var i = 0; i < data.length; i++) {
        var node = new Node(data[i].mother,
            data[i].father,
            data[i].children);

        result.push(node);
    }

    return result;
}

function buildDictionary(data) {
    var dictionary = [];

    for (var i = 0; i < data.length; i++) {
        var mother = data[i].mother;
        var father = data[i].father;

        dictionary[mother] = data[i];
        dictionary[father] = data[i];
    }

    for (var name in dictionary) {
        var node = dictionary[name];

        for (var i = 0; i < node.children.length; i++) {
            var childName = node.children[i];

            if (dictionary[childName] && !(childName instanceof Node)) {
                node.children[i] = dictionary[childName];

                if (dictionary[childName].mother === childName) {
                    dictionary[childName].isFemale = true;
                }
            } 
            else if (!(childName instanceof Node)) {
                var leaf = new Node(null, childName);
                dictionary[childName] = leaf;
                node.children[i] = leaf;
            }
        }
    }

    return dictionary;
}

function findRoot(tree, dictionary) {
    var root = null;

    for (var i = 0; i < tree.length; i++) {
        var mother = tree[i].mother;
        var father = tree[i].father;
        var isRoot = true;

        for (var j = 0; j < tree.length; j++) {
            if (i == j) {
                continue;
            }

            if (tree[j].hasChild(mother) || tree[j].hasChild(father)) {
                isRoot = false;
                break;
            }
        }

        if (isRoot) {
            root = tree[i];
            break;
        }
    }

    return dictionary[root.mother];
}

function drawFamilyTree(layer, root) {
    var queue = [];
    root.level = levelStartHeight;
    root.posX = posX;
    queue.push(root);

    while (queue.length > 0) {
        var node = queue.shift();

        for (var i = 0; i < node.children.length; i++) {
            var child = node.children[i];
            child.level = node.level + levelStep;
            child.num = i;

            var paddingRight = 0;
            if (node.children.length > 1) {
                paddingRight = widthStep * (node.children.length - 1);
            }

            child.posX = node.posX + posXStep * i - paddingRight;
            queue.push(node.children[i]);
        }

        drawSubTree(layer, node);
    }
}

function drawSubTree(layer, root) {
    if (root.father) {
        addFigureToLayer(layer, root.posX, root.level, root.father || "", 5);
    }

    if (root.mother) {
        addFigureToLayer(layer, root.posX + widthStep, root.level, root.mother || "", 17);
    }

    // Connect father <-> mother
    if (root.father && root.mother) {
        var line = getLine(root.posX, root.level);
        layer.add(line);
    }

    // Connect (father, mother) <-> { children }
    for (var i = 0; i < root.children.length; i++) {
        var child = root.children[i];
        var x = child.posX + nodeWidth / 2;
        if (child.father === null || child.isFemale) {
            x += widthStep;
        }

        makeConnection(root.posX - 20, root.level, x - 50, child.level - 1, layer);
    }
}

function makeConnection(leftParentX, leftParentY, childX, childY, layer) {
    var startX = leftParentX + nodeWidth * 1.25;
    var startY = leftParentY + nodeHeight / 2 - 4;
    var endX = childX + nodeWidth / 2;
    var endY = childY;
    innerGetBezierLine(startX, startY, endX, endY, layer);

    function innerGetBezierLine(stX, stY, eX, eY) {
        var beizerCPdx = Math.abs(eX - stX) / 10;
        var beizerCPdY = Math.abs(eY - stY) * 0.95;
        var currLine = new Kinetic.Shape({
            drawFunc: function(context) {
                context.beginPath();
                context.moveTo(stX, stY);
                context.bezierCurveTo(stX + beizerCPdx, stY + beizerCPdY,
                    eX - beizerCPdx, eY - beizerCPdY,
                    eX, eY);
                context.strokeShape(this);
                context.beginPath();
                context.lineTo(eX + 5, eY - 5);
                context.lineTo(eX - 5, eY - 5);
                context.lineTo(eX, eY);
                context.fillShape(this);
            },
            strokeWidth: 1,
            fill: '#77B300',
            stroke: '#77B300',
        });

        layer.add(currLine);
    }
}

function addFigureToLayer(layer, posX, posY, text, radius) {
    var nodeText = getNodeText(posX, posY, text);
    var nodeFigure = getRect(posX, posY, nodeText.height(), radius);
    layer.add(nodeFigure);
    layer.add(nodeText);
}

function getNodeText(posX, posY, text) {
    var nodeText = new Kinetic.Text({
        x: posX,
        y: posY,
        width: nodeWidth,
        padding: 10,
        text: text,
        fontSize: fontSize,
        fill: 'black',
        align: 'center'
    });
    return nodeText;
}

function getRect(posX, posY, height, radius) {
    var rect = new Kinetic.Rect({
        x: posX,
        y: posY,
        width: nodeWidth,
        stroke: '#77B300',
        strokeWidth: 1,
        height: height,
        cornerRadius: radius
    });
    return rect;
}

function getLine(posX, posY) {
    var line = new Kinetic.Line({
        points: [0, 0, nodeWidth - widthStep, 0],
        stroke: '#77B300',
        strokeWidth: 2
    });
    line.move({
        x: posX + widthStep,
        y: posY + nodeHeight / 2 - 5
    });
    return line;
}

function Node(mother, father, childs) {
    this.mother = mother;
    this.father = father;
    this.children = childs || [];
    this.isFemale = false;
    return this;
}

Node.prototype.hasChild = function(name) {
    for (var i = 0; i < this.children.length; i++) {
        var child = this.children[i];
        if (child.mother === name || child.father === name) {
            return true;
        }
    }
};