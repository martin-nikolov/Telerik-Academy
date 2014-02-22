define(function(require) {

    // Constructor
    function Human(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age || 0;
    }

    // Property for Object introducement
    Human.prototype.introduce = function(skipType) {
        var result = skipType ? "" : this.constructor.name + " - ";

        result += "Name: " + this.firstName + " " + this.lastName + ", " +
                  "Age: " + this.age;

        return result;
    }

    return Human;
})