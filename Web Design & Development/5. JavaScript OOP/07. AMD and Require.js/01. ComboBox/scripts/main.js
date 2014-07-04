(function() {
    'use strict';
    require.config({
        paths: {
            "jquery": "library/jquery-2.1.1.min",
            "handlebars": "library/handlebars-v1.3.0",
            "controls": "controls",
        }
    });

    require(['controls', 'jquery', 'handlebars'], function (Controls) {
        var PERSON_TEMPLATE_ID = '#person-template',
            COMBOBOX_CONTAINER_ID = '#comboBox';

        var people = [
            { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/doncho.jpg" }, 
            { id: 2, name: "Ivaylo Kenov", age: 19, avatarUrl: "images/ivaylo.png" },
            { id: 3, name: "Nikolay Kostov", age: 19, avatarUrl: "images/niki.jpg" },
            { id: 4, name: "Svetlin Nakov", age: 19, avatarUrl: "images/svetlin.jpg" }
        ];

        var container = $(COMBOBOX_CONTAINER_ID),
            htmlTemplate = $(PERSON_TEMPLATE_ID).html(),
            comboBoxTemplate = Handlebars.compile(htmlTemplate); // Coupling => ComboBox does not knows about Handlebars

        var comboBox = new Controls.ComboBox({
            container: container,
            people: people,
            template: comboBoxTemplate
        });
    });
}());