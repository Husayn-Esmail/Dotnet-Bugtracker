// The goal for this file is to create a modal

const openEls = document.querySelectorAll("[data-open]");
const isVisible = "is-visible";

// allows user to click plus button to open modal
for (const el of openEls) {
    el.addEventListener("click", function() {
        const modalId = this.dataset.open;
        document.getElementById(modalId).classList.add(isVisible);
    });
}

// close button
const closeEls = document.querySelectorAll("[data-close]");
for (const el of closeEls) {
    el.addEventListener("click", function() {
        this.parentElement.parentElement.parentElement.classList.remove(isVisible);
    });
}

// click outside exits modal
document.addEventListener("click", e => {
    if (e.target == document.querySelector(".modal.is-visible")) {
        document.querySelector(".modal.is-visible").classList.remove(isVisible);
    }
});


// allows user to press escape to get out of modal
document.addEventListener("keyup", e=> {
    if (e.key == "Escape" && document.querySelector(".modal.is-visible")) {
        document.querySelector(".modal.is-visible").classList.remove(isVisible);
    }
});
