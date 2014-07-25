(function () {
    var widgetId = '345690956013633536',
        tweetsContainerId = 'tweets-container',
        numberOfTweetsToTake = 100,
        useLinks = true,
        showProfilePicture = true,
        showDateOnPosted = true;

    twitterFetcher.fetch(widgetId, tweetsContainerId, numberOfTweetsToTake,
                         useLinks, showProfilePicture, showDateOnPosted);
})();