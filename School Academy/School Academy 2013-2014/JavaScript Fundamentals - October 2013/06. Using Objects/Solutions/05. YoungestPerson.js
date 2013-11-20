/*
 05. Write a function that finds the youngest person in
 a given array of persons and prints his/hers full name
 Each person have properties firstname, lastname and age, as shown:

 var persons = [
  {firstname : "Gosho", lastname: "Petrov", age: 32}, 
  {firstname : "Bay", lastname: "Ivan", age: 81},…];
*/

(function Solve () {
    
  var persons =
      [ { firstName: 'Gosho', lastName: 'Petrov', age: 32 },
        { firstName: 'Bay', lastName: 'Ivan', age: 81 } ];

  var youngest = persons.reduce(function(a, b) {
  	
            return a.age - b.age < 0 ? a : b;
        })

    console.log(youngest.firstName, youngest.lastName);
    
}).call(this);



