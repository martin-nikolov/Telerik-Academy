(function(scope) {
	scope.Person = (function() {
		function Person(firstname, lastname) {
			this._fname = firstname;
			this._lname = lastname;
		}

		Person.prototype.firstname = function(newName) {
			if (newName) {
				this._fname = newName;
				return this;
			} else {
				return this._fname;
			}
		};
		Person.prototype.lastname = function(newName) {
			if (newName) {
				this._lname = newName;
				return this;
			} else {
				return this._lname;
			}
		};
		return Person;
	}());
}(window));