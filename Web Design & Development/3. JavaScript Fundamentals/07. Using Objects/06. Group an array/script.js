/*
    6. Write a function that groups an array of persons by age,
    first or last name. The function must return an associative
    array, with keys - the groups, and values -arrays with 
    persons in this groups
    - Use function overloading (i.e. just one function)
*/

taskName = "6. Group an array";

function Main(bufferElement) {

    var persons =
    [ 
        Person("Georgi", "Ivanov", 32),
        Person("Ivan", "Georgiev", 17),
        Person("Ivan", "Georgiev", 32),
        Person("Georgi", "Ivanov", 17),
    ];

    var groupedByFname = group(persons, "firstName");
    printAppropiate("BY FIRST NAME", groupedByFname);
    
    var groupedByLname = group(persons, "lastName");
    printAppropiate("BY LAST NAME", groupedByLname);

    var groupedByAge = group(persons, "age");
    printAppropiate("BY AGE", groupedByAge);
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

// PERSON PROTOTYPES

Person.prototype.toString = function() {
    return this.firstName + " " + this.lastName + " - " + this.age;
};

// FUNCTIONS

function group(persons, property) {
    var groupedArray = [];

    for (var i in persons) {
        var current = persons[i][property];

        groupedArray[current] = groupedArray[current] || []; // If not exists -> creates new array
        groupedArray[current].push(persons[i]); // Push the current person
    }

    return groupedArray;
}

function printAppropiate(message, persons) {
    WriteLine("------------[" + message + "]------------");

    for (var property in persons) {
        WriteLine("* Key: " + property);
        WriteLine("->  " + persons[property].join('; '));
        WriteLine();
    }
}