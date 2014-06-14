window.onload = function() {
    var items = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }];

    var optionsTemplate = selectTemplate('select-option-template');
    appendItems(items, optionsTemplate, 'select-menu');
};

function selectTemplate(templateId) {
    var optionsTemplateHtml = document.getElementById(templateId).innerHTML;
    var optionsTemplate = Handlebars.compile(optionsTemplateHtml);
    return optionsTemplate;
}

function appendItems(items, template, containerId) {
    var selectMenu = document.getElementById(containerId);
    selectMenu.innerHTML = template({
        items: items
    });
}