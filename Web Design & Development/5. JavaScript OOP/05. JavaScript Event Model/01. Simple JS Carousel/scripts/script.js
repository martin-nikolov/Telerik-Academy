window.onload = function() {
    var step = 913;
    var carouselList = document.getElementById('carousel-list');

    var previousButton = document.getElementById('previousButton');

    previousButton.onclick = function() {
        carouselList.style.marginLeft = (getPixels(carouselList.style.marginLeft) + step + 'px');

        if (getPixels(carouselList.style.marginLeft) > 0) {
            carouselList.style.marginLeft = (-step * 2) + 'px';
        }
    };

    var nextButton = document.getElementById('nextButton');

    nextButton.onclick = function() {
        carouselList.style.marginLeft = (getPixels(carouselList.style.marginLeft) - step + 'px');

        if (getPixels(carouselList.style.marginLeft) <= -step * 3) {
            carouselList.style.marginLeft = '0px';
        }
    };

    function getPixels(prop) {
        return parseInt(prop) | 0;
    }
}