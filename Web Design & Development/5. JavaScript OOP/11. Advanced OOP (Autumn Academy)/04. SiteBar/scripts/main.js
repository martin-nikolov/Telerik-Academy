/*
    4. Create a favorite sites bar
    - The favorite sites bar should keep a set of urls and set of folders
    - Folders have a title and set of urls
    - Urls have a title and a url
    - The favorite sites bar should have a functionality to display urls and folders
    - If an url is clicked, it should be open in new tab in the browser
    - Use Classical OOP with Class.create()
*/

define(function(require) {

    // Include classes
    var Url = require('scripts/Classes/Url.js');
    var Folder = require('scripts/Classes/Folder.js');
    var SiteBar = require('scripts/Classes/SiteBar.js');

    /* ------------------------------------------------------------------------ */
    
    var pcWorld = new Url("PC World", "http://www.pcworld.com/");
    var pluralSight = new Url("Pluralsight", "http://pluralsight.com/");
    var scharpTutorial = new Url("Dot Net Perls", "http://www.dotnetperls.com/");

    var telerikAcademy = new Url("Telerik Academy", "http://academy.telerik.com/");
    var telerikStudentSystem = new Url("Telerik Student System", "http://telerikacademy.com/")
    var telerikAcademyForums = new Url("Telerik Academy Forums", "http://forums.academy.telerik.com/");

    var personalBlog = new Url("Martin Nikolov's blog", "http://flextry.wordpress.com/");
    var gitHub = new Url("GitHub Repository", "https://github.com/flextry");
    var techCrunch = new Url("TechCrunch", "http://techcrunch.com/");

    /* ------------------------------------------------------------------------ */

    var telerikSites = new Folder("Telerik", [telerikAcademy, telerikStudentSystem, telerikAcademyForums]);
    var blogs = new Folder("Blogs", [personalBlog, gitHub, techCrunch]);

    /* ------------------------------------------------------------------------ */

    var siteBar = new SiteBar();
    siteBar.addUrl(pcWorld);
    siteBar.addUrl(pluralSight);
    siteBar.addUrl(scharpTutorial);

    siteBar.addFolder(telerikSites);
    siteBar.addFolder(blogs);

    /* ------------------------------------------------------------------------ */

    var bodyContainer = document.body;
    bodyContainer.appendChild(siteBar.convertToHtml());

    /* ------------------------------------------------------------------------ */
})