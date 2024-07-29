< !DOCTYPE html >
    <html lang="en">
        <head>
            <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>Theme Toggle</title>
                    <style>
                        body {
                            transition: background-color 0.3s, color 0.3s; /* Smooth transition */
        }

                        .dark-mode {
                            background - color: #121212;
                        color: #e0e0e0;
        }

                        .theme-switch {
                            position: relative;
                        display: inline-block;
                        width: 40px;
                        height: 20px;
        }

                        .theme-switch input {
                            opacity: 0;
                        width: 0;
                        height: 0;
        }

                        .slider {
                            position: absolute;
                        cursor: pointer;
                        top: 0;
                        left: 0;
                        right: 0;
                        bottom: 0;
                        background-color: #333;
                        transition: 0.4s;
                        border-radius: 20px;
        }

                        .slider:before {
                            position: absolute;
                        content: "";
                        height: 16px;
                        width: 16px;
                        left: 2px;
                        bottom: 2px;
                        background-color: white;
                        transition: 0.4s;
                        border-radius: 50%;
        }

                        input:checked + .slider {
                            background - color: black;
        }

                        input:checked + .slider:before {
                            transform: translateX(20px);
        }
                    </style>
                </head>
                <body>
                    <label class="theme-switch">
                        <input type="checkbox" id="theme-toggle">
                            <span class="slider"></span>
                    </label>

                    <script>
                        document.addEventListener('DOMContentLoaded', function () {
            const themeToggle = document.getElementById('theme-toggle');

                        // Check local storage to apply the theme on page load
                        const storedTheme = localStorage.getItem('theme');
                        if (storedTheme === 'dark') {
                            document.body.classList.add('dark-mode');
                        themeToggle.checked = true;
            }

                        // Add event listener to the toggle switch
                        themeToggle.addEventListener('change', function () {
                if (this.checked) {
                            document.body.classList.add('dark-mode');
                        localStorage.setItem('theme', 'dark');
                } else {
                            document.body.classList.remove('dark-mode');
                        localStorage.setItem('theme', 'light');
                }
            });
        });
                    </script>
                </body>
            </html>
