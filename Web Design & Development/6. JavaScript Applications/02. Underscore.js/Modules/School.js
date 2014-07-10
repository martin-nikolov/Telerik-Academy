var School = (function() {
    'use strict';

    var Student = (function() {
        function Student(firstName, lastName, age, marks) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.marks = marks;
            return this;
        }

        Student.prototype.fullName = function() {
            var fullName = this.firstName + " " + this.lastName;
            return fullName;
        };

        return Student;
    }());

    var StudentsGenerator = (function() {
        var firstNames = ['Ivan', 'Peter', 'Atanas', 'Georgi', 'Samuil', 'Martin', 'Stanislav', 'Kaloyan', 'Ivaylo', 'Nikolay'],
            lastNames = ['Kenov', 'Minkov', 'Kostov', 'Nakov', 'Nikolov', 'Stoyanov', 'Georgiev', 'Atanasov', 'Todorov', 'Ivanov'];

        function _randomStudents(count) {
            count = count || firstNames.length;
            var randomStudents = [],
                student = null,
                randomFirstName, randomLastName, randomAge, randomMarks, randomMarksCount;

            for (var i = 0; i < count; i++) {
                randomFirstName = firstNames[GetRandomInt(firstNames.length - 1)];
                randomLastName = lastNames[GetRandomInt(firstNames.length - 1)];
                randomAge = GetRandomInt(10, 30);

                randomMarks = [];
                randomMarksCount = GetRandomInt(3, 10);
                for (var j = 0; j < randomMarksCount; j++) {
                    randomMarks.push(GetRandomInt(2, 6));
                }

                student = new Student(randomFirstName, randomLastName, randomAge, randomMarks);
                randomStudents.push(student);
            }

            return randomStudents;
        }

        return {
            randomStudents: _randomStudents
        };
    }());

    return {
        Student: Student,
        StudentsGenerator: StudentsGenerator
    };
}());