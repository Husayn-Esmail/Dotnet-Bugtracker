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

// dynamically adds correct class to status
const statusElements = document.querySelectorAll('.status');
for (var i = 0; i < statusElements.length; i++) {
    let status = statusElements[i];
    switch (status.innerHTML) {
        case "open":
            status.classList.add("open");
            break;
        case "closed":
            status.classList.add("closed");
            break;
        case "archived":
            status.classList.add("archived");
            break;
        case "resolved":
            status.classList.add("resolved");
            break;
        case "unresolved":
            status.classList.add("unresolved");
            break;
        case "assigned":
            status.classList.add("assigned");
            break;
        default:
            status.classList.add("default");
            break;
    }
}
