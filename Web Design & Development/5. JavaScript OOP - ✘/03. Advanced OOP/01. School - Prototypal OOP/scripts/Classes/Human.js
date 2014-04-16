define(function(require) {

    var Human = {
        init: function(firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age || 0;

            return this;
        },
        introduce: function() {
            var result = "Name: " + this.firstName + " " + this.lastName + ", " +
                          "Age: " + this.age;

            return result;
        }
    };

    return Human;
})