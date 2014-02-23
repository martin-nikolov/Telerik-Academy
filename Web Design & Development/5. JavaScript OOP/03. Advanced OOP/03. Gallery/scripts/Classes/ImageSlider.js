define(function(require) {

    var ImageSlider = {
        init: function(sliderTitle, setOfImages) {
            this.sliderTitle = sliderTitle;
            this.setOfImages = Array.isArray(setOfImages) ? setOfImages : [];

            return this;
        },
        addImage: function(image) {
            var section = document.getElementById('imageSlider');

            if (section) {
                var imageCount = section.getElementsByTagName('label').length + 1;

                var id = 'image-' + imageCount;
                var url = image.url;
                var label = _createLabel(id, url, image.imgTitle);

                section.appendChild(label);
            }
            else {
                this.setOfImages.push(image);
            }
        },
        draw: function() {
            if (document.getElementById('imageSlider')) return;

            var section = _createSection(this.sliderTitle);

            for (var i = 0; i < this.setOfImages.length; i++) {
                var id = 'image-' + (i + 1);
                var url = this.setOfImages[i].url;
                var label = _createLabel(id, url, this.setOfImages[i].imgTitle);

                section.appendChild(label);
            }

            var body = document.getElementsByTagName('body')[0];
            body.appendChild(section);

            _checkFirstInput();
            _appendNavButtons(section);
        }
    };

    function _createSection(title) {
        var section = document.createElement('section');
        section.id = 'imageSlider';

        var header = document.createElement('header');
        var h1 = document.createElement('h1');
        h1.innerHTML = title;

        var h2 = document.createElement('h2');
        h2.id = 'img-title';

        header.appendChild(h1);
        header.appendChild(h2);

        section.appendChild(header);

        return section;
    }

    function _createLabel(id, url, imgTitle) {
        var label = document.createElement('label');
        label.setAttribute('for', id);

        var img = document.createElement('img');
        img.setAttribute('src', url);

        var input = document.createElement('input');
        input.setAttribute('type', 'radio');
        input.id = id;
        input.name = 'gallery';
        input.imgTitle = imgTitle;

        input.onclick = function(e) {
            var title = document.getElementById('img-title');
            title.innerHTML = '- ' + this.imgTitle;
        }

        var span = document.createElement('span');
        span.className = 'larger';

        var spanImage = document.createElement('img');
        spanImage.setAttribute('src', url);

        var anchor = document.createElement('a');
        anchor.innerHTML = 'See the full-sized version...';
        anchor.setAttribute('href', url);

        span.appendChild(spanImage);
        span.appendChild(anchor);

        label.appendChild(img);
        label.appendChild(input);
        label.appendChild(span);

        return label;
    }

    function _checkFirstInput() {
        var firstInput = document.getElementsByTagName('input')[0];

        if (firstInput) {
            firstInput.checked = true;
            firstInput.onclick();
        }
    }

    function _appendNavButtons(section) {
        var previous = document.createElement('button');
        previous.className = 'button previous';

        previous.onclick = function() {
            _checkNextRadio(section, false);
        }

        var next = document.createElement('button');
        next.className = 'button next';

        next.onclick = function() {
            _checkNextRadio(section, true);
        }

        section.appendChild(previous);
        section.appendChild(next);
    }

    function _checkNextRadio(section, isNext) {
        var radioInputs = document.getElementsByTagName('input');
        var checkedIndex = 0;

        if (!radioInputs) return;

        for (var i = 0; i < radioInputs.length; i++) {
            if (radioInputs[i].checked) {
                checkedIndex = i;
                break;
            }
        }

        var indexForCheck = isNext ? checkedIndex + 1 : checkedIndex - 1;
        
        if (indexForCheck < 0) {
            indexForCheck = radioInputs.length - 1;
        }
        else if (indexForCheck >= radioInputs.length) {
            indexForCheck = 0;
        }

        radioInputs[indexForCheck].checked = true;
        radioInputs[indexForCheck].onclick();
    }

    return ImageSlider;
})