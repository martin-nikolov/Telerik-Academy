define(function(require) {

    // Include utility
    var Class = require('../Helper/utility.js');

    function _convertToHtml(folderName, urls) {
        var ul = document.createElement('ul');
        var li = document.createElement('li');

        var nestedUl = document.createElement('ul');

        for (var i = 0; i < urls.length; i++) {
            var nestedLi = document.createElement('li');
            nestedLi.appendChild(urls[i].convertToHtml());
            nestedUl.appendChild(nestedLi);
        }

        var anchor = document.createElement('a');
        anchor.className = "item folder";
        anchor.innerHTML = folderName;

        li.appendChild(anchor);
        li.appendChild(nestedUl);
        ul.appendChild(li);

        return ul;
    }

    var Folder = Class.create({
        init: function(folderName, urls) {
            this.folderName = folderName;
            this.urls = Array.isArray(urls) ? urls : [];

            return this;
        },
        convertToHtml: function() { return _convertToHtml(this.folderName, this.urls); }
    });

    return Folder;
})