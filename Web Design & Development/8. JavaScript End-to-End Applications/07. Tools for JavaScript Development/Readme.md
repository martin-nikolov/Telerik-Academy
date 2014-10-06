## Tools for JavaScript Development

1. Create a project with a Gruntfile.js and three folders – DEV folder, APP folder and DIST folder
    * Write some CoffeeScript, Jade and Stylus in APP
    * Register the following grunt tasks:
        * Serve:
            * Compiles the CoffeeScript to JS and puts them into DEV/scripts
            * Runs jshint on the compiled JS files
            * Compiles the Jade to HTML and puts them into DEV
            * Compiles the Stylus to CSS and puts them into DEV/styles
            * Copies every image from the APP/images to DEV/images
            * Connect a server on port 9578 and show the contents of DEV
            * Watch for changes to the CoffeeScript, Stylus and Jade files, and if changed – reload the page into the browser
2. Create a project with a Gruntfile.js and three folders – DEV folder, APP folder and DIST folder
    * Write some CoffeeScript, Jade and Stylus in APP
    * Register the following grunt tasks:
    * Build:
        * Compiles CoffeeScript, Stylus and Jade
        * Runs jshint and csslint
        * Concats all CSS files into one file and minify it into DIST/styles
        * Concats all JS files into one file and uglify it into DIST/scripts
        * Uglifies the HTML files into DIST
        * Copies all images into DIST/images
