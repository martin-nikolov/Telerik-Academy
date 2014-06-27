window.onload = function() {
    var layer = new Drawer.Layer({
        containerId: 'drawer-container',
        width: 1000,
        height: 500
    });

    var rect = new Drawer.Rect({
        x: 50,
        y: 50,
        width: 50,
        height: 50
    });

    var circle = new Drawer.Circle({
        x: 150,
        y: 150,
        radius: 25
    });

    var line = new Drawer.Line({
        x1: 200,
        y1: 250,
        x2: 350,
        y2: 150
    });

    layer.add(rect)
    layer.add(circle)
    layer.add(line)

    /* ----------------------- */

    console.log(layer)
    console.log(rect);
    console.log(circle);
    console.log(line);

    /* ----------------------- */

    var layer2 = new Drawer.Layer({
        containerId: 'drawer-container',
        width: 500,
        height: 500
    })
    .add(new Drawer.Rect({
        height: 25,
        width: 50,
        x: 50,
        y: 200
    }));
}