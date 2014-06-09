chrome.extension.sendMessage({}, function(response) {
    if (!String.prototype.endsWith) {
        Object.defineProperty(String.prototype, 'endsWith', {
            enumerable: false,
            configurable: false,
            writable: false,
            value: function(searchString, position) {
                position = position || this.length;
                position = position - searchString.length;
                var lastIndex = this.lastIndexOf(searchString);
                return lastIndex !== -1 && lastIndex === position;
            }
        });
    }

    var readyStateCheckInterval = setInterval(function() {
        if (document.readyState === "complete") {

            // var currentPageUrlIs = "";
            // if (typeof this.href != "undefined") {
            //     currentPageUrlIs = this.href.toString().toLowerCase();
            // } 
            // else {
            //     currentPageUrlIs = document.location.toString().toLowerCase();
            // }

            if (document.getElementsByClassName('code-body')[0]) {
                var rawButton = document.getElementById('raw-url');

                if (!rawButton || document.getElementById('preview-url-btn')) {
                    return;
                }

                // Add Preview button
                var newLink = rawButton.href.replace('raw/', '');
                newLink = newLink.replace('/github', '/rawgithub');

                var previewButton = rawButton.cloneNode(true);
                previewButton.id = 'preview-url-btn';
                previewButton.classList.add('danger');
                previewButton.textContent = 'Preview';
                previewButton.href = newLink;

                rawButton.parentNode.insertBefore(previewButton, rawButton.nextSibling);

                // Add Copy text button
                var copyTextButton = document.createElement('button');
                copyTextButton.id = 'copy-text-btn';
                copyTextButton.className = 'button minibutton danger';
                copyTextButton.textContent = 'Select';

                copyTextButton.onclick = function() {
                    var codeBody = document.getElementsByClassName('code-body')[0];
                    codeBody.setAttribute('contenteditable', true);
                    codeBody.focus();
                    document.execCommand('selectAll', false, null);
                };

                rawButton.parentNode.insertBefore(copyTextButton, previewButton.nextSibling);
            }
        }
    }, 150);
});