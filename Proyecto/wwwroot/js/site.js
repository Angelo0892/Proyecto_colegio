// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let listElements = document.querySelectorAll('.list_button--click')

listElements.forEach(listElement => {
    listElement.addEventListener('click', () => {

        listElement.classList.toggle('arrow');

        let height = 0;
        let menu = listElement.nextElementSibling;

        if (menu.clientHeight == 0) {
            height = menu.scrollHeight;
        }

        menu.style.height = height + "px";
    })
});
