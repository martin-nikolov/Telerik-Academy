window.onload = function() {
    var _step = 913;
    var _slides = Math.ceil(document.querySelectorAll('#carousel-list li img').length / 3) | 0;
    var _currentSlide = 0;

    generateCircles(_slides);
    colorCircle(_currentSlide);
    setOnClickToCircles(_step);

    /* -------------------------------------------------------- */

    var carouselList = document.getElementById('carousel-list');

    /* -------------------------------------------------------- */

    // Set event to Previous Button
    var previousButton = document.getElementById('previousButton');

    previousButton.onclick = function() {
        carouselList.style.marginLeft = (getPixels(carouselList.style.marginLeft) + _step + 'px');

        _currentSlide--;

        if (getPixels(carouselList.style.marginLeft) > 0) {
            carouselList.style.marginLeft = (-_step * (_slides - 1)) + 'px';

            _currentSlide = _slides - 1;
        }

        colorCircle(_currentSlide);
    };

    // Set event to Next Button
    var nextButton = document.getElementById('nextButton');

    nextButton.onclick = function() {
        carouselList.style.marginLeft = (getPixels(carouselList.style.marginLeft) - _step + 'px');

        _currentSlide++;

        if (getPixels(carouselList.style.marginLeft) <= -_step * _slides) {
            carouselList.style.marginLeft = '0px';

            _currentSlide = 0;
        }

        colorCircle(_currentSlide);
    };

    /* -------------------------------------------------------- */

    function getPixels(prop) {
        return parseInt(prop) | 0;
    }

    function generateCircles(_slidesCount) {
        var carouselContainer = document.getElementById('carousel-container');
        var carouselNav = document.createElement('div');
        carouselNav.id = 'carousel-nav';

        for (var i = 0; i < _slidesCount; i++) {
            var div = document.createElement('div');
            carouselNav.appendChild(div);
        }

        carouselContainer.appendChild(carouselNav);
    }

    function setOnClickToCircles(step) {
        var carouselList = document.getElementById('carousel-list');
        var carouselNav = document.getElementById('carousel-nav');

        for (var i = 0; i < carouselNav.childNodes.length; i++) {
            carouselNav.childNodes[i].currentIndex = i;

            carouselNav.childNodes[i].addEventListener('click', function() {
                carouselList.style.marginLeft = (-step * this.currentIndex) + 'px'; 
                colorCircle(this.currentIndex);
                _currentSlide = this.currentIndex;
            });
        }
    }

    function colorCircle(slideIndex) {
        var carouselNav = document.getElementById('carousel-nav');
        
        for (var i = 0; i < carouselNav.childNodes.length; i++) {
            carouselNav.childNodes[i].removeAttribute('class');
        }

        carouselNav.childNodes[slideIndex].className = "current";   
    }
}