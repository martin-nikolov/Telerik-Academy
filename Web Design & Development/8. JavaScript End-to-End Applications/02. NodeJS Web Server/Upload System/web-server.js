var formidable = require('formidable'),
    http = require('http'),
    fs = require('fs'),
    uuid = require('node-uuid'),
    imageExt = '.jpg';

http.createServer(function(req, res) {
    res.writeHead(200, {
        'content-type': 'text/html'
    });

    if (req.url == '/' && req.method.toLowerCase() == 'get') {
        res.end(generateFormHtml());
    }

    if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
        parseFormData(req, res);
        return;
    }

    if (req.url.indexOf('/image') === 0) {
        var imageId = __dirname + req.url;

        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        fs.readFile(imageId, function(error, data) {
            if (error) {
                console.log('Cannot read image...');
                return;
            }

            res.write('<html><body><img src="data:image/jpeg;base64,')
            res.write(new Buffer(data).toString('base64'));
            res.end('"/></body></html>');
        });

        return;
    }

    function parseFormData(req, res, form) {
        var form = new formidable.IncomingForm();
        form.parse(req, function(error, fields, files) {
            var filePath = files.upload.path;
            saveFile(filePath, res);
        });
    }

    function saveFile(filePath, res) {
        fs.readFile(filePath, function(error, original_data) {
            var id = uuid.v1();
            var base64Image = original_data.toString('base64');
            var decodedImage = new Buffer(base64Image, 'base64');
            fs.writeFile('Images/' + id + imageExt, decodedImage, function(error) {});

            res.write('You can access image at: localhost:1234/images/' + id + imageExt);
            res.end();
        });
    }

    res.end();
}).listen(1234);

function generateFormHtml() {
    return '<form action="/upload" enctype="multipart/form-data" method="post">' +
        '<input type="file" name="upload" accept="image/*"><br>' +
        '<input type="submit" value="Upload">' +
        '</form>';
}