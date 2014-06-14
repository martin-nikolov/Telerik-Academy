window.onload = function() {
    Handlebars.registerHelper('list', function(items, options) {
        var html = "";

        for (var index in items) {
            var item = items[index];
            html += options.fn({
                index: index,
                title: item.title,
                firstDate: item.firstDate.toUTCString(),
                secondDate: item.secondDate.toUTCString()
            });
        }

        return html;
    });

    var courses = [{
        title: 'Course Introduction',
        firstDate: new Date(),
        secondDate: new Date()
    }, {
        title: 'Document Object Model',
        firstDate: new Date(),
        secondDate: new Date()
    }, {
        title: 'HTML5 Canvas',
        firstDate: new Date(),
        secondDate: new Date()
    }, {
        title: 'Kinetic.js Overview',
        firstDate: new Date(),
        secondDate: new Date()
    }, {
        title: 'SVG and Raphael.js',
        firstDate: new Date(),
        secondDate: new Date()
    }, {
        title: 'DOM Operations',
        firstDate: new Date(),
        secondDate: new Date()
    }];

    var coursesTemplateHtml = document.getElementById('courses-row-template').innerHTML;
    var coursesTemplate = Handlebars.compile(coursesTemplateHtml);

    var tableBody = document.getElementById('courses-table-body');
    tableBody.innerHTML = coursesTemplate({
        courses: courses
    });
};