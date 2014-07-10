/*
    4. Write a function that by a given array of animals,
    groups them by species and sorts them by number of legs.
*/

taskName = "4. Group and sort animals";

function Main(bufferElement) {
    SetConsoleSize(500);

    var animalsCount = 10;
    var animals = Zoo.AnimalsGenerator.getRandomAnimals(animalsCount);
    WriteLine('-- Random animals --');
    printAnimals(animals);

    WriteLine();

    var groupedBySpecies = groupAnimalsBySpecies(animals);
    WriteLine('-- Animals grouped by species --');
    printAnimals(groupedBySpecies);

    WriteLine();

    var sortedByNumOfLegs = sortAnimalsByNumOfLegs(animals);
    WriteLine('-- Animals sorted by number of legs --');
    printAnimals(sortedByNumOfLegs);
}

function groupAnimalsBySpecies(animals) {
    var groupedBySpecies = _.groupBy(animals, 'species');
    return groupedBySpecies;
}

function sortAnimalsByNumOfLegs(animals) {
    var sortedByNumOfLegs = _.sortBy(animals, 'numOfLegs');
    return sortedByNumOfLegs;
}

function printAnimals(animals) {
    _.each(animals, function(animal) {
        if (Array.isArray(animal)) {
            WriteLine(animal.join(', '));
        }
        else {
            WriteLine(animal.toString());
        }
    });
}