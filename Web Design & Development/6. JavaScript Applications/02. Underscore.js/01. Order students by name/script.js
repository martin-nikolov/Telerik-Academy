/*
    1. Write a method that from a given array of students
    finds all students whose first name is before its last
    name alphabetically.
    Print the students in descending order by full name.
    Use Underscore.js
*/

taskName = "1. Order students by name";

function Main() {
    var studentsCount = 10;
    var randomStudents = School.StudentsGenerator.randomStudents(studentsCount);
    WriteLine('-- All students --');
    printStudents(randomStudents);

    WriteLine();

    var studentsWhoseFirstNameBeforeLastName = getStudentsFirstNameBeforeLastName(randomStudents);
    var sortedStudents = sortByFullName(studentsWhoseFirstNameBeforeLastName);
    WriteLine('-- Students whose first name is before its last name --');
    printStudents(sortedStudents);
}

/// <summary>
/// Finds all students whose first name is before its last name alphabetically
/// </summary>
function getStudentsFirstNameBeforeLastName(students) {
    var studentsWhoseFirstNameBeforeLastName = _.filter(students, function(student) {
        return student.firstName.toLowerCase() < student.lastName.toLowerCase();
    });
    return studentsWhoseFirstNameBeforeLastName;
}

function sortByFullName(students) {
    var sortedStudents = _.sortBy(students, function(student) {
            return student.fullName().toLowerCase();
        })
        .reverse();
    return sortedStudents;
}

function printStudents(students) {
    _.each(students, function(student) {
        WriteLine(student.fullName());
    });
}