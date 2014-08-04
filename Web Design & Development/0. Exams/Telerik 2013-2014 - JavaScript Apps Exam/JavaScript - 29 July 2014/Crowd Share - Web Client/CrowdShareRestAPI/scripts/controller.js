define(['ui-controller', 'q', 'validation-controller', 'underscore'], function (UI, Q, ValidationController, _) {
    var Controller = (function () {
        var DEFAULT_POSTS_ON_PAGE = 5;

        function BaseController(dataPersister) {
            this.persister = dataPersister;         
        }

        BaseController.prototype = {
            loadUI: function() {
                if (this.persister.isLoggedIn()) {
                    this.drawLoggedInForm();
                }
                else {
                    this.drawLogInForm();
                }

                this.getNumberOfPostsForPage();
                this.drawPosts();
                this.setEventHandlers(this.persister);
            },
            drawLogInForm: function () {
                var loginHtml = UI.drawLogInForm();
                $('#login-container').html(loginHtml);
            },
            drawLoggedInForm: function() {
                var loggedInFormHtml = UI.drawLoggedInForm(),
                    drawCreatePostFormHtml = UI.drawCreatePostForm();

                $('#login-container').html(loggedInFormHtml);
                $('#create-post-container').html(drawCreatePostFormHtml);
            },
            drawPosts: function () {
                var postsOnPageCount = this.getNumberOfPostsForPage(),
                    pageNumber = this.getCurrentPageNumber(),
                    sortOptions = this.getSortOptions();
                _this = this;

                this.persister.post.getPosts()
                    .then(function (response) {
                        var posts = _this.sortPosts(response, sortOptions);
                        var postsHtml = UI.drawPosts(posts, postsOnPageCount, pageNumber);
                        $('#posts').html(postsHtml);
                    })
            },
            sortPosts: function (posts, sortOptions) {
                if (!sortOptions || sortOptions.criteria == "" || sortOptions.order == "") {
                    return posts;
                }
                
                posts.sort(function (a, b) {
                    if (sortOptions.criteria === 'title') {
                        var firstTitle = a.title.toLowerCase(),
                            secondTitle = b.title.toLowerCase();

                        if (firstTitle < secondTitle) return -1;
                        if (firstTitle > secondTitle) return 1;
                        else return 0;
                    }
                    else if (sortOptions.criteria === 'date') {
                        if (a.postDate < b.postDate) return -1;
                        if (a.postDate > b.postDate) return 1;
                        else return 0;
                    }
                });

                if (sortOptions.order === 'desc') {
                    posts.reverse();
                }

                return posts;
            },
            getNumberOfPostsForPage: function() {
                var postsCount = 0,
                    postsCountFromSessionStorage = sessionStorage.getItem('posts-count');
                
                postsCount = postsCountFromSessionStorage || (($('#posts-count') | 0) || DEFAULT_POSTS_ON_PAGE);
                this.setNumberOfPostsForPage(postsCount);

                return postsCount;
            },
            setNumberOfPostsForPage: function (postsCount) {
                var number = parseInt(postsCount);
                if (!isNaN(number) && number >= 0) {
                    sessionStorage.setItem('posts-count', postsCount);
                    return true;
                }

                return false;
            },
            getCurrentPageNumber: function() {
                var pageNumber = 0,
                    postsCountFromSessionStorage = sessionStorage.getItem('posts-page');

                pageNumber = postsCountFromSessionStorage || 1;
                this.setCurrentPageNumber(pageNumber);

                return pageNumber;
            },
            setCurrentPageNumber: function (pageNumber) {
                if ((pageNumber | 0) > 0) {
                    sessionStorage.setItem('posts-page', pageNumber);
                }
            },
            getSortOptions: function() {
                var criteria = $('#sort-criteria').find(":selected").val(),
                    order = $('#sort-order').find(":selected").val();
                    
                if (!criteria && order) {
                    order = "";
                }
                else if (criteria && !order) {
                    order = "asc";
                }

                var sortOptions = {
                    criteria: criteria,
                    order: order
                };
                return sortOptions;
            },
            setEventHandlers: function() {
                var _this = this;

                // Send register request
                $('#wrapper').on('click', '#button-register', function () {
                    var username = $('#register-user-nickname').val(),
                        password = $('#register-user-password').val(),
                        passwordRe = $('#register-user-password-re').val();

                    var isUsernameValid = ValidationController.isUsernameCorrect(username),
                        isPasswordValid = ValidationController.isPasswordCorrect(password),
                        isPasswordsEqual = password === passwordRe;

                    if (isUsernameValid && isPasswordValid && isPasswordsEqual) {
                        UI.clearErrorMessage();

                        _this.persister.user.register(username, password)
                             .then(function () {
                                 console.log('registered');
                             }, function (error) {
                                 UI.showAppErrorMessage(JSON.parse(error.responseText).message);
                             })
                        $('#login-container').html(UI.drawLogInForm());
                    }
                    else {
                        UI.showAppErrorMessage('Invalid username or password!');
                    }
                });

                // Log in
                $('#wrapper').on('click', '#button-log-in', function () {
                    var username = $('#login-user-nickname').val(),
                        password = $('#login-user-password').val();

                    var isUsernameValid = ValidationController.isUsernameCorrect(username),
                        isPasswordValid = ValidationController.isPasswordCorrect(password);

                    if (isUsernameValid && isPasswordValid) {
                        UI.clearErrorMessage();

                        _this.persister.user.login(username, password)
                             .then(function (response) {
                                 if (_this.persister.isLoggedIn()) {
                                     _this.drawLoggedInForm();
                                     _this.drawPosts();
                                 }
                             }, function (error) {
                                 UI.showAppErrorMessage(JSON.parse(error.responseText).message);
                             });
                    }
                    else {
                        UI.showAppErrorMessage('Invalid username or password!');
                    }
                });

                // Logout
                $('#wrapper').on('click', '#user-loged-in #button-logout', function () {
                    $('#login-container').empty();
                    $('#create-post-container').empty();
                    UI.clearErrorMessage();

                    _this.persister.user.logout()
                         .then(function () {
                             $('#login-container').html(UI.drawLogInForm());
                         });
                });
                
                // Register now
                $('#wrapper').on('click', '#register-now', function () {
                    UI.clearErrorMessage();
                    $('#login-container').html(UI.drawRegisterForm());
                });

                // Register back
                $('#wrapper').on('click', '#back-to-homepage', function () {
                    UI.clearErrorMessage();
                    $('#login-container').html(UI.drawLogInForm());
                });
             
                // Create new post request
                $('#wrapper').on('click', '#create-post-btn', function () {
                    var postTitle = $('#post-title-input').val(),
                        postContent = $('#post-body-input').val();

                    // TODO: Validation

                    var postData = {
                        title: postTitle,
                        body: postContent
                    };

                    _this.persister.post.create(postData)
                         .then(function () {
                             UI.showAppSuccessMessage('Post created successfully.');
                             $('#post-title-input').val('');
                             $('#post-body-input').val('');
                             _this.drawPosts();
                         }, function (error) {
                             UI.showAppErrorMessage(JSON.parse(error.responseText).message);
                         })
                });

                // Posts on page label
                $('#posts-page').text(_this.getCurrentPageNumber());

                // Posts on page input
                $('#posts-count').val(sessionStorage.getItem('posts-count'));
                $('#posts-count').on('input', function (e) {
                    var inputObj = $(e.target),
                        isValidNumber = _this.setNumberOfPostsForPage(inputObj.val());

                    if (isValidNumber) {
                        _this.drawPosts();
                    }
                });

                // Next page
                $('#wrapper').on('click', '#next-page-btn', function () {
                    var currentPageNumber = _this.getCurrentPageNumber() | 0;
                    currentPageNumber += 1;
                    _this.setCurrentPageNumber(currentPageNumber);
                    $('#posts-page').text(_this.getCurrentPageNumber());
                    _this.drawPosts();
                });

                // Previous page
                $('#wrapper').on('click', '#prev-page-btn', function () {
                    var currentPageNumber = _this.getCurrentPageNumber() | 0;
                    currentPageNumber -= 1;
                    _this.setCurrentPageNumber(currentPageNumber);
                    $('#posts-page').text(_this.getCurrentPageNumber());
                    _this.drawPosts();
                });

                // Sorting
                $('#wrapper').on('click', '#sort-btn', function () {
                    _this.drawPosts();
                });
            }
        }

        return {
            getController: function (persister) {
                return new BaseController(persister);
            }
        }
    }());

    return Controller;
})