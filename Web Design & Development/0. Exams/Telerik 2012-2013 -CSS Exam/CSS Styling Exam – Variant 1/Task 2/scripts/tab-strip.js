(function () {
	$.fn.tabStrip = function () {
		var selector = this.selector;

		function onTabBtnClick(e) {
			$(selector + " .current").removeClass("current");
			$(this).parent().addClass("current");

			if (e.preventDefault) {
				e.preventDefault();
			}
			return false;
		}
		$(selector + " .tab-btn").on("click", onTabBtnClick);
	};
})();