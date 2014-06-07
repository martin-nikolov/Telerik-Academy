define(function(require) {

    var Nav = {};

    // Containers
    Nav.mainMenu = document.getElementById('main-menu');
    Nav.taskItems = document.getElementById('task-items');
    Nav.createItem = document.getElementById('create-item');
    Nav.itemInfoContainer = document.getElementById('task-item-info');
    Nav.itemInfoInnerContainer = document.getElementById('task-item-info-wrapper');

    // Navigation Buttons
    Nav.header = document.getElementById('header');
    Nav.homeButton = document.getElementById('home');
    Nav.navSpace = document.getElementById('nav');
    Nav.navSpaceSmall = document.getElementById('nav-small');
    Nav.addItem = document.getElementById('add-item');
    Nav.deleteItem = document.getElementById('delete-item');
    Nav.saveItem = document.getElementById('save-item');
    Nav.editItem = document.getElementById('edit-item');

    // Home Buttons
    Nav.allTasksButton = document.getElementById('tasks');
    Nav.createTaskButton = document.getElementById('create-task');

    // Create New Item - Form inputs
    Nav.taskTitle = document.getElementById('task-title');
    Nav.taskContent = document.getElementById('task-content');
    Nav.priorityRadios = document.querySelectorAll('#priority input[type=radio]');

    // Messages
    Nav.savedMsg = document.getElementById('saved');
    Nav.updatedMsg = document.getElementById('updated');
    Nav.deletedMsg = document.getElementById('deleted');

    return Nav;
});