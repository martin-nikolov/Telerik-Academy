var DataPersister = (function() {
    'use strict';

    var BasePersister = function(rootUrl) {
        this.rootUrl = rootUrl;
        this.students = new StudentPersister(rootUrl);
        return this;
    };

    var StudentPersister = function(rootUrl) {
        this.rootUrl = rootUrl + '/Students';
        return this;
    };

    StudentPersister.prototype = {
        create: function(student) {
            return HttpRequster.postJSON(this.rootUrl, student);
        },
        getAll: function() {
            return HttpRequster.getJSON(this.rootUrl);
        },
        deleteById: function(studentId) {
            return HttpRequster.deleteJSON(this.rootUrl + '/' + studentId);
        }
    };

    return {
        getPersister: function(rootUrl) {
            return new BasePersister(rootUrl);
        }
    };
}());