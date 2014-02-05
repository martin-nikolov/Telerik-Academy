/*
    9. Write a function for extracting all email addresses
    from given text. All substrings that match the format
    <identifier>@<host>…<domain> should be recognized as 
    emails. Return the emails as array of strings.
*/

taskName = "9. Extract all valid emails";

function Main(bufferElement) {

    var text = '(+001 222 222 222), example@gmail.com, test.user@yahoo.co.uk, test@test, @gmail.com, a@a.b, valid@email.com, "just message" <rfernsdfson@gmal.com>, <admin@truformdftechnoproducts.com>, <manager@ysahoo.in>';

    var validEmails = extractValidEmails(text);

    for (email in validEmails) {
        WriteLine(validEmails[email])
    }
}

function extractValidEmails(text) {
    var pattern = /(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))/g;

    var validEmails = text.match(pattern);

    return validEmails;
}