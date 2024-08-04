// Ensure DOM is fully loaded before executing scripts
document.addEventListener('DOMContentLoaded', function () {
    const themeToggle = document.getElementById('theme-toggle');

    // Apply the stored theme from local storage on page load
    const storedTheme = localStorage.getItem('theme');
    if (storedTheme === 'dark') {
        document.body.classList.add('dark-mode');
        themeToggle.checked = true;
    } else {
        document.body.classList.remove('dark-mode');
        themeToggle.checked = false;
    }

    // Add event listener to the theme toggle switch
    themeToggle.addEventListener('change', function () {
        if (this.checked) {
            document.body.classList.add('dark-mode');
            localStorage.setItem('theme', 'dark');
        } else {
            document.body.classList.remove('dark-mode');
            localStorage.setItem('theme', 'light');
        }
    });

    // Example for smooth scrolling when clicking internal links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            document.querySelector(this.getAttribute('href')).scrollIntoView({
                behavior: 'smooth'
            });
        });
    });

    // Example of a mobile menu toggle (if you have a mobile menu)
    const menuToggle = document.getElementById('menu-toggle');
    const menu = document.querySelector('.navbar-nav');

    if (menuToggle) {
        menuToggle.addEventListener('click', function () {
            menu.classList.toggle('active');
        });
    }
});
