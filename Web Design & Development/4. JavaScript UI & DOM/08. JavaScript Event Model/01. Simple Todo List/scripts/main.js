define(function(require) {

    // Include classes
    var SimpleOrganizer = require('scripts/Classes/SimpleOrganizer.js');

    var simpleOrganizer = new SimpleOrganizer();

    simpleOrganizer.addTask('CSS - Exam', '1-2 March', 'Low');
    simpleOrganizer.addTask('HTML - Exam', '22-23 March', 'Medium');
    simpleOrganizer.addTask('JavaScript - Exam', '5-6 June', 'High');

    simpleOrganizer.addTask('Database - Exam', '8-9 June', 'Medium');
    simpleOrganizer.addTask('C# Part 1 - Exam', '15-17 June', 'Low');
    simpleOrganizer.addTask('C# Part 2 - Exam', '20-21 June', 'Low');

    simpleOrganizer.addTask('C# OOP - Exam', '22-23 June', 'High');
    simpleOrganizer.addTask('C++ - Exam', '22-23 July', 'Medium');
    simpleOrganizer.addTask('PHP - Exam', '5-6 August', 'Low');
});