/*
03. Write a JavaScript function that finds how many
times a substring is contained in a given text 
(perform case insensitive search).
Example: The target substring is "in". The text is as follows:

We are living in an yellow submarine. We don't have anything else.
Inside the submarine is very tight. So we are drinking 
all the day. We will move out of it in 5 days.

The result is: 9.
*/

function CountRepeatingSubstring(text, searchedWord) {

    var match = text.match(new RegExp(searchedWord, 'gi'));

    return match && match.length || 0;
}

(function Solve () {
    
  console.log(CountRepeatingSubstring('We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.', 'in'));
    
}).call(this);
