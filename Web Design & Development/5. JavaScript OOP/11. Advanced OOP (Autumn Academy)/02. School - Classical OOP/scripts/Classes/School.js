define(function(require) {

    // Constructor
    function School(nameOfSchool, setOfClasses) {
        this.nameOfSchool = nameOfSchool;
        this.setOfClasses = Array.isArray(setOfClasses) ? setOfClasses : [];
    }

    School.prototype.addSchoolClass = function(schoolClass) {
        this.setOfClasses.push(schoolClass);
    }

    School.prototype.toString = function() {
        var result = 'School "' + this.nameOfSchool + '": ';

        for (var i = 0; i < this.setOfClasses.length; i++) {
            result += this.setOfClasses[i].toString() + ", ";
        }

        return this.setOfClasses.length > 0 ? result.substr(0, result.length - 2) : result;
    }

    return School;
})