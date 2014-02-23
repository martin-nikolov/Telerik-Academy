/*
    3. Implement a image slider control using Prototypal OOP
    - The slider has a set of images and only one can be enlarged
    - Each image in the image slider has a title and two urls (thumbnail url and large image url)
    - When an image from the thumbnails is clicked
    - The slider must have buttons for prev/next image
*/

define(function(require) {

    /* ------------------------------------------------------------------------ */

    // Include classes
    var ImageSlider = require('scripts/Classes/ImageSlider.js');
    var Picture = require('scripts/Classes/Picture.js');

    /* ------------------------------------------------------------------------ */

    var imageSlider = (function() {
        var title = 'ANIMAL GALLERY';

        var pictures = [
            Object.create(Picture).init('Chameleon', './images/1.jpg'),
            Object.create(Picture).init('Abalone', './images/2.jpg'),
            Object.create(Picture).init('Polecat', './images/3.jpg'),
            Object.create(Picture).init('Shark', './images/4.jpg'),
            Object.create(Picture).init('Chameleon', './images/5.jpg'),
            Object.create(Picture).init('Tiger', './images/6.jpg'),
            Object.create(Picture).init('White tigers', './images/7.jpg'),
            Object.create(Picture).init('Cats', './images/8.jpg'),
        ];

        return Object.create(ImageSlider).init(title, pictures);
    }());

    imageSlider.addImage(Object.create(Picture).init('Snake', './images/9.jpg'));

    imageSlider.draw();

    imageSlider.addImage(Object.create(Picture).init('Gepard', './images/10.jpg'));

    /* ------------------------------------------------------------------------ */
})