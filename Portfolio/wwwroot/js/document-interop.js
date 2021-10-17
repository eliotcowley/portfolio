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

    console.log(document.body.scrollTop);
    console.log(document.documentElement.scrollTop);

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