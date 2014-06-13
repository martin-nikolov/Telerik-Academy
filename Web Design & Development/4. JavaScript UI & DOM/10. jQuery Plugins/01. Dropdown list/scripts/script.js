(function($) {
    $.fn.dropdown = function() {
        var $this = $(this);
        $this.hide();

        var dropDownListId = '#' + $this.attr('id');

        var ddListContainer = $('<div class="dropdown-list-container" />');
        $('#wrapper').append(ddListContainer);

        var ddListOptions = $('<ul class="dropdown-list-options" />');
        ddListContainer.append(ddListOptions);

        var options = $this.find('option');
        for (var i = 0; i < options.length; i++) {
            var li = $('<li class="dropdown-list-option" />')
                .attr('data-value', options[i].value)
                .text(options[i].text);

            ddListOptions.append(li);
        }

        ddListOptions.on('click', 'li.dropdown-list-option', function(e) {
            var selectedValue = $(this).attr('data-value');
            var pattern = 'option[value=\'' + selectedValue + '\']';

            var optionForSelection = $(dropDownListId).find(pattern);
            if (optionForSelection.attr('selected')) {
                optionForSelection.removeAttr('selected', 'selected');

                $(this).css('background-color', '');
                $('#selected-item').text('Last clicked: ' + optionForSelection.html());
            } else {
                optionForSelection.attr('selected', 'selected');

                $(this).css('background-color', 'cyan');
                $('#selected-item').text('Last clicked: ' + optionForSelection.html());
            }
        });

        $this.after(ddListOptions);
        ddListOptions.hide();

        $('#dd-arrow').on('click', function() {
                ddListOptions.slideToggle();
        });

        return $this;
    };
}(jQuery));