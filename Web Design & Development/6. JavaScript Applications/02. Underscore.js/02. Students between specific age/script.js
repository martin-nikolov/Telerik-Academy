/*
    2. Write function that finds the first name and
    last name of all students with age between 18 and 24.
    Use Underscore.js
*/

taskName = "2. Students with age between 18 and 24";

function Main() {
    var studentsCount = 10;
    var randomStudents = School.StudentsGenerator.randomStudents(studentsCount);
    WriteLine('-- All students --');
    printStudents(randomStudents);

    WriteLine();

    var minAge = 18,
        maxAge = 24,
        studentsBetweenAge = getStudentsBetweenAge(randomStudents, minAge, maxAge);
    WriteLine(Format('-- Students with age between {0} and {1} --', minAge, maxAge));
    printStudents(studentsBetweenAge);
}

function getStudentsBetweenAge(students, minAge, maxAge) {
    var studentsBetweenAge = _.filter(students, function(student) {
        return student.age >= minAge && student.age <= maxAge;
    });
    return studentsBetweenAge;
}

function printStudents(students) {
    _.each(students, function(student) {
        WriteLine(student.fullName() + ' - ' + student.age);
    });
}