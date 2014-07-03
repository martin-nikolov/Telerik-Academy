define(function() {
    'use strict';

    var Controls = (function() {
        var ComboBox = (function() {
            var _people = [];

            function ComboBox(people) {
                if (!people || !Array.isArray(people)) {
                    throw new Error('Array people[] is not defined.');
                }

                _people = people;
            }

            ComboBox.prototype.convertToHtml = function(htmlTemplate) {
                console.log('render');
                return null;
            };

            return ComboBox;
        }());

        return {
            ComboBox: ComboBox
        }
    }());

    return Controls;
});