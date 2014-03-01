window.onload = function() {

    // Simple Organizer Module
    SimpleOrganizer = (function() {
        // Const
        var MONTH_NAME = [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ];

        var _currentItemForEdition = null; // Very bad solution

        // Containers
        var _mainMenu = document.getElementById('main-menu');
        var _taskItems = document.getElementById('task-items');
        var _createItem = document.getElementById('create-item');
        var _itemInfoContainer = document.getElementById('task-item-info');
        var _itemInfoInnerContainer = document.getElementById('task-item-info-wrapper');

        // Navigation Buttons
        var _header = document.getElementById('header');
        var _homeButton = document.getElementById('home');
        var _navSpace = document.getElementById('nav');        
        var _navSpaceSmall = document.getElementById('nav-small');        
        var _addItem = document.getElementById('add-item');
        var _deleteItem = document.getElementById('delete-item');
        var _saveItem = document.getElementById('save-item');
        var _editItem = document.getElementById('edit-item');

        // Home Buttons
        var _allTasksButton = document.getElementById('tasks');
        var _createTaskButton = document.getElementById('create-task');

        // Create New Item - Form inputs
        var _taskTitle = document.getElementById('task-title');
        var _taskContent = document.getElementById('task-content');
        var _priorityRadios = document.querySelectorAll('#priority input[type=radio]');

        // Messages
        var _savedMsg = document.getElementById('saved');
        var _updatedMsg = document.getElementById('updated');
        var _deletedMsg = document.getElementById('deleted');

        // Set events
        function _setButtonEvents() {
            _allTasksButton.onclick = function() {
                _hideElements(_mainMenu, _header);
                _showElements('inline-block', _homeButton, _navSpace, _addItem);
                _showElements('block', _taskItems);
            };

            // On Create New Task Item - Button Click
            _createTaskButton.onclick = function() {
                _hideElements(_mainMenu, _header);
                _showElements('inline-block', _homeButton, _navSpace, _saveItem);
                _showElements('block', _createItem);

                if (_currentItemForEdition) {
                    _taskTitle.value = _currentItemForEdition.taskTitle;
                    _taskContent.value = _currentItemForEdition.taskContent;
                }
            };

            _addItem.onclick = function() { _homeButton.click(); _createTaskButton.click(); };

            // On Save The New Task Item - Button Click
            _saveItem.onclick = function() {
                _taskTitle.style.boxShadow = !_taskTitle.value ? '0px 0px 5pt 1pt red' : "";
                _taskContent.style.boxShadow = !_taskContent.value ? '0px 0px 5pt 1pt red' : "";

                if (!_taskTitle.value || !_taskContent.value) {
                    return;
                }

                var selectedPriority = _getCheckedRadio(_priorityRadios);

                if (_currentItemForEdition) {
                    _currentItemForEdition.taskTitle = _taskTitle.value;
                    _currentItemForEdition.taskContent = _taskContent.value;

                    // Show - Saved Message
                    _showElements('inline-block', _updatedMsg);
                    setTimeout(function() { _hideElements(_updatedMsg); }, 1500);
                }
                else {
                    _addItemToView(new Task(_taskTitle.value, _taskContent.value, selectedPriority));

                    // Show - Saved Message
                    _showElements('inline-block', _savedMsg);
                    setTimeout(function() { _hideElements(_savedMsg); }, 1500);
                }

                _resetInputProperties(_taskTitle, _taskContent);

                _homeButton.click();
                _allTasksButton.click();
            };

            // On Home Button Click
            _homeButton.onclick = function() {
                _hideElements(_homeButton, _navSpace, _addItem, _saveItem, _createItem, _taskItems, _itemInfoContainer, _deleteItem, _editItem, _navSpaceSmall);
                _showElements('block', _mainMenu, _header);
                _resetInputProperties(_taskTitle, _taskContent);
                _currentItemForEdition = null;
                _getCheckedRadio(_priorityRadios); // Reset checked radio
            };
        }

        function Task(taskTitle, taskContent, priority) {
            this.taskTitle = taskTitle;
            this.taskContent = taskContent.substr(0, 400);
            this.taskDate = new Date();
            this.priority = priority;
        }

        function _addItemToView(task) {
            var wrapper = document.createElement('div');
            wrapper.className = 'wrapper-gradient item';

            var itemContainer = document.createElement('div');
            itemContainer.className = 'item-container';

            var itemTitle = document.createElement('div');
            itemTitle.className = 'item-title';
            itemTitle.innerHTML = task.taskTitle.length > 18 ? task.taskTitle.substr(0, 18) + '...' : task.taskTitle;

            var itemContent = document.createElement('div');
            itemContent.className = 'item-content';
            itemContent.innerHTML = task.taskContent.length > 25 ? task.taskContent.substr(0, 25) + '...' : task.taskContent;

            var itemDate = document.createElement('div');
            itemDate.className = 'item-date';
            itemDate.innerHTML = _getFormattedDate(task.taskDate);

            var itemPriorityImg = document.createElement('img');
            itemPriorityImg.className = 'item-priority-img';
            itemPriorityImg.setAttribute('src', 'images/' + task.priority.toLowerCase() + '.png');

            itemContainer.appendChild(itemTitle);
            itemContainer.appendChild(itemDate);
            itemContainer.appendChild(itemContent);
            itemContainer.appendChild(itemPriorityImg);

            wrapper.appendChild(itemContainer);

            wrapper.onclick = function() {
                _hideElements(_taskItems, _addItem, _navSpace);
                _showElements('inline-block', _navSpaceSmall, _editItem, _deleteItem);
                _showElements('block', _itemInfoContainer);
                _changeItemInfoContainer(task);

                _deleteItem.onclick = function() {
                    _taskItems.removeChild(wrapper);
                    _homeButton.click();
                    _allTasksButton.click();

                    // Show - Remove Message
                    _showElements('inline-block', _deletedMsg);
                    setTimeout(function() { _hideElements(_deletedMsg); }, 1500);
                };

                _editItem.onclick = function() {
                    _homeButton.click();
                    _currentItemForEdition = task;
                    _createTaskButton.click();
                };
            }

            _taskItems.appendChild(wrapper);
        }

        function _changeItemInfoContainer(task) {
            // Remove all childs
            while (_itemInfoInnerContainer.firstChild) {
                _itemInfoInnerContainer.removeChild(_itemInfoInnerContainer.firstChild);
            }

            var taskTitle = document.createElement('div');
            taskTitle.innerHTML = task.taskTitle;
            taskTitle.className = 'item-title';

            var taskDate = document.createElement('div');
            taskDate.innerHTML = _getFormattedDate(task.taskDate);
            taskDate.className = 'item-date';

            var taskContent = document.createElement('div');
            taskContent.innerHTML = task.taskContent;
            taskContent.className = 'item-content';

            var taskPriorityImg = document.createElement('img');
            taskPriorityImg.setAttribute('src', 'images/' + task.priority.toLowerCase() + '.png');
            taskPriorityImg.className = 'item-priority-img';

            _itemInfoInnerContainer.appendChild(taskTitle);
            _itemInfoInnerContainer.appendChild(taskDate);
            _itemInfoInnerContainer.appendChild(taskContent);
            _itemInfoInnerContainer.appendChild(taskPriorityImg);
        }

        function _getFormattedDate(date) {
            return MONTH_NAME[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
        }

        function _getCheckedRadio(collection) {
            for (var i = 0; i < collection.length; i++) {
                if (collection[i].checked) {
                    collection[i].checked = false;
                    return collection[i].value;
                }
            }

            return collection[0].value;
        }

        function _resetInputProperties() {
            for (var i = 0; i < arguments.length; i++) {
                arguments[i].value = '';
                arguments[i].style.boxShadow = "";
            }
        }

        function _hideElements() {
            for (var i = 0; i < arguments.length; i++) {
                arguments[i].style.display = 'none';
            }
        }

        function _showElements(type) {
            type = type || 'inline-block';

            for (var i = 1; i < arguments.length; i++) {
                arguments[i].style.display = type;
            }
        }

        function _initialize() {
            _setButtonEvents();
        }

        return {
            initialize: function() { _initialize(); },
            addTask: function(taskTitle, taskContent, priority) { 
                _addItemToView(new Task(taskTitle, taskContent, priority)); 
            }
        }
    }());

    SimpleOrganizer.initialize();

    SimpleOrganizer.addTask('CSS - Exam', '1-2 March', 'Low');
    SimpleOrganizer.addTask('HTML - Exam', '22-23 March', 'Medium');
    SimpleOrganizer.addTask('JavaScript - Exam', '5-6 June', 'High');

    SimpleOrganizer.addTask('Database - Exam', '8-9 June', 'Medium');
    SimpleOrganizer.addTask('C# Part 1 - Exam', '15-17 June', 'Low');
    SimpleOrganizer.addTask('C# Part 2 - Exam', '20-21 June', 'Low');

    SimpleOrganizer.addTask('C# OOP - Exam', '22-23 June', 'High');
    SimpleOrganizer.addTask('C++ - Exam', '22-23 July', 'Medium');
    SimpleOrganizer.addTask('PHP - Exam', '5-6 August', 'Low');
}