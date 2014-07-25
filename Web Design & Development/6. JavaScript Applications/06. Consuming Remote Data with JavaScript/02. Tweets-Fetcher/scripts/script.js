(function () {
    var widgetId = '492726091031666688',
        tweetsContainerId = 'tweets-container',
        numberOfTweetsToTake = 100,
        useLinks = true,
        showProfilePicture = true,
        showDateOnPosted = true;

    twitterFetcher.fetch(widgetId, tweetsContainerId, numberOfTweetsToTake,
                         useLinks, showProfilePicture, showDateOnPosted);
})();