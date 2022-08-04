// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// dynamically adds top and bottom to first and last element
const issues = document.querySelectorAll('.issue');
const finalItem = issues[issues.length - 1];
const firstItem = issues[0];

firstItem.querySelector('a').classList.add('top')
finalItem.querySelector('a').classList.add('bottom');