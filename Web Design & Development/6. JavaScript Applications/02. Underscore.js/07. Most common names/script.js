/*
    7. By an array of people find the most common
    first and last name. Use underscore.
*/

taskName = "7. Most common names";

function Main() {
    var studentsCount = 10;
    var randomStudents = School.StudentsGenerator.randomStudents(studentsCount);
    WriteLine('-- All students --');
    printStudents(randomStudents);

    WriteLine();

    var mostCommonFirstNames = findMostCommonBy(randomStudents, 'firstName');
    WriteLine(Format('Most common first name(s): {0} -> {1} time(s)',
        mostCommonFirstNames.props.join(', '), mostCommonFirstNames.count));

    var mostCommonLastNames = findMostCommonBy(randomStudents, 'lastName');
    WriteLine(Format('Most common last name(s): {0} -> {1} time(s)',
        mostCommonLastNames.props.join(', '), mostCommonLastNames.count));
}

function findMostCommonBy(collection, countBy) {
    var countByProp = _.countBy(collection, countBy);
    var mostCommonCount = _.max(countByProp);
    var mostCommonProps = [];

    _.each(countByProp, function(count, prop) {
        if (count == mostCommonCount) {
            mostCommonProps.push(prop);
        }
    });

    return {
        props: mostCommonProps,
        count: mostCommonCount
    };
}

function printStudents(students) {
    _.each(students, function(student) {
        WriteLine(student.fullName());
    });
}