/*
 06. Write a function that groups an array of persons
 by age, first or last name. The function must return
 an associative array, with keys - the groups, and 
 values -arrays with persons in this groups
 Use function overloading (i.e. just one function)

 var persons = {…};
 var groupedByFname = group(persons,"firstname");
 var groupedByAge= group(persons,"age");
*/

 function Join(persons, prop) {

  var result = {};

  persons.forEach(function(person) {

    var value = person[prop];

    result[value] = result[value] || [];

    result[value].push(person) ;
  });

    return result;
}

 

(function Solve () {
    
 var persons =
    [ { firstName: 'Gosho', lastName: 'Petrov', age: 40 },
      { firstName: 'Gosho', lastName: 'Ivan', age: 30 },
      { firstName: 'Bay', lastName: 'Ivan', age: 40 },
      { firstName: 'Bay', lastName: 'Ivan', age: 30 } ];

  var prop;

  for (prop in persons[0])
      console.log(Join(persons, prop));
    
}).call(this);



