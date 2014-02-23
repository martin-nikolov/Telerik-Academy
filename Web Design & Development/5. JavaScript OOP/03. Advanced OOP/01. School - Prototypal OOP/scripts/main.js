define(function(require) {

    /* ------------------------------------------------------------------------ */

    // Include classes
    var Human = require('scripts/Classes/Human.js');
    var Student = require('scripts/Classes/Student.js');
    var Teacher = require('scripts/Classes/Teacher.js');

    var School = require('scripts/Classes/School.js');
    var SchoolClass = require('scripts/Classes/SchoolClass.js');

    /* ------------------------------------------------------------------------ */

    var human = Object.create(Human);
    human.init("Ivan", "Atanasov", 18);
    WriteLine(human.introduce());
    WriteLine();

    /* ------------------------------------------------------------------------ */
   
    var student = Object.create(Student);
    student.init("Miroslav", "Borisov", 14, 8);
    WriteLine(student.introduce());
    WriteLine();    

    /* ------------------------------------------------------------------------ */

    var teacher = Object.create(Teacher);
    teacher.init("Aleksandra", "Mincheva", 30, "Math");
    WriteLine(teacher.introduce());
    
    /* ------------------------------------------------------------------------ */

    WriteLine();
    WriteLine("/* ------------------------------------------------------------ */");
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var schoolClass = (function() {
        var students = [
            Object.create(Student).init("Peter", "Petrov", 17, 11),
            Object.create(Student).init("Gergana", "Georgieva", 18, 11),
            Object.create(Student).init("George", "Petrov", 17, 11),
            Object.create(Student).init("Cvetelina", "Ivanova", 18, 11)
        ];

        var teacher = Object.create(Teacher).init("Veselin", "Borisov", 42, "Biology");

        return Object.create(SchoolClass).init("XI", 4, students, teacher);
    }());

    WriteLine(schoolClass.toString());
    WriteLine();
    
    WriteLine("Students in " + schoolClass.nameOfClass + " class: ");

    for (var i = 0; i < schoolClass.setOfStudents.length; i++) {
        WriteLine("- " + schoolClass.setOfStudents[i].introduce(true));
    }

    WriteLine();
    WriteLine("Form-Teacher of " + schoolClass.nameOfClass + " class: " + schoolClass.formTeacher.introduce(true));

    /* ------------------------------------------------------------------------ */

    WriteLine();
    WriteLine("/* ------------------------------------------------------------ */");
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var schoolClass1 = Object.create(SchoolClass);
    schoolClass1.init("II", 26, [student, student], teacher);

    var school = Object.create(School);
    school.init("Kliment Ohridski", [schoolClass1]);
    school.addSchoolClass(schoolClass);

    WriteLine("School : " + school.nameOfSchool);

    for (var i = 0; i < school.setOfClasses.length; i++) {
        WriteLine("- " + school.setOfClasses[i].toString());
    }

    /* ------------------------------------------------------------------------ */
})