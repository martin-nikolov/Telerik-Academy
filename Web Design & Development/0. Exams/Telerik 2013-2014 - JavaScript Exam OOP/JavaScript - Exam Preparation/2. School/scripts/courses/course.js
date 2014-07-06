define(['courses/student'], function(Student) {
    'use strict';

    var Course = (function() {
        function Course(title, scoreFormulaFunction) {
            this.title = title;
            this.students = [];
            this._scoreFormula = scoreFormulaFunction;
            this._calculatedResults = null;
            return this;
        }

        Course.prototype.addStudent = function(student) {
            if (!(student instanceof Student)) {
                throw new Error("Object 'student' is not instance of Student.");
            }

            this.students.push(student);
            // this._calculatedResults = null;
        }

        Course.prototype.calculateResults = function() {
            var i, len, student;
            this._calculatedResults = [];

            for (i = 0, len = this.students.length; i < len; i++) {
                student = this.students[i];

                var studentResults = {
                    student: student,
                    exam: student.exam, // for easier testing
                    totalScore: this._scoreFormula(student)
                };

                this._calculatedResults.push(studentResults);
            }
        };

        Course.prototype.getTopStudentsByExam = function(count) {
            var students = getStudentsByComparer.call(this, count, byExamComparer);
            return students;
        };

        Course.prototype.getTopStudentsByTotalScore = function(count) {
            var students = getStudentsByComparer.call(this, count, byTotalScoreComparer);
            return students;
        };

        function getStudentsByComparer(count, comparer) {
            if (this._calculatedResults == null) {
                throw new Error("Must call calculateResults() first.");
            }

            count = count || this._calculatedResults.length;

            var students = this._calculatedResults
                               .slice(0)
                               .sort(comparer)
                               .slice(0, count);
            return students;
        }

        function byExamComparer(st1, st2) {
            return st2.student.exam - st1.student.exam;
        }

        function byTotalScoreComparer(st1, st2) {
            return st2.totalScore - st1.totalScore;
        }

        return Course;
    }());

    return Course;
})