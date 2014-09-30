/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui-controller.js" />
/// <reference path="class.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.controller = (function () {
    var AccessController = Class.create({
        init: function (dataPersister) {
            this.persister = dataPersister;

            if (this.persister.loggedIn) {
                this.loadGame();
            }
            else {
                this.loadLogin("#main-content");
            }
        },

        loadLogin: function (selector) {
            var loginHtml = BullsAndCows.ui.loginHtml();
            $(selector).html(loginHtml);
        },

        loadGame: function () {

        }
    });

    return {
        getAccessController: function (dataPersister) { return new AccessController(dataPersister); }
    }
}());