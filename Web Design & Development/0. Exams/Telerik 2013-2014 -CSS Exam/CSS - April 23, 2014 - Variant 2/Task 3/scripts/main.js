(function() {
  $(function() {
    ($('.dropdown .chosen')).on('click', function(ev) {
      var isExpanded, ul;
      ul = ($(this)).next();
      isExpanded = ul.hasClass('expanded');
      ($('.expanded')).removeClass('expanded');
      if (!isExpanded) {
        ul.addClass('expanded');
        console.log($(this));
        return ($(this)).addClass('expanded');
      }
    });
    return ($('.dropdown ul li')).on('click', function(ev) {
      var chosen, value;
      value = ($(this)).html();
      chosen = ($(this)).parent().prev();
      chosen.html(value);
      return ($(this)).parent().removeClass('expanded');
    });
  });

}).call(this);
