/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

function logout() {
  // Clear the session data
  sessionStorage.clear();  // For client-side session data
  // Or, for server-side session management:
    fetch('/logout', { method: 'POST' })
        .then(() => {
            //     // Redirect to the login page or home page after logout
            window.location.href = '/login'; // Example redirection
        });
}

            // Função para lidar com o clique em um link de menu que possui submenus
    function handleMenuClick(event) {
        event.preventDefault(); // Impede o comportamento padrão de clicar em um link

    // Obtém o elemento do submenu correspondente
    var submenu = event.target.nextElementSibling;

    // Se o submenu estiver oculto, mostra; caso contrário, oculta
    if (submenu.style.display === "block") {
        submenu.style.display = "none";
                } else {
        submenu.style.display = "block";
                }
            }

    // Adiciona manipuladores de eventos a todos os links de menu com submenus
    document.addEventListener("DOMContentLoaded", function () {
                var menuLinks = document.querySelectorAll('.nav-link.collapsed');
    menuLinks.forEach(function (link) {
        link.addEventListener('click', handleMenuClick);
                });
            });