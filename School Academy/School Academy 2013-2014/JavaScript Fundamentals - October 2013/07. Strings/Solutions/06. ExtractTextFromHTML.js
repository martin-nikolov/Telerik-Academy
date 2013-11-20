/*
 06. Write a function that extracts the content of a html
 page given as text. The function should return anything 
 that is in a tag, without the tags:

 <html><head><title>Sample site</title></head><body>
 <div>text<div>more text</div>and more...</div>in body</body></html>

 result: Sample sitetextmore textand more...in body
*/

function ExtractText(html) {

    return html.replace(/<(.*?)>/g, '');
}


(function Solve () {
    
	console.log(ExtractText('<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>'));
    
}).call(this);