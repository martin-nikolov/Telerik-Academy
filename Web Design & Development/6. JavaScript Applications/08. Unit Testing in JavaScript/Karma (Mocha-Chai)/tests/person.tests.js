(function() {
    describe('#person', function() {
        describe('when initializing', function() {
            it('with valid names, expect ok', function() {
                var person = new Person('Peter', 'Petrov');
                expect(person.firstname()).to.equal('Peter');
                expect(person.lastname()).to.equal('Petrov');
            });
        });
    });
}());