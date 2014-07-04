define(function() {
    'use strict';

    var Controls = (function() {
        var ComboBox = (function() {
            function ComboBox(params) {
                if (!params.people || !Array.isArray(params.people)) {
                    throw new Error('Array people[] is not defined.');
                }

                this._container = $(params.container);
                this._people = params.people;
                this._template = params.template;

                _createComboBox(this);
            }

            function _createComboBox(comboBox) {
                var $compiledHtml = _convertToHtml({
                    objs: comboBox._people,
                    template: comboBox._template
                })

                // Set events on '.person-item' element
                comboBox._container.on('click', '.person-item:not(#selected-item)', function(e) {
                    var $selectedItem = comboBox._container.find('#selected-item');
                    $selectedItem.html($(this).html()).click();
                });

                var selectedItemContainer = _createSelectedItemContainer({
                    obj: comboBox._people[0], // XXX
                    template: comboBox._template,
                    id: 'selected-item'
                })
                .on('click', function() {
                    comboBox._container.find('.person-item:not(#selected-item)').slideToggle();
                });

                // Adds elements to DOM
                comboBox._container.html($compiledHtml);
                comboBox._container.prepend(selectedItemContainer);
            }

            function _convertToHtml(params) {
                var html = '', obj;
                for (obj in params.objs) {
                    html += params.template(params.objs[obj]);
                }
                return $(html);
            };

            function _createSelectedItemContainer(params) {
                var $selectedItemContainer = $(params.template(params.obj));
                $selectedItemContainer.attr('id', params.id);
                return $selectedItemContainer;
            }

            return ComboBox;
        }());

        return {
            ComboBox: ComboBox
        }
    }());

    return Controls;
});