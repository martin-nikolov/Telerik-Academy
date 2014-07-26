$(function () {
    var applicationApiKey = 'Dg4tl9L6gfpeY1jdrPaTjoA0tAM';

    function renderTweets(data) {
        var ul = $('<ul/>'),
            template = $('#tweet-template').html(),
            options = {
                weekday: "long", year: "numeric", month: "short",
                day: "numeric", hour: "2-digit", minute: "2-digit"
            };

        for (var i = 0; i < data.length; i++) {
            var user = data[i].user,
                tweet = {
                    username: user.screen_name,
                    screen_name: '@' + user.screen_name,
                    name: user.name,
                    img_src: user.profile_image_url,
                    tweet_msg: data[i].text,
                    time_posted: new Date(data[i].created_at).toLocaleTimeString("en-us", options)
                },
                output = Mustache.render(template, tweet);

            ul.append(output);
        }

        $('#tweets-container').html(ul);
    }

    function getInputData() {
        var username = $('#twitter-username').val(),
            numberOfTweetsToTake = parseInt($('#msg-count').val());

        if (!username) {
            $('#twitter-username').css('box-shadow', 'red 0 0 4pt 1pt');
            return null;
        }
        else {
            $('#twitter-username').css('box-shadow', '');
        }

        numberOfTweetsToTake = numberOfTweetsToTake || 20;

        return {
            username: username,
            numberOfTweetsToTake: numberOfTweetsToTake
        }
    }

    function getAuthPromise() {
        OAuth.initialize(applicationApiKey);
        var authPromise = OAuth.popup('twitter', { cache: true });
        return authPromise;
    }

    $('#show-tweets-btn').on('click', function () {
        var data = getInputData();
        if (!data) {
            return;
        }

        requestUrl = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count='
                     + data.numberOfTweetsToTake + '&screen_name=' + data.username;

        getAuthPromise()
        .done(function (response) {
            response.get(requestUrl)
                    .done(function (data) {
                        renderTweets(data);              
                    });
        })
    });
});