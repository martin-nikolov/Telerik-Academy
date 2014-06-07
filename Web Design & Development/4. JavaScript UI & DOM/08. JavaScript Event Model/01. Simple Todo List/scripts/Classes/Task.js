define(function(require) {

    // Constructor
    function Task(taskTitle, taskContent, priority) {
        this.taskTitle = taskTitle;
        this.taskContent = taskContent.substr(0, 400);
        this.taskDate = new Date();
        this.priority = priority;
    }

    return Task;
});