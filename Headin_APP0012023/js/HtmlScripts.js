function openModal(noticia) {
    var modal = document.getElementById('modal');
    var modalTitle = document.getElementById('modal-title');
    var modalBody = document.getElementById('modal-body');

    modal.style.display = "block";

    if (noticia === 'noticia1') {
        modalTitle.innerHTML = "Notícia 1";
        modalBody.innerHTML = "Esta é a notícia 1. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
    } else if (noticia === 'noticia2') {
        modalTitle.innerHTML = "Notícia 2";
        modalBody.innerHTML = "Esta é a notícia 2. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
    }
}

function closeModal() {
    var modal = document.getElementById('modal');
    modal.style.display = "none";
}
