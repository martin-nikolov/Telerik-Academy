define(['chai', 'controller'], function (chai, Controller) {
    var assert = chai.assert,
        controller = Controller.getController(null),
        fakePosts = [{
                "id": 1,
                "title": "d",
                "postDate": "2014-07-28T05:05:33.853Z",
            }, {
                "id": 2,
                "title": "c",
                "postDate": "2014-07-28T05:06:04.410Z",
            }, {
                "id": 3,
                "title": "b",
                "postDate": "2014-07-28T05:06:15.090Z"    
            }, {
                "id": 4,
                "title": "C",
                "postDate": "2014-07-28T05:06:16.090Z"
            }, {
                "id": 5,
                "title": "a",
                "postDate": "2014-07-28T05:06:17.090Z"
            }, {
                "id": 6,
                "title": "A",
                "postDate": "2014-07-28T05:04:11.090Z"
            }
        ];

    describe('# Test the sort behavior', function () {
        describe('Without posts', function () {
            it('with null array', function () {
                var sortedArray = controller.sortPosts(null);
                assert.equal(null, sortedArray);
            })

            it('with empty array', function () {
                var sortedArray = controller.sortPosts([]);
                assert.equal([].length, sortedArray.length);
            })
        })
        
        describe('With posts', function () {
            it('with fake posts - no sorting', function () {
                var sortedArray = controller.sortPosts(fakePosts.slice(0));
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(fakePosts[0].id, sortedArray[0].id);
                assert.equal(fakePosts[fakePosts.length - 1].id, sortedArray[fakePosts.length - 1].id);
            })

            it('with fake posts - no sorting parameters', function () {
                var sortingCriteria = {
                    criteria: '',
                    order: ''
                },
                    sortedArray = controller.sortPosts(fakePosts.slice(0), sortingCriteria);
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(fakePosts[0].id, sortedArray[0].id);
                assert.equal(fakePosts[fakePosts.length - 1].id, sortedArray[fakePosts.length - 1].id);
            })
        })

        describe('Both by title and by date', function () {
            it('with fake posts - sorting by title ascending', function () {
                var sortingCriteria = {
                    criteria: 'title',
                    order: 'asc'
                },
                    sortedArray = controller.sortPosts(fakePosts.slice(0), sortingCriteria);
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(5, sortedArray[0].id);
                assert.equal(6, sortedArray[1].id);
                assert.equal(1, sortedArray[sortedArray.length - 1].id);
                assert.equal('b', sortedArray[2].title);
            })

            it('with fake posts - sorting by title descending', function () {
                var sortingCriteria = {
                    criteria: 'title',
                    order: 'desc'
                },
                    sortedArray = controller.sortPosts(fakePosts.slice(0), sortingCriteria);
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(1, sortedArray[0].id);
                assert.equal(5, sortedArray[sortedArray.length - 1].id);
                assert.equal(6, sortedArray[sortedArray.length - 2].id);
                assert.equal('b', sortedArray[3].title);
            })

            it('with fake posts - sorting by date ascending', function () {
                var sortingCriteria = {
                    criteria: 'date',
                    order: 'asc'
                },
                    sortedArray = controller.sortPosts(fakePosts.slice(0), sortingCriteria);
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(6, sortedArray[0].id);
                assert.equal(1, sortedArray[1].id);
                assert.equal(5, sortedArray[sortedArray.length - 1].id);
                assert.equal(4, sortedArray[sortedArray.length - 2].id);
                assert.equal('2014-07-28T05:06:15.090Z', sortedArray[3].postDate);
            })

            it('with fake posts - sorting by date ascending', function () {
                var sortingCriteria = {
                    criteria: 'date',
                    order: 'desc'
                },
                    sortedArray = controller.sortPosts(fakePosts.slice(0), sortingCriteria);
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(5, sortedArray[0].id);
                assert.equal(4, sortedArray[1].id);
                assert.equal(6, sortedArray[sortedArray.length - 1].id);
                assert.equal(1, sortedArray[sortedArray.length - 2].id);
                assert.equal('2014-07-28T05:06:15.090Z', sortedArray[2].postDate);
            })
        })
    });
});