define(['chai', 'controller', 'ui-controller'], function (chai, Controller, UI) {
    var assert = chai.assert,
        controller = Controller.getController(null),
        fakePosts = [{
                "id": 1,
                "title": "Lorem ipsum",
                "body": "Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem",
                "postDate": "2014-07-28T05:05:33.853Z",
                "user": {
                    "id": 1,
                    "username": "Minkov"
                }
            }, {
                "id": 2,
                "title": "Ipsum #2",
                "body": "Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem",
                "postDate": "2014-07-28T05:06:04.410Z",
                "user": {
                        "id": 2,
                        "username": "Yoda"
                    }
            }, {
                "id": 3,
                "title": "Again Ipsum",
                "body": "Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem",
                "postDate": "2014-07-28T05:06:15.090Z",
                "user": {
                        "id": 1,
                        "username": "Minkov"
                    }
            }
        ];

    describe('# Test the paging behavior', function () {
        describe('Without posts', function () {
            it('with null array', function () {
                var html = UI.drawPosts(fakePosts, 25, 1)
                console.log(html)
                assert.equal(html, '<fieldset class="post-entry"><legend><strong>Title: </strong><span class="post-title">Lorem ipsum</span></legend><div class="post-body"><strong>Content: </strong><span class="post-content">Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem</span></div><div class="post-date"><strong>Posted on: </strong><span class="posted-on">2014-07-28T05:05:33.853Z</span></div><div class="post-by"><strong>Posted by: </strong><span class="posted-by">Minkov</span></div></fieldset><fieldset class="post-entry"><legend><strong>Title: </strong><span class="post-title">Ipsum #2</span></legend><div class="post-body"><strong>Content: </strong><span class="post-content">Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem</span></div><div class="post-date"><strong>Posted on: </strong><span class="posted-on">2014-07-28T05:06:04.410Z</span></div><div class="post-by"><strong>Posted by: </strong><span class="posted-by">Yoda</span></div></fieldset><fieldset class="post-entry"><legend><strong>Title: </strong><span class="post-title">Again Ipsum</span></legend><div class="post-body"><strong>Content: </strong><span class="post-content">Lorem ipsum, lorem ipsum, and again lorem, lorem, loreeeeeeem</span></div><div class="post-date"><strong>Posted on: </strong><span class="posted-on">2014-07-28T05:06:15.090Z</span></div><div class="post-by"><strong>Posted by: </strong><span class="posted-by">Minkov</span></div></fieldset>');
            })

            it('with empty array', function () {
                var sortedArray = controller.sortPosts([]);
                assert.equal([].length, sortedArray.length);
            })
        })

        describe('With posts', function () {
            it('with fake posts - posts on page', function () {
                var sortedArray = controller.sortPosts(fakePosts.slice(0));
                assert.equal(fakePosts.length, sortedArray.length);
                assert.equal(fakePosts[0].id, sortedArray[0].id);
                assert.equal(fakePosts[fakePosts.length - 1].id, sortedArray[fakePosts.length - 1].id);
            })

            it('with fake posts - page number', function () {
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
    });
});