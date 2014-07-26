## Consuming Remote Data with JavaScript

1. Create a module that exposes methods for performing HTTP requests by given URL and headers
    * getJSON and postJSON
        * Both methods should work with promises
* Read the developer documentation of Twitter
    * Create a simple application that visualizes all public tweets for a given user (maybe from a textbox)
* Using the REST API at 'localhost:3000/students' create a web application for managing students
    * The REST API provides methods as follows:
        * POST creates a new student
        * GET returns all students
        * DELETE deletes a student by Id
    * You may extend the demo for jQuery.ajax()