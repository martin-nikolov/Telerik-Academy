define(function(require) {

    var Utils = require('../Helper/Utils.js');
    var Nav = require('./Navigation.js');
    var Task = require('./Task.js');

    var _currentItemForEdition = null;
    var _addItemToViewRef = null;
    var _changeItemInfoContainerRef = null;

    // Constructor
    function EventListener(addItemToView, changeItemInfoContainer) {
        _addItemToViewRef = addItemToView;
        _changeItemInfoContainerRef = changeItemInfoContainer;
    }

    EventListener.prototype.setEventOnClick = function(wrapper, taskContainer, task) {
        wrapper.onclick = function() {
            Utils.hideElements(Nav.taskItems, Nav.addItem, Nav.navSpace);
            Utils.showElements('inline-block', Nav.navSpaceSmall, Nav.editItem, Nav.deleteItem);
            Utils.showElements('block', Nav.itemInfoContainer);
            _changeItemInfoContainerRef(task);

            Nav.deleteItem.onclick = function() {
                Nav.taskItems.removeChild(wrapper);
                Nav.homeButton.click();
                Nav.allTasksButton.click();

                // Show - Remove Message
                Utils.showElements('inline-block', Nav.deletedMsg);
                setTimeout(function() {
                    Utils.hideElements(Nav.deletedMsg);
                }, 1500);
            };

            Nav.editItem.onclick = function() {
                Nav.homeButton.click();

                _currentItemForEdition = {
                    task: task,
                    items: taskContainer.childNodes
                };

                Nav.createTaskButton.click();
            };
        };
    };

    EventListener.prototype.setButtonEvents = function() {
        Nav.allTasksButton.onclick = function() {
            Utils.hideElements(Nav.mainMenu, Nav.header);
            Utils.showElements('inline-block', Nav.homeButton, Nav.navSpace, Nav.addItem);
            Utils.showElements('block', Nav.taskItems);
        };

        // On Create New Task Item - Button Click
        Nav.createTaskButton.onclick = function() {
            Utils.hideElements(Nav.mainMenu, Nav.header);
            Utils.showElements('inline-block', Nav.homeButton, Nav.navSpace, Nav.saveItem);
            Utils.showElements('block', Nav.createItem);

            if (_currentItemForEdition) {
                Nav.taskTitle.value = _currentItemForEdition.task.taskTitle;
                Nav.taskContent.value = _currentItemForEdition.task.taskContent;
                Nav.priorityRadios[Utils.PRIORITY[_currentItemForEdition.task.priority]].checked = true;
            }
        };

        Nav.addItem.onclick = function() {
            Nav.homeButton.click();
            Nav.createTaskButton.click();
        };

        // On Save The New Task Item - Button Click
        Nav.saveItem.onclick = function() {
            Nav.taskTitle.style.boxShadow = !Nav.taskTitle.value ? '0px 0px 5pt 1pt red' : "";
            Nav.taskContent.style.boxShadow = !Nav.taskContent.value ? '0px 0px 5pt 1pt red' : "";

            if (!Nav.taskTitle.value || !Nav.taskContent.value) {
                return;
            }

            var selectedPriority = Utils.getCheckedRadio(Nav.priorityRadios);

            if (_currentItemForEdition) {
                // Edit current item properties
                _currentItemForEdition.task.taskTitle = Nav.taskTitle.value;
                _currentItemForEdition.task.taskContent = Nav.taskContent.value;
                _currentItemForEdition.task.taskDate = new Date();
                _currentItemForEdition.task.priority = selectedPriority;

                // Edit (refresh) item view with the new value
                _currentItemForEdition.items[0].innerHTML = Utils.getShortStringIfNecessary(_currentItemForEdition.task.taskTitle, 20);
                _currentItemForEdition.items[1].innerHTML = Utils.getFormattedDate(_currentItemForEdition.task.taskDate);
                _currentItemForEdition.items[2].innerHTML = Utils.getShortStringIfNecessary(_currentItemForEdition.task.taskContent, 30);

                Utils.removePriorityClasses(_currentItemForEdition.items[3]);
                _currentItemForEdition.items[3].classList.add(selectedPriority.toLowerCase()); // HACK

                // Show - Saved Message
                Utils.showElements('inline-block', Nav.updatedMsg);
                setTimeout(function() {
                    Utils.hideElements(Nav.updatedMsg);
                }, 1500);
            }
            else {
                _addItemToViewRef(new Task(Nav.taskTitle.value, Nav.taskContent.value, selectedPriority));

                // Show - Saved Message
                Utils.showElements('inline-block', Nav.savedMsg);
                setTimeout(function() {
                    Utils.hideElements(Nav.savedMsg);
                }, 1500);
            }

            Utils.resetInputProperties(Nav.taskTitle, Nav.taskContent);

            Nav.homeButton.click();
            Nav.allTasksButton.click();
        };

        // On Home Button Click
        Nav.homeButton.onclick = function() {
            Utils.hideElements(Nav.homeButton, Nav.navSpace, Nav.addItem, Nav.saveItem, Nav.createItem, Nav.taskItems, Nav.itemInfoContainer, Nav.deleteItem, Nav.editItem, Nav.navSpaceSmall);
            Utils.showElements('block', Nav.mainMenu, Nav.header);
            Utils.resetInputProperties(Nav.taskTitle, Nav.taskContent);
            Utils.getCheckedRadio(Nav.priorityRadios); // Reset checked radio

            _currentItemForEdition = null;
        };
    };

    return EventListener;
});