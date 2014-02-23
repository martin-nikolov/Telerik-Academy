/*
    8. Write a program that replaces in a HTML document given as string all 
    the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 

    Sample HTML fragment:
    ________________________________________________________________________________
    |<p>Please visit <a href="http://academy.telerik.com">our site</a>             |
    |to choose a training course. Also visit <a href="www.devbg.org">our forum</a> |
    |to discuss the courses.</p>                                                   |
    |______________________________________________________________________________|                                  
    ________________________________________________________________________________
    |<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a    |
    |training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the |
    |courses.</p>                                                                  |
    |______________________________________________________________________________|
*/

taskName = "8. Replace href with URL";

function Main(bufferElement) {

    var html = '<p>Please visit <A HREF="http://academy.telerik.com">our site</A> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

    var escapedHtml = replaceHrefWithUrlTag(html);

    WriteLine(html);
    WriteLine();
    WriteLine(escapedHtml);
}

function replaceHrefWithUrlTag(text) {
    var pattern = /<a href="(.*?)">(.*?)<\/a>/gi;

    var escapedText = text.replace(pattern, function(tag, url, message) {
        return Format("[URL={0}]{1}[\/URL]", url, message);
    });

    return escapedText;
}