taskName = "3. Application for managing students";

function Main(bufferElement) {
    var apiKey = '95kmJDN7rCOytUwQ',
        url = 'https://api.everlive.com/v1/' + apiKey;

    var persister = DataPersister.getPersister(url);

    addStudent(persister);
    getAllStudents(persister);
    deleteStudentById(persister);
}

function addStudent(persister) {
    var student = {
        FirstName: 'John',
        LastName: 'Snow',
        Age: '25'
    };

    persister.students.create(student)
        .then(function() {
            WriteLine('- Student added successfully.');
            WriteLine();
        }, function() {
            WriteLine('- Error! Cannot add student to the database.');
            WriteLine();
        });
}

function getAllStudents(persister) {
    persister.students.getAll()
        .then(function(data) {
            WriteLine('Total number of students: ' + data.Count);

            _.each(data.Result, function(student) {
                WriteLine(Format('Student: {0} {1}, {2}',
                    student.FirstName, student.LastName, student.Age));
            });

            WriteLine();
        });
}

function deleteStudentById(persister) {
    persister.students.getAll()
        .then(function(data) {
            WriteLine('Count before deletion: ' + data.Count);
            return data;
        })
        .then(function(data) {
            var firstStudent = _.first(data.Result);
            if (firstStudent) {
                var studentId = firstStudent.Id;
                persister.students.deleteById(studentId)
                    .then(function() {
                        WriteLine('- Student delete successfully.');
                    }, function() {
                        WriteLine('- Error! Cannot deleted student from the database.');
                    })
                    .then(function() {
                        persister.students.getAll()
                            .then(function(data) {
                                WriteLine('Count after deletion: ' + data.Count);
                                WriteLine();
                            });
                    });
            }
        });
}