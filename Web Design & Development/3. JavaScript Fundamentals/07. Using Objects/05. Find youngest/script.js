/*
    5. Write a function that finds the youngest person in a 
    given array of persons and prints his/hers full name
    Each person have properties firstname, lastname and age.
*/

taskName = "5. Find youngest";

function Main(bufferElement) {

    var persons =
    [ 
        Person("Gosho", "Petrov", 32),
        Person("John", "Junior", 17),
        Person("Bay", "Ivan", 81),
        Person("Georgi", "Georgiev", 23),
        Person("Peter", "Petrov", 25)
    ];

    for (var i = 0; i < persons.length; i++)
        WriteLine(persons[i]);

    WriteLine();
    WriteLine("Youngest person: " + findYoungestPerson(persons));
}

// PERSON CONSTRUCTOR

function Person(firstName, lastName, age) {
    if (!(this instanceof Person)) {
        return new Person(firstName, lastName, age);
    }

    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

// PERSON PROTOTYPE

Person.prototype.toString = function() {
    return this.firstName + " " + this.lastName + ", " + this.age;
};

function findYoungestPerson(persons) {
    var youngest = persons.reduce(function(a, b) {
        return (a.age < b.age) ? a : b;
    });

    return youngest;
}