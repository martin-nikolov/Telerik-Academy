/*
    3. By given an array of students, generate a table that represents these students
    - Each student has first name, last name and grade
    - Use jQuery
*/

taskName = "3. Student table";

function Main(bufferElement) {
    var container = $(_GetDefaultContainer());

    /* ------------------------------------------------------------------------ */

    var students = [
        new Student("Peter", "Ivanov", 3),
        new Student("Milena", "Grigorova", 6),
        new Student("Gergana", "Borisova", 3),
        new Student("Boyko", "Petrov", 3)
    ];

    var studentProperties = ["First name", "Last name", "Grade"];

    $(container).append(generateTable(students, studentProperties));

    /* ------------------------------------------------------------------------ */

    var teachers = [
        new Teacher("Peter", "Ivanov", 35, "Math"),
        new Teacher("Milena", "Grigorova", 44, "Biology"),
        new Teacher("Gergana", "Borisova", 28, "Geography"),
        new Teacher("Boyko", "Petrov", 69, "History")
    ];

    var teacherProperties = ["First name", "Last name", "Age", "Specialty"];

    $(container).append(generateTable(teachers, teacherProperties));

    /* ------------------------------------------------------------------------ */
}

function generateTable(collection, properties) {
    var table = $('<table/>');
    var thead = $('<thead/>');
    var tbody = $('<tbody/>');

    // Generate table head
    var tr = $('<tr/>');

    for (var property in properties) {
        var th = $('<th/>').append(properties[property]);
        $(tr).append(th);
    }

    $(thead).append(tr);
    $(table).append(thead);

    // Generate table body
    for (var item in collection) {
        var tr = $('<tr/>');

        for (var property in collection[item]) {
            var td = $('<td/>').append(collection[item][property]);
            $(tr).append(td);
        }

        $(tbody).append(tr);
    }

    $(table).append(tbody);
    return table;
}

function Student(firstName, lastName, grade) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.grade = grade | 0;
    return this;
}

function Teacher(firstName, lastName, age, specialty) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age | 0;
    this.specialty = specialty;
    return this;
}