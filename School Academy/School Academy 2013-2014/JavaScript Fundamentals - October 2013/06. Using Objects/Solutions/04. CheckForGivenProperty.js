/*
 04. Write a function that checks if a given 
 object contains a given property

 var obj  = …;
 var hasProp = hasProperty(obj,"length");
*/

function HasProperty(property, obj) {

    return obj.hasOwnProperty(property)
}

(function Solve () {
    
	  console.log(HasProperty('length', { length: undefined }))
    
}).call(this);

