define(function(require) {

    var Picture = {
        init: function(imgTitle, url) {
            this.imgTitle = imgTitle;
            this.url = url;

            return this;
        }
    };

    return Picture;
})