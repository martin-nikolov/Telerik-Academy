/*
    Task: Fake Text Markup Language
    http://bgcoder.com/Contests/55/CSharp-Part-2-2012-2013-11-Feb-2013
*/

var args = [
    '2',
    "So<rev><upper>saw</upper> txet em</rev>",
    "<lower><upper>here</upper></lower>",
];

var args2 = [
    '3',
    '<toggle><rev>ERa</rev></toggle> you',
    '<rev>noc</rev><lower>FUSED</lower>',
    '<rev>?<rev>already </rev></rev>'
];

console.log(Solve(args));

function Solve(args) {
    args.shift(); // number of rows
    var text = args.join('\n');
    var regex = new RegExp('(<\\w+>)([^>]*)(<\/\\w+>)', 'gi');

    var functions = {
        upper: function(content) { return content.toUpperCase(); },
        lower: function(content) { return content.toLowerCase(); },
        del: function() { return ""; },
        rev: function(content) { return content.split('').reverse().join(''); },
        toggle: function(content) {
            var toggled = "";
            for (var i = 0; i < content.length; i++) {
                toggled += functions[(content[i] >= 'a' && content[i] <= 'z') ? "upper" : "lower"](content[i]);
            }
            return toggled;
        }
    };
    
    function replacer(string, openTag, content) {
        var functionName = openTag.substr(1, openTag.length - 2);
        return functions[functionName](content);
    }

    while (text.match(regex)) {
        text = text.replace(regex, replacer);
    }

    return text;
}