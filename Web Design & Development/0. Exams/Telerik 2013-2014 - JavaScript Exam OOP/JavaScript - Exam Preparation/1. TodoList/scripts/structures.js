define(['todo-list/container', 'todo-list/section', 'todo-list/item'], function(Container, Section, Item) {
  'use strict';
  return {
    getContainer: function() {
      return new Container();
    },
    getSection: function(title) {
      return new Section(title);
    },
    getItem: function(content, type) {
      return new Item(content, type);
    }
  };
});