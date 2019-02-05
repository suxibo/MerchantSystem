$(function () {
    init();
    function init() {
        let path = location.pathname;
        let $sidebar = $("#sidebar");
        $sidebar.find('.sidemodule a').removeClass("selected");
        $sidebar.find('.sidemodule a[href="' + path + '"]').addClass("selected");
    }
});