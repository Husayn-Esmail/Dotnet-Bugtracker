// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// dynamically adds top and bottom to first and last element
const issues = document.querySelectorAll('.issue');
const finalItem = issues[issues.length - 1];
const firstItem = issues[0];

firstItem.querySelector('a').classList.add('top')
finalItem.querySelector('a').classList.add('bottom');


// dynamically adds correct class to priority
const priority = document.querySelectorAll('.priority');
for (var i = 0; i < priority.length; i++) {
    switch (priority[i].innerHTML) {
        case "high":
            priority[i].classList.add("high");
            break;
        case "medium":
            priority[i].classList.add("medium");
            break;
        case "low":
            priority[i].classList.add("low");
            break;
        default:
            priority[i].classList.add("default");
            break;
    }
}