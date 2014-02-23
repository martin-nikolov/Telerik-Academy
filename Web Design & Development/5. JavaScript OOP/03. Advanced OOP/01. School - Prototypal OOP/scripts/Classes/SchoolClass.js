define(function(require) {

    var SchoolClass = {
        init: function(nameOfClass, capacity, setOfStudents, formTeacher) {
            this.nameOfClass = nameOfClass;
            this.capacity = capacity || 0;
            this.setOfStudents = (Array.isArray(setOfStudents) ? setOfStudents : [])
            this.formTeacher = formTeacher; 

            return this;
        },
        toString: function() {
            var result = "School Class: ";

            result += "Name: " + this.nameOfClass;
            result += ", Capacity: " + this.capacity;
            result += ", Students: ";

            for (var i = 0; i < this.setOfStudents.length; i++) {
                result += '{ ' + this.setOfStudents[i].introduce() + ' }, ';
            }

            if (this.formTeacher) {
                result += "Form-Teacher: { " + this.formTeacher.introduce() + " }";
            }

            return result;
        }
    };

    return SchoolClass;
})