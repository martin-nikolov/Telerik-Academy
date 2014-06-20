define(function(require) {

    // Consts
    var MONTH_NAME = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    var PRIORITY = {
        'Low': 0,
        'Medium': 1,
        'High': 2
    };

    function getFormattedDate(date) {
        return MONTH_NAME[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
    }

    function getCheckedRadio(collection) {
        for (var i = 0; i < collection.length; i++) {
            if (collection[i].checked) {
                collection[i].checked = false;
                return collection[i].value;
            }
        }

        return collection[0].value;
    }

    function resetInputProperties() {
        for (var i = 0; i < arguments.length; i++) {
            arguments[i].value = '';
            arguments[i].style.boxShadow = "";
        }
    }

    function showElements(type) {
        type = type || 'inline-block';

        for (var i = 1; i < arguments.length; i++) {
            arguments[i].style.display = type;
        }
    }

    function hideElements() {
        for (var i = 0; i < arguments.length; i++) {
            arguments[i].style.display = 'none';
        }
    }

    function removeAllChilds(item) {
        while (item.firstChild) {
            item.removeChild(item.firstChild);
        }
    }

    function addChildsRange(container) {
        for (var i = 1; i < arguments.length; i++) {
            container.appendChild(arguments[i]);
        }
    }

    function createElement(type, className) {
        var element = document.createElement(type);
        element.className = className;
        return element;
    }

    function removePriorityClasses(element) {
        for (var priorName in PRIORITY) {
            element.classList.remove(priorName.toLowerCase());
        }
    }

    function getShortStringIfNecessary(string, maxLen) {
        return string.length > maxLen ? string.substr(0, maxLen) + '...' : string;
    }

    return {
        PRIORITY: PRIORITY,
        getFormattedDate: getFormattedDate,
        getCheckedRadio: getCheckedRadio,
        resetInputProperties: resetInputProperties,
        showElements: showElements,
        hideElements: hideElements,
        removeAllChilds: removeAllChilds,
        addChildsRange: addChildsRange,
        createElement: createElement,
        removePriorityClasses: removePriorityClasses,
        getShortStringIfNecessary: getShortStringIfNecessary
    };
});