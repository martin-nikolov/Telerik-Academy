/*
    3. Write a function that by a given array of students
    finds the student with highest marks
*/

taskName = "3. Students with highest marks";

function Main() {
    SetConsoleSize(500);

    var studentsCount = 20;
    var randomStudents = School.StudentsGenerator.randomStudents(studentsCount);
    WriteLine('-- All students --');
    printStudents(randomStudents);

    WriteLine();

    var studentsWithHighestMarks = getStudentsWithHighestMarks(randomStudents);
    WriteLine('-- Students with highest marks --');
    printStudents(studentsWithHighestMarks);
}

/// <summary>
/// Get all students with highest average mark
/// </summary>
function getStudentsWithHighestMarks(students) {
    var studentWithHighestMarks = [],
        highestAverageMark = 0;

    _.each(students, function(student) {
        var studentAverageMark = getAverageMark(student.marks);

        if (studentAverageMark > highestAverageMark) {
            studentWithHighestMarks = [];
            highestAverageMark = studentAverageMark;
        }

        if (studentAverageMark === highestAverageMark) {
            studentWithHighestMarks.push(student);
        }
    });

    return studentWithHighestMarks;
}

function getAverageMark(marks) {
    var averageMark = _.reduce(marks, function(sum, n) {
        return sum += n;
    });
    averageMark /= marks.length;
    return averageMark;
}

function printStudents(students) {
    _.each(students, function(student) {
        WriteLine(student.fullName() + ' [' + student.marks.join(', ') + ']');
    });
}