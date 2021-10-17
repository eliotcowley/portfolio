var portfolio = portfolio || {};
portfolio.setDocumentTitle = function (title) {
    document.title = title;
};

var backToTopButton = document.getElementById("btn-back-to-top");
var backToTopButtonScrollAmount = 300;

window.onscroll = function () {
    if (backToTopButton == null) {
        backToTopButton = document.getElementById("btn-back-to-top");
    }

    if (document.documentElement.scrollTop > backToTopButtonScrollAmount) {
        backToTopButton.style.display = "block";
    }
    else {
        backToTopButton.style.display = "none";
    }
}

function OnScrollEvent() {
    document.documentElement.scrollTop = 0;
}

var navbar;
var navbarCollapse;

function collapseNavbar() {
    if (navbar == null) {
        navbar = document.getElementById("navbarSupportedContent");
        navbarCollapse = new bootstrap.Collapse(navbar);
    }

    navbarCollapse.hide();
}