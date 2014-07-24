(function() {
  require(['structures'], function(structures) {
    var bulgarianHeroesSection, greekHeroesSection, heroesContainer, superheroesSection;
    heroesContainer = structures.getContainer();

    superheroesSection = structures.getSection('Superheroes');
    heroesContainer.add(superheroesSection);
    superheroesSection.add(structures.getItem('Batman'));
    superheroesSection.add(structures.getItem('Ironman'));
    superheroesSection.add(structures.getItem('Superman'));
    superheroesSection.add(structures.getItem('Wonderwoman'));
    superheroesSection.add(structures.getItem('The Flash'));
    superheroesSection.add(structures.getItem('Spiderman'));
    superheroesSection.add(structures.getItem('Captain America'));
    superheroesSection.add(structures.getItem('The Hulk'));
    superheroesSection.add(structures.getItem('Green arrow'));
    superheroesSection.add(structures.getItem('Green Lantern'));

    greekHeroesSection = structures.getSection('Greek Heroes');
    heroesContainer.add(greekHeroesSection);
    greekHeroesSection.add(structures.getItem('Ajax'));
    greekHeroesSection.add(structures.getItem('Hercules'));
    greekHeroesSection.add(structures.getItem('Jason'));
    greekHeroesSection.add(structures.getItem('Perseus'));
    greekHeroesSection.add(structures.getItem('Odysseus'));

    bulgarianHeroesSection = structures.getSection('Bulgarian Heroes');
    heroesContainer.add(bulgarianHeroesSection);
    bulgarianHeroesSection.add(structures.getItem('Hristo Botev'));
    bulgarianHeroesSection.add(structures.getItem('Vasil Levski'));
    bulgarianHeroesSection.add(structures.getItem('Chavdar Vyivoda'));

    var result = JSON.stringify(heroesContainer.getData());
    var expected = JSON.stringify([{
      "title": "Superheroes",
      "items": [{
        "content": "Batman"
      }, {
        "content": "Ironman"
      }, {
        "content": "Superman"
      }, {
        "content": "Wonderwoman"
      }, {
        "content": "The Flash"
      }, {
        "content": "Spiderman"
      }, {
        "content": "Captain America"
      }, {
        "content": "The Hulk"
      }, {
        "content": "Green arrow"
      }, {
        "content": "Green Lantern"
      }]
    }, {
      "title": "Greek Heroes",
      "items": [{
        "content": "Ajax"
      }, {
        "content": "Hercules"
      }, {
        "content": "Jason"
      }, {
        "content": "Perseus"
      }, {
        "content": "Odysseus"
      }]
    }, {
      "title": "Bulgarian Heroes",
      "items": [{
        "content": "Hristo Botev"
      }, {
        "content": "Vasil Levski"
      }, {
        "content": "Chavdar Vyivoda"
      }]
    }]);

    console.log(result == expected);
  });


  /* Should produce:
  [{ "title": "Superheroes",
     "items": [{ "content": "Batman" }, 
               { "content": "Ironman" },
               { "content": "Superman" }, 
               { "content": "Wonderwoman" }, 
               { "content": "The Flash" }, 
               { "content": "Spiderman" }, 
               { "content": "Captain America" },
               { "content": "The Hulk" }, 
               { "content": "Green arrow" }, 
               { "content": "Green Lantern" }]
   }, 
   { "title": "Greek Heroes",
     "items": [{ "content": "Ajax" }, 
               { "content": "Hercules" }, 
               { "content": "Jason" }, 
               { "content": "Perseus" }, 
               { "content": "Odysseus" }]

   }, 
   { "title": "Bulgarian Heroes",
     "items": [{ "content": "Hristo Botev" }, 
               { "content": "Vasil Levski" }, 
               { "content": "Chavdar Vyivoda" }]
  }]
   */

}).call(this);

//# sourceMappingURL=app.map