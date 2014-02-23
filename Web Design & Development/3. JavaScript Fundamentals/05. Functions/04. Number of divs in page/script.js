/*
    4. Write a function to count the number of divs on the web page
*/

taskName = "4. Number of divs in page";

function Main(bufferElement) {

    WriteLine("Number of <div> in 'document': " + getNumberOfHtmlElements(document, 'div'));
    WriteLine("Number of <button> in 'document': " + getNumberOfHtmlElements(document, 'button'));
    WriteLine("Number of <span> in 'document': " + getNumberOfHtmlElements(document, 'span'));
}

function getNumberOfHtmlElements(container, htmlElement) {
    return container.getElementsByTagName(htmlElement).length;
}