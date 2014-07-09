define(function(require) {

    // Constructor
    function SchoolClass(nameOfClass, capacity, setOfStudents, formTeacher) {
        this.nameOfClass = nameOfClass;
        this.capacity = capacity || 0;
        this.setOfStudents = (Array.isArray(setOfStudents) ? setOfStudents : [])
        this.formTeacher = formTeacher; 
    }

    SchoolClass.prototype.toString = function() {
        var result = "School Class: ";

        result += "Name: " + this.nameOfClass;
        result += ", Capacity: " + this.capacity;
        result += ", Students: ";

        for (var i = 0; i < this.setOfStudents.length; i++) {
            result += '{ ' + this.setOfStudents[i].introduce(true) + ' }, ';
        }

        if (this.formTeacher) {
            result += "Form-Teacher: { " + this.formTeacher.introduce(true) + " }";
        }

        return result;
    }

    return SchoolClass;
})