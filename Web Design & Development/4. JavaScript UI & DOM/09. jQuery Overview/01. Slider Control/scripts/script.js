/*
    1. Create a slider control using jQuery
    - The slider can have many slides
    - Only one slide is visible at a time
    - Each slide contains HTML code
        -> i.e. it can contain images, forms, divs, headers, links, etc…
    - Implement functionality for changing the visible slide after 5 seconds
    - Create buttons for next and previous slide
*/

window.onload = function() {
    var articleText = 'But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful.';

    var footerText = 'Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which.';

    var imgSrc = 'images/example.jpg';

    SliderControl.addSlide(createSlide("First Slide", articleText, imgSrc, footerText));
    SliderControl.addSlide(createSlide('Second Slide', null, 'images/example.jpg'));
    SliderControl.addSlide(createSlide("Third Slide", articleText + footerText, imgSrc));
    SliderControl.addSlide(createSlide(null, '<img src=images/example.jpg />', null, 'Fourth slide...'));
};

var SliderControl = (function() {
    var _slides = [];
    var _prevButtonId = '#previous-button';
    var _nextButtonId = '#next-button';
    var _slideContainerId = '#slide-container';
    var _timer = null;
    var _nextSlideTimeMS = 3000;

    // Class constructor
    function Slide(htmlCode) {
        var div = $('<div/>')
            .html(htmlCode)
            .addClass('hidden');
        return div;
    }

    function addSlide(htmlCode) {
        var slide = new Slide(htmlCode);

        if (_slides.length === 0) {
            removeHiddenClass(slide);
            setTimer();
            setButtonEvents();
        }

        _slides.push(slide);
        $(_slideContainerId).append(slide);
    }

    function displayNextSlide(isNext) {
        if (!_slides || _slides.length === 0) {
            return;
        }

        var checkedIndex = 0;

        for (var i = 0; i < _slides.length; i++) {
            if (!_slides[i].hasClass('hidden')) {
                checkedIndex = i;
            }

            _slides[i].addClass('hidden');
        }

        var indexForCheck = isNext ? checkedIndex + 1 : checkedIndex - 1;

        if (indexForCheck < 0) {
            indexForCheck = _slides.length - 1;
        }
        else if (indexForCheck >= _slides.length) {
            indexForCheck = 0;
        }

        removeHiddenClass(_slides[indexForCheck]);
    }

    function setButtonEvents() {
        var prevButton = $(_prevButtonId)
            .on('click', function() {
                displayNextSlide(false);
                setTimer();
            });

        var nextButton = $(_nextButtonId)
            .on('click', function() {
                displayNextSlide(true);
                setTimer();
            });
    }

    function setTimer() {
        if (_timer) {
            clearInterval(_timer);
        }

        _timer = setInterval(function() {
            displayNextSlide(true);
        }, _nextSlideTimeMS);
    }

    function removeHiddenClass(slide) {
        slide.removeClass('hidden');

        if (slide.attr('class').length === 0) {
            slide.removeAttr('class');
        }
    }

    return {
        addSlide: function(htmlCode) {
            addSlide(htmlCode);
        }
    };
}());

function createSlide(headerText, articleText, imgSrc, footerText, id) {
    var div = $('<div/>')
        .attr('id', id || 'slide');

    if (headerText) {
        var h1 = $('<h1/>').html(headerText);
        div.append(h1);
    }

    if (articleText) {
        var article = $('<div/>').html(articleText);
        article.addClass('article');
        div.append(article);
    }

    if (imgSrc) {
        var img = $('<img/>');
        img.attr('src', imgSrc);
        div.append(img);
    }

    if (footerText) {
        var footer = $('<div/>').html(footerText);
        footer.addClass('footer');
        div.append(footer);
    }

    return div.wrapAll('<div></div>').parent().html();
}