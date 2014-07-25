taskName = "1. Http-Requester";

function Main(bufferElement) {
    var apiKey = '95kmJDN7rCOytUwQ',
        url = 'https://api.everlive.com/v1/' + apiKey + '/Students';

    var student = {
        FirstName: 'John',
        LastName: 'Smith',
        Age: '20'
    };

    // Adds student to the database
    HttpRequster.postJSON(url, student)
        .then(function() {
            WriteLine('- Student added successfully.');
        }, function() {
            WriteLine('- Error! Cannot add student to the database.');
        });

    // Gets all students from the database
    HttpRequster.getJSON(url)
        .then(function(data) {
            WriteLine();
            WriteLine('Total number of students: ' + data.Count);

            _.each(data.Result, function(student) {
                WriteLine(Format('Student: {0} {1}, {2}',
                    student.FirstName, student.LastName, student.Age));
            });
        });
}