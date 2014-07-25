define(function() {
    var UI = (function() {
        var div = document.createElement('div'),
            span = document.createElement('span'),
            strong = document.createElement('strong');
        div.className = 'msgln';
        div.appendChild(strong);
        div.appendChild(span);

        function buildMessage(postBy, postText) {
            if (postText.length > 50) {
                postText = postText.substr(0, 50) + '...';
            }

            strong.innerHTML = postBy + ": ";
            span.innerHTML = postText;
            return div.cloneNode(true);
        }

        function buildChatBox(data, skipMessagesCount) {
            var docFragment = document.createDocumentFragment();

            for (var i = data.length - 1; i > Math.max(data.length - skipMessagesCount, 0); i--) {
                var post = data[i],
                    postBy = post.by.trim(),
                    postText = post.text.trim();

                if (!postBy || !postText) {
                    continue;
                }

                var postHtml = buildMessage(postBy, postText);
                docFragment.appendChild(postHtml);
            }

            return docFragment;
        }

        return {
            buildMessage: buildMessage,
            buildChatBox: buildChatBox
        }
    }());

    return UI;
});