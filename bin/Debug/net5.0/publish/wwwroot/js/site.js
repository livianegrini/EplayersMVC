// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function BotaoDoMenu() {
    var menu = document.getElementById("links")
    if (menu.style.display  === "flex") {
        // esconda o menu
        menu.style.display = "none"
    }else {
        // mostre o menu
        menu.style.display = "flex"
    }
}
