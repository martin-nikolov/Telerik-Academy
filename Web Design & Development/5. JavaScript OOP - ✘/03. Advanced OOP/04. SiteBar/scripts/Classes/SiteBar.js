define(function(require) {

    // Include utility
    var Class = require('../Helper/utility.js');

    var siteBarContainer = _createSiteBarContainer();

    function _createSiteBarContainer() {
        var div = document.createElement('div');
        div.id = 'sitebar';

        return div;
    }

    function _addUrl(url) {
        siteBarContainer.appendChild(url.convertToHtml());
    }

    function _addFolder(folder) {
        siteBarContainer.appendChild(folder.convertToHtml());
    }

    function _convertToHtml() {
        return siteBarContainer;
    }

    var SiteBar = Class.create({
        init: function() {  
            return this;
        },
        addUrl: function(url) { _addUrl(url); },
        addFolder: function(folder) { _addFolder(folder); },
        convertToHtml: function() { return _convertToHtml(); }
    });

    return SiteBar;
})