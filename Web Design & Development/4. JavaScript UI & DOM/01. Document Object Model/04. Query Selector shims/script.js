/*
    4. *Write a script that shims querySelector 
    and querySelectorAll in older browsers
*/

taskName = "4. Query Selector shims";

function Main(bufferElement) {

    var minButtons = document.querySelectorAll('#control-buttons > button');
    WriteLine("querySelectorAll('#control-buttons > button')[0] -> " + minButtons[0]);
    
    WriteLine();

    var minButton = document.querySelector('button#minimize-button');
    WriteLine("querySelector(button#minimize-button') -> " + minButton);

    WriteLine();

    var consoleTitle = document.querySelector('#main-container #title-bar span#title');
    WriteLine("querySelector('#main-container #title-bar span#title') -> " + consoleTitle);
    
    WriteLine();

    var consoleIcon = document.querySelector('body div > div > img + div button img');
    WriteLine("querySelector('body div > div > img + div button img') -> " + consoleIcon);
}

;(function shimQuerySelector() {
    if (typeof document.querySelector === 'undefined') {
        querySelectorAllShim();
        querySelectorShim();

        alert("querySelector shim added!");
    }
}())

// Here's a script which adds IE-style createStyleSheet()
// and addRule() methods to browsers which don't have them:
// StackOverFlow - http://goo.gl/jiwq0c/
;(function shimStyleSheet() {
    if (typeof document.createStyleSheet === 'undefined') {
        document.createStyleSheet = (function() {
            function createStyleSheet(href) {
                if (typeof href !== 'undefined') {
                    var element = document.createElement('link');
                    element.type = 'text/css';
                    element.rel = 'stylesheet';
                    element.href = href;
                }
                else {
                    var element = document.createElement('style');
                    element.type = 'text/css';
                }

                document.getElementsByTagName('head')[0].appendChild(element);
                var sheet = document.styleSheets[document.styleSheets.length - 1];

                if (typeof sheet.addRule === 'undefined')
                    sheet.addRule = addRule;

                if (typeof sheet.removeRule === 'undefined')
                    sheet.removeRule = sheet.deleteRule;

                return sheet;
            }

            function addRule(selectorText, cssText, index) {
                if (typeof index === 'undefined')
                    index = this.cssRules.length;

                this.insertRule(selectorText + ' {' + cssText + '}', index);
            }

            return createStyleSheet;
        })();
    }
}());

// IE7 support for querySelectorAll. Supports multiple / grouped 
// selectors and the attribute selector with a "for" attribute. 
// http://www.codecouch.com/
function querySelectorAllShim() {
    (function(doc, styleSheet) {
        doc = document, styleSheet = doc.createStyleSheet();

        doc.querySelectorAll = function(selector) {
            var allDocElements = doc.all, collection = [];
            selector = selector.replace(/\[for\b/gi, '[htmlFor').split(',');

            for (var i = selector.length; i--;) {
                styleSheet.addRule(selector[i], 'k:v');

                for (var j = allDocElements.length; j--;)  {
                    allDocElements[j].currentStyle.k && collection.push(allDocElements[j]);
                }

                styleSheet.removeRule(0);
            }

            return collection;
        };
    })();
}

function querySelectorShim() {
    document.querySelector = function(selector) {
        var result = this.querySelectorAll(selector);
        return result[0] || null;
    };
}