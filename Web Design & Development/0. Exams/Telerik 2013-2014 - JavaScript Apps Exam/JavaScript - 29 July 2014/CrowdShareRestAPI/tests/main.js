 (function() {
     "use strict";
     require.config({
         baseUrl: '',
         paths: {
             'jquery': '../scripts/vendor/jquery-2.1.1',
             'sha1': '../scripts/vendor/cryptojs-sha1',
             'q': '../scripts/vendor/q',
             'underscore': '../scripts/vendor/underscore',
             'http-requester': '../scripts/http-requester',
             'data-persister': '../scripts/data-persister',
             'controller': '../scripts/controller',
             'ui-controller': '../scripts/ui-controller',
             'validation-controller': '../scripts/validation-controller',
             'mocha': '../scripts/vendor/mocha/mocha',
             'chai': '../scripts/vendor/chai/chai'
         }
     });

     require(['mocha', 'chai'], function() {
         mocha.setup('bdd');
         require(['tests/sort-behaviour.session', 'tests/paging-begaviour.session'], function () {
             mocha.run();
         });
     })
 }());