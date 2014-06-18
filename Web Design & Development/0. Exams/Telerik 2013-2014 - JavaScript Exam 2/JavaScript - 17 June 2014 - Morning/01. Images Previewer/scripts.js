// Create container for selected image -> title + big image
var selectedImageTitle = document.createElement('div');
selectedImageTitle.style.fontWeight = 'bold';
selectedImageTitle.style.padding = '12px';
selectedImageTitle.style.fontSize = '30px';

var selectedImage = document.createElement('img');
selectedImage.style.width = '350px';
selectedImage.style.borderRadius = '10px';

var selectedImgContainer = document.createElement('div');
selectedImgContainer.appendChild(selectedImageTitle);
selectedImgContainer.appendChild(selectedImage);

// Right navigation bar - small images
var imageListContainer = document.createElement('div');

function createImagesPreviewer(selector, items) {
    var imagesPreviewerContainer = generateImagesPreviewer(items);

    // Add the Image Preview Container to DOM Tree
    var wrapper = document.querySelector(selector);
    wrapper.appendChild(imagesPreviewerContainer);
}

function generateImagesPreviewer(items) {
    var navContainer = generateNavigationContainer(items);

    // Create Image Preview Container
    var imagesPreviewerContainer = document.createElement('div');
    imagesPreviewerContainer.appendChild(selectedImgContainer);
    imagesPreviewerContainer.appendChild(navContainer);

    selectFirstImage(imageListContainer);

    // Apply styles to containers
    setStylesToSelectedImageContainer(selectedImgContainer);
    setStylesToNavContainer(navContainer);
    setStylesToImagePreviewerContainer(imagesPreviewerContainer);
    return imagesPreviewerContainer;
}

// Create right navigation container -> filter + small images
function generateNavigationContainer(items) {
    var filterTitle = document.createElement('div');
    filterTitle.innerText = 'Filter';

    var filterInput = document.createElement('input');
    filterInput.setAttribute('type', 'text');
    filterInput.style.width = '125px';
    filterInput.addEventListener('change', onFilterInputValueChanged, false);

    var imageList = getSmallImagesContainers(items);
    var docFrag = document.createDocumentFragment();
    for (var i = 0; i < imageList.length; i++) {
        docFrag.appendChild(imageList[i]);
        imageList[i].addEventListener('click', onSmallImageClick, false);
        imageList[i].addEventListener('mouseover', onChangeBackgroundMouseover, false);
        imageList[i].addEventListener('mouseout', onChangeBackgroundMouseout, false);
    }
    imageListContainer.appendChild(docFrag); // global variable

    var navContainer = document.createElement('div');
    navContainer.appendChild(filterTitle);
    navContainer.appendChild(filterInput);
    navContainer.appendChild(imageListContainer);
    return navContainer;
}

function getSmallImagesContainers(images) {
    var imageTitle = document.createElement('div');
    imageTitle.className = 'image-title';
    imageTitle.style.fontWeight = 'bold';

    var smallImage = document.createElement('img');
    smallImage.style.width = '120px';
    smallImage.style.borderRadius = '10px';

    var imgContainer = document.createElement('div');
    imgContainer.appendChild(imageTitle);
    imgContainer.appendChild(smallImage);

    var imageList = [];
    for (var img in images) {
        var currentImg = images[img];
        imageTitle.innerHTML = currentImg.title;
        smallImage.src = currentImg.url;
        imageList.push(imgContainer.cloneNode(true));
    }
    return imageList;
}

// 'selectedImageTitle' and 'selectedImage' are global variables
function selectFirstImage(imageListContainer) {
    var firstImageContainer = imageListContainer.querySelector('div'); // select first img if exists
    if (firstImageContainer) {
        var firstImgTitle = firstImageContainer.querySelector('div.image-title').innerHTML;
        var firstImgSrc = firstImageContainer.querySelector('img').src;
        selectedImageTitle.innerHTML = firstImgTitle;
        selectedImage.src = firstImgSrc;
    }
}

// 'selectedImageTitle' and 'selectedImage' are global variables
function onSmallImageClick() {
    var selectedImg = this.querySelector('img');
    var selectedImgTitle = selectedImg.parentElement.querySelector('div.image-title').innerHTML;
    var selectedImgSrc = selectedImg.src;
    selectedImageTitle.innerHTML = selectedImgTitle;
    selectedImage.src = selectedImgSrc;
}

// Hiding elements is faster than recreating them
// 'imageListContainer' is a global variable
function onFilterInputValueChanged() {
    var inputValue = this.value.toLowerCase();
    var imgTitles = imageListContainer.getElementsByClassName('image-title');

    for (var i = 0; i < imgTitles.length; i++) {
        var imgTitle = imgTitles[i].innerHTML.toLowerCase();
        if (imgTitle.indexOf(inputValue) === -1) {
            imgTitles[i].parentElement.style.display = 'none';
        }
        else {
            imgTitles[i].parentElement.style.display = 'block';
        }
    }
}

function onChangeBackgroundMouseover() {
    this.style.backgroundColor = '#D1CBCE';
}

function onChangeBackgroundMouseout() {
    this.style.backgroundColor = '';
}

function setStylesToImagePreviewerContainer(element) {
    element.style.width = '550px';
    element.style.height = '370px';
}

function setStylesToSelectedImageContainer(element) {
    element.style.width = '370px';
    element.style.height = '320px';
    element.style.cssFloat= 'left';
    element.style.textAlign = 'center';}

function setStylesToNavContainer(element) {
    element.style.width = '160px';
    element.style.height = '320px';
    element.style.cssFloat = 'left';
    element.style.overflow = 'auto';
    element.style.marginTop = '20px';
    element.style.textAlign = 'center';
}