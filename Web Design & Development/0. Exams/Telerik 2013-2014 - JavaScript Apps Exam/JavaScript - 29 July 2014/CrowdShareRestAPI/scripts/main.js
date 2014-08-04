/// <reference path="http-requester.js" />
/// <reference path="data-persister.js" />

define(function () {
    require.config({
        paths: {
            'jquery': 'vendor/jquery-2.1.1',
            'sha1': 'vendor/cryptojs-sha1',
            'q': 'vendor/q',
            'underscore': 'vendor/underscore',
            'http-requester': 'http-requester',
            'data-persister': 'data-persister',
            'controller': 'controller',
            'ui-controller': 'ui-controller',
            'validation-controller': 'validation-controller'
        }
    });

    require(['http-requester', 'data-persister', 'controller'], function (HttpRequester, DataPersister, Controller) {
        var rootUrl = 'http://localhost:3000',
            persister = DataPersister.getPersister(rootUrl),
            controller = Controller.getController(persister);

        controller.loadUI();
    });
})