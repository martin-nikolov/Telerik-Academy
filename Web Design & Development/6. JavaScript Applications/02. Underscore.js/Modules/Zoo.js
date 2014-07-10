var Zoo = (function() {
    'use strict';

    var Animal = (function() {
        function Animal(species, numOfLegs) {
            this.species = species;
            this.numOfLegs = numOfLegs;
            return this;
        }

        Animal.prototype.toString = function() {
            return this.species + ' - ' + this.numOfLegs + ' legs';
        };

        return Animal;
    }());

    var AnimalsGenerator = (function() {
        var animals = [
            new Animal('Blue Whale', 0),
            new Animal('Bluefin Tuna', 0),
            new Animal('Macaw', 2),
            new Animal('Kangaroo', 2),
            new Animal('Cross River Gorilla', 2),
            new Animal('Saola', 4),
            new Animal('Black Rhino', 4),
            new Animal('Amur Leopard', 4),
            new Animal('Asian Elephant', 4),
            new Animal('Hawksbill Turtle', 4),
            new Animal('Black Grass Spider', 6),
            new Animal('Dark Fishing Spider', 6),
            new Animal('Hobo Spider', 8),
            new Animal('Grass Spider', 8),
            new Animal('Woodlouse Hunter', 8),
            new Animal('Centipede', 100)
        ];

        function _getRandomAnimals(count) {
            count = count || animals.length;
            var randomAnimals = [];

            for (var i = 0; i < count; i++) {
                randomAnimals.push(animals[GetRandomInt(0, animals.length - 1)]);
            }

            return randomAnimals;
        }

        return {
            getRandomAnimals: _getRandomAnimals
        };
    }());

    return {
        Animal: Animal,
        AnimalsGenerator: AnimalsGenerator
    };
}());