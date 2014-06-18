$.fn.gallery = function (columnsCount) {
    var DEFAULT_COLUMNS_COUNT = 4;
    var IMG_WIDTH = 260;
    var numberOfColumns = columnsCount || DEFAULT_COLUMNS_COUNT;

    var gallery = $(this);
    gallery.addClass('gallery');
    gallery.css('width', (IMG_WIDTH * numberOfColumns) + 'px');
    gallery.find('div.selected').hide(); // Hide div shows the prev/current/next image

    var galleryList = gallery.find('.gallery-list');
    var imagesList = galleryList.find('.image-container > img');

    var selectedImagesContainer = gallery.find('div.selected');
    var selectedPrevImg = selectedImagesContainer.find('#previous-image');
    var selectedCurrentImg = selectedImagesContainer.find('#current-image');
    var selectedNextImg = selectedImagesContainer.find('#next-image');
    selectedPrevImg.on('click', navImageEventOnClick);
    selectedCurrentImg.on('click', selectedImageEventOnClick);
    selectedNextImg.on('click', navImageEventOnClick);

    var selectedImage = null;

    // Set event on img click
    galleryList.on('click', 'img', function(e) {
        if (!selectedImage) {
            changeEnlargedImage($(e.target));
        }
    });

    function changeEnlargedImage(img) {
        selectedImage = $(img);
        var targetImgDataInfo = getImageDataInfo(selectedImage);

        var prevIndex = (targetImgDataInfo  - 1) % imagesList.length;
        prevIndex = (prevIndex - 1 < 0 ? imagesList.length - 1 : prevIndex - 1);
        var prevImage = $(imagesList[prevIndex]);

        var currentIndex = targetImgDataInfo;
        var currentImage = $(imagesList[currentIndex - 1]);

        var nextIndex = targetImgDataInfo % imagesList.length;
        var nextImage = $(imagesList[nextIndex]);

        setImgAttributes(selectedPrevImg, prevImage);
        setImgAttributes(selectedCurrentImg, currentImage);
        setImgAttributes(selectedNextImg, nextImage);

        selectedImagesContainer.show();
        galleryList.addClass('blurred');
    }

    function selectedImageEventOnClick() {
        selectedImage = null;
        selectedImagesContainer.hide();
        galleryList.removeClass('blurred');
    }

    function navImageEventOnClick(e) {
       changeEnlargedImage($(e.target));
    }

    function getImageDataInfo(img) {
        return img.attr('data-info') | 0;
    }

    function setImgAttributes(toImage, fromImage) {
        toImage.attr('src', fromImage.attr('src'));
        toImage.attr('data-info', fromImage.attr('data-info'));
    }
};