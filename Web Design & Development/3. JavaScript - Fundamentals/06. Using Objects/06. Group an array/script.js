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

function Person(firstName, lastName, age) {
    if (!(this instanceof Person)) {
        return new Person(firstName, lastName, age);
    }

    this.toString = function() {
        return firstName + " " + lastName + " - " + age;
    }

    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

function group(array, property) {
    var groupedArray = [];

    for (var i in array) {
        var current = array[i][property];

        groupedArray[current] = groupedArray[current] || [];
        groupedArray[current].push(array[i]);
    }

    return groupedArray;
}

function printAppropiate(message, array) {
    WriteLine("------------[" + message + "]------------");

    for (property in array) {
        WriteLine("* Key: " + property);
        WriteLine("->  " + array[property].join('; '));
        WriteLine();
    }
}