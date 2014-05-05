/*
    7. Write a script that parses an URL address given in the format:

    - [protocol]://[server]/[resource]

    and extracts from it the [protocol], [server] and [resource] elements.
    Return the elements in a JSON object.
    For example from the URL http://www.devbg.org/forum/index.php the 
    following information should be extracted:

    - { protocol: "http", server: "www.devbg.org", resource: "/forum/index.php" }
*/

taskName = "7. Extract Url Address fragments";

function Main(bufferElement) {

    var urlAddress = "https://www.devbg.org/forum/index.php";

    var fragments = extractUrlFragments(urlAddress);

    // Convert to JSON object
    var jsonObject = JSON.stringify({
        protocol: fragments[1],
        server: fragments[2],
        resource: fragments[3]
    });
    
    WriteLine("JSON: " + jsonObject);

    // Parse JSON object to JS object
    var jsObject = JSON.parse(jsonObject);

    WriteLine();
    WriteLine("URL Address: " + urlAddress);
    WriteLine("[protocol] = " + jsObject.protocol);
    WriteLine("[server] = " + jsObject.server);
    WriteLine("[resource] = " + jsObject.resource);
}

function extractUrlFragments(urlAddress) {
    var pattern = /(.*):\/\/(.*?)(\/.*)/g;

    return pattern.exec(urlAddress);
}