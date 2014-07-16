/*
    5. By a given array of animals, find the total number of legs
    Each animal can have 2, 4, 6, 8 or 100 legs
*/

taskName = "5. Total number of legs";

function Main(bufferElement) {
    var animalsCount = 10;
    var animals = Zoo.AnimalsGenerator.getRandomAnimals(animalsCount);
    WriteLine('-- Random animals --');
    printAnimals(animals);

    WriteLine();

    var totalNumberOfLegs = findTotalNumberOfLegs(animals);
    WriteLine('Total number of legs: ' + totalNumberOfLegs);
}

function findTotalNumberOfLegs(animals) {
    var legs = _.pluck(animals, 'numOfLegs');
    var totalNumberOfLegs = _.reduce(legs, function(totalLegs, legs) {
        return totalLegs += legs;
    });
    return totalNumberOfLegs;
}

function printAnimals(animals) {
    _.each(animals, function(animal) {
        WriteLine(animal.toString());
    });
}