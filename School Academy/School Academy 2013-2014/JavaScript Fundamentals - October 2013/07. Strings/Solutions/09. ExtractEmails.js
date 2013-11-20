/*
 09. Write a function for extracting all email addresses
 from given text. All substrings that match the format
 <identifier>@<host>…<domain> should be recognized 
 as emails. Return the emails as array of strings.
*/

(function Solve () {
    
	var str = 'Please contact us by phone (+001 222 222 222) or by email at example@gmail.com or at test.user@yahoo.co.uk. This is not email: test@test. This also: @gmail.com. Neither this: a@a.b. End!';

 	var pattern = '([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)';

	console.log(str.match(pattern));
    
}).call(this);

