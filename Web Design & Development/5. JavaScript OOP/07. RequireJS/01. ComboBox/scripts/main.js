(function() {
    'use strict';
    require.config({
        paths: {
            "jquery": "library/jquery-2.1.1.min",
            "handlebars": "library/handlebars-v1.3.0",
            "controls": "Controls",
        }
    });

    require(['controls', 'jquery', 'handlebars'], function (Controls, $) {
        var PERSON_TEMPLATE_ID = '#person-template',
            COMBOBOX_CONTAINER_ID = '#comboBox';

        var people = [
            { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "../images/minkov.jpg" }, 
            { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "../images/joreto.jpg" }
        ];

        var comboBox = new Controls.ComboBox(people);
        var template = $(PERSON_TEMPLATE_ID).html();
        var comboBoxHtml = comboBox.convertToHtml(template);

        var container = $(COMBOBOX_CONTAINER_ID);
        container.html(comboBoxHtml);
    });
}());