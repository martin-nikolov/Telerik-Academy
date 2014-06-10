$.fn.tabs = function() {
    $('#tabs-container').addClass('tabs-container');
    var tabs = $('.tab-item');

    tabs.on('click', function() {
        tabs.removeClass('current');
        $('.tab-item-content').hide();
        $(this).addClass('current');
        $(this).find('.tab-item-content').show();
    });

    tabs.first().click();
};