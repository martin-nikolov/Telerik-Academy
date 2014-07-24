define(['todo-list/section'], function(Section) {
    'use strict';

    var Container = (function() {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function(section) {
            if (!(section instanceof Section)) {
                throw new Error("Object 'section' is not instance of Section");
            }

            this._sections.push(section);
            return this;
        }

        Container.prototype.getData = function() {
            var sections = [],
                section, i, len;

            for (i = 0, len = this._sections.length; i < len; i++) {
                section = this._sections[i];
                sections.push(section.getData());
            }

            return sections;
        }

        return Container;
    }());

    return Container;
});