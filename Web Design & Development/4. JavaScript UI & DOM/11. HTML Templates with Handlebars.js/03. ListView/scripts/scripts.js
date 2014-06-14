(function($) {
    $.fn.listView = function(items) {
        var itemsContainer = $(this);
        var dataAttrId = '#' + itemsContainer.attr('data-template');

        var itemsTemplate = selectTemplate(dataAttrId);
        appendItemsToContainer(items, itemsTemplate, itemsContainer);
    };
}(jQuery));

function selectTemplate(dataAttrId) {
    var itemsTemplateHTML = $(dataAttrId).html();
    var itemsTemplate = Handlebars.compile(itemsTemplateHTML);
    return itemsTemplate;
}

function appendItemsToContainer(items, template, container) {
    var html = "";
    for (var item in items) {
        html += template(items[item]);
    }
    container.html(html);
}

