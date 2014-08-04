var express = require('express');
var enableCors = function (req, res, next) {
    'use strict';

    // console.log("Cors handler invoked");
    var oneof = false;
    if (req.headers.origin) {
        res.header('Access-Control-Allow-Origin', req.headers.origin);
        oneof = true;
    }
    if (req.headers['access-control-request-method']) {
        res.header('Access-Control-Allow-Methods', req.headers['access-control-request-method']);
        oneof = true;
    }
    if (req.headers['access-control-request-headers']) {
        res.header('Access-Control-Allow-Headers', req.headers['access-control-request-headers']);
        oneof = true;
    }
    if (oneof) {
        res.header('Access-Control-Max-Age', 60 * 60 * 24 * 365);
    }
    // intercept OPTIONS method
    if (oneof && req.method === 'OPTIONS') {
        res.send(200);
    } else {
        next();
    }
};

module.exports = function (app, config) {
    app.configure(function () {
        app.use(express.compress());
        app.set('port', config.port);
        app.use(express.logger('dev'));
        app.use(express.bodyParser());
        app.use(express.methodOverride());
        app.use(enableCors);
        app.use(app.router);
		app.use(express.errorHandler( { dumpExceptions: false, showStack: false } ));
        // app.use(function(req, res) {
        //   res.status(404).render('404', { title: '404' });
        // });
    });
};