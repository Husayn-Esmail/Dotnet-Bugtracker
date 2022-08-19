// dynamically adds top and bottom to first and last element
const issues = document.querySelectorAll('.issue');
const finalItem = issues[issues.length - 1];
const firstItem = issues[0];

if (issues.length !== 0) {
    firstItem.querySelector('a').classList.add('top');
    finalItem.querySelector('a').classList.add('bottom');
}

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

const issueStatus = document.querySelectorAll('.issue-status');
for (var i = 0; i < issueStatus.length; i++) {
    let isstatus = issueStatus[i];
    isstatus.classList.add("status");
    switch (isstatus.innerHTML.trim()) {
        case "open":
            isstatus.classList.add("open");
            break;
        case "closed":
            isstatus.classList.add("closed");
            break;
        case "unresolved":
            isstatus.classList.add("unresolved");
            break;
        case "assigned":
            isstatus.classList.add("assigned");
            break;
        case "resolved":
            isstatus.classList.add("resolved");
            break;
        case "archived":
            isstatus.classList.add("archived");
            break;
        default:
            isstatus.classList.add("default");
            break;
        }
        isstatus.innerHTML = "";
}

const form = document.querySelector('.search-form')
console.log(form.children[0].value);
if (form.children[0].value !== "") {
    const x = document.createElement("button");
    x.value = "back";
    x.classList.add("back");
    x.classList.add("button");
    
}