/*
    6. Write a function that extracts the content of a html
    page given as text. The function should return anything 
    that is in a tag, without the tags:

    Example: <html><head><title>Sample site</title></head><body>
    <div>text<div>more text</div>and more...</div>in body</body></html>

    Result: Sample sitetextmore textand more...in body
*/

taskName = "6. Extract content";

function Main(bufferElement) {

    var input = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>;";

    var result = input.replace(/<(.*?)>/g, '');

    WriteLine(input);
    WriteLine();
    WriteLine(result);
}