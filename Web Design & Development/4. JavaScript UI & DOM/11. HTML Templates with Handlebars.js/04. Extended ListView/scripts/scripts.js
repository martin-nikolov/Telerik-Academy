(function($) {
    $.fn.listView = function(items) {
        var itemsContainer = $(this);
        var itemsTemplate = selectTemplate(itemsContainer);
        appendItemsToContainer(items, itemsTemplate, itemsContainer);
    };
}(jQuery));

function selectTemplate(itemsContainer) {
    var itemsTemplate = Handlebars.compile(itemsContainer.html());
    return itemsTemplate;
}

function appendItemsToContainer(items, template, container) {
    var html = "";
    for (var item in items) {
        html += template(items[item]);
    }
    container.html(html);
}