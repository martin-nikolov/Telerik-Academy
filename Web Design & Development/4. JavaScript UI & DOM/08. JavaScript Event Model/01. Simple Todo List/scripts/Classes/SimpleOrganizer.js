define(function(require) {

    var Utils = require('../Helper/Utils.js');
    var Nav = require('./Navigation.js');
    var Task = require('./Task.js');
    var EventListener = require('./EventListener.js');

    var eventListener = null;

    // Constructor
    function SimpleOrganizer() {
        var _addItemToViewRef = _addItemToView; // Reference to function
        var _changeItemInfoContainerRef = _changeItemInfoContainer; // Reference to function

        eventListener = new EventListener(_addItemToViewRef, _changeItemInfoContainerRef);
        eventListener.setButtonEvents();
    }

    function _addItemToView(task) {
        var taskTitle = Utils.createElement('div', 'item-title');
        taskTitle.innerHTML = _getShortStringIfNecessary(task.taskTitle, 20);

        var taskContent = Utils.createElement('div', 'item-content');
        taskContent.innerHTML = Utils.getShortStringIfNecessary(task.taskContent, 30);

        var taskDate = Utils.createElement('div', 'item-date');
        taskDate.innerHTML = Utils.getFormattedDate(task.taskDate);

        var taskPriorImg = Utils.createElement('img', 'item-priority-img prior ' + task.priority.toLowerCase());

        var taskContainer = Utils.createElement('div', 'item-container');
        Utils.addChildsRange(taskContainer, taskTitle, taskDate, taskContent, taskPriorImg);

        var wrapper = Utils.createElement('div', 'item wrapper-gradient');
        wrapper.appendChild(taskContainer);

        Nav.taskItems.appendChild(wrapper);
        eventListener.setEventOnClick(wrapper, taskContainer, task);
    }

    function _changeItemInfoContainer(task) {
        Utils.removeAllChilds(Nav.itemInfoInnerContainer);

        var taskTitle = Utils.createElement('div', 'item-title');
        taskTitle.innerHTML = task.taskTitle;

        var taskContent = Utils.createElement('div', 'item-content');
        taskContent.innerHTML = task.taskContent;

        var taskDate = Utils.createElement('div', 'item-date');
        taskDate.innerHTML = Utils.getFormattedDate(task.taskDate);

        var taskPriorImg = Utils.createElement('img', 'item-priority-img prior ' + task.priority.toLowerCase());
        Utils.addChildsRange(Nav.itemInfoInnerContainer, taskTitle, taskDate, taskContent, taskPriorImg);
    }

    function _getShortStringIfNecessary(string, maxLen) {
        return string.length > maxLen ? string.substr(0, maxLen) + '...' : string;
    }

    SimpleOrganizer.prototype.addTask = function(taskTitle, taskContent, priority) {
        _addItemToView(new Task(taskTitle, taskContent, priority));
    };

    return SimpleOrganizer;
});