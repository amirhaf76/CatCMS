﻿// Navbar burger menu toggle
document.addEventListener('DOMContentLoaded', () => {
    const burgers = Array.prototype.slice.call(document.querySelectorAll('.navbar-burger'), 0);
    burgers.forEach(el => {
        el.addEventListener('click', () => {
            const target = el.dataset.target;
            const menu = document.getElementById(target);
            el.classList.toggle('is-active');
            if (menu) menu.classList.toggle('is-active');
        });
    });
});
