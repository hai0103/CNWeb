$.fn.memenu = function (e) {
    function r() {
        $(".memenu").find("li, a").unbind();
        if (window.innerWidth <= 768) {
            o(); s();
            if (n == 0) {
                $(".memenu > li:not(.showhide)").hide(0)
            }
        }
        else { u(); i() }
    }
    function i() {
        $(".memenu li").bind("mouseover", function () {
            $(this).children(".dropdown, .mepanel").stop().fadeIn(t.interval)
        }).bind("mouseleave", function () {
            $(this).children(".dropdown, .mepanel").stop().fadeOut(t.interval)
        })
    }
    function s() {
        $(".memenu > li > a").bind("click", function (e) {
            if ($(this).siblings(".dropdown, .mepanel").css("display") == "none") {
                $(this).siblings(".dropdown, .mepanel").slideDown(t.interval);
                $(this).siblings(".dropdown").find("ul").slideDown(t.interval);
                n = 1
            } else { $(this).siblings(".dropdown, .mepanel").slideUp(t.interval) }
        })
    }
    function o() {
        $(".memenu > li.showhide").show(0);
        $(".memenu > li.showhide").bind("click", function () {
            if ($(".memenu > li").is(":hidden")) { $(".memenu > li").slideDown(300) }
            else { $(".memenu > li:not(.showhide)").slideUp(300); $(".memenu > li.showhide").show(0) }
        })
    }
    function u() {
        $(".memenu > li").show(0); $(".memenu > li.showhide").hide(0)
    }
    var t = { interval: 250 };
    var n = 0;
    $(".memenu").prepend("<li class='showhide'><span class='title'>MENU</span><span class='icon1'></span><span class='icon2'></span></li>");
    r();
    $(window).resize(function () {
        r()
    })
}