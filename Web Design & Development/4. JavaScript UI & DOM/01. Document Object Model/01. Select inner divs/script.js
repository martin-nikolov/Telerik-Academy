/*
    1. Write a script that selects all the div nodes that are directly inside other div elements
        - Create a function using querySelectorAll()
        - Create a function using getElementsByTagName()
*/

taskName = "1. Select inner divs";

function Main(bufferElement) {
    showNumberOfAllDivsInPage();

    selectInnerDivsUsingLiveNode(); // Using getElementsByTagName()
    selectInnerDivsUsingStaticNode(); // Using querySelectorAll()
}

function showNumberOfAllDivsInPage() {
    var allDivs = document.getElementsByTagName('div');
    var numberOfInnerDivs = 0;

    WriteLine('Number of all divs in page: ' + allDivs.length);
    WriteLine();
}

function selectInnerDivsUsingLiveNode() {
    var innerDivs = document.getElementsByTagName('div');
    var numberOfInnerDivs = 0;

    for (var i = 0, len = innerDivs.length; i < len; i++) {
        if (innerDivs[i].parentNode instanceof HTMLDivElement) {
            WriteLine(innerDivs[i]);
            numberOfInnerDivs++;
        }
    }

    WriteLine(" - Live node -> number of inner divs: " + numberOfInnerDivs);
    WriteLine();
}

function selectInnerDivsUsingStaticNode() {
    var innerDivs = document.querySelectorAll('div > div');

    for (var i = 0; i < innerDivs.length; i++) {
        WriteLine(innerDivs[i]);
    }

    WriteLine(" - Static node -> number of inner divs: " + innerDivs.length);
}