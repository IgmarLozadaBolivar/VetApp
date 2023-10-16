Swal.fire({
    title: 'Ingresa tu token',
    icon: 'warning',
    html: `
        <input type="text" id="token-input" class="swal2-input" placeholder="Ingresa tu token aquí">
    `,
    showCancelButton: true,
    confirmButtonText: 'Aceptar',
    allowOutsideClick: false,
    allowEscapeKey: false,
    preConfirm: async () => {
        const token = document.getElementById('token-input').value;
        try {
            const response = await fetch('http://localhost:5285/User/validarToken', {
                method: 'POST',
                body: JSON.stringify({ token }),
                headers: {
                    'Content-Type': 'application/json',
                },
            });
            if (response.ok) {
                Swal.fire({
                    title: '¡Token valido!',
                    text: 'Puedes disfrutar de los servicios de la app!',
                    icon: 'success',
                });
                return token;
            } else {
                Swal.showValidationMessage('Token invalido');
            }
        } catch (error) {
            console.error(error);
        }
    },
}).then((result) => {
    if (result.isConfirmed) {
        const token = result.value;
    } else if (result.isDismissed) {
        window.location.href = 'http://127.0.0.1:5500/Front/Html/login.html';
    }
});

let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search");
let logoIcon = document.querySelector('.logo-icon');
closeBtn.addEventListener("click", () => {
    sidebar.classList.toggle("open");
    menuBtnChange();
});
searchBtn.addEventListener("click", () => {
    sidebar.classList.toggle("open");
    menuBtnChange();
});
function menuBtnChange() {
    if (sidebar.classList.contains("open")) {
        closeBtn.classList.replace("bx-menu", "bx-menu-alt-right");
        logoIcon.style.display = 'block';
    } else {
        closeBtn.classList.replace("bx-menu-alt-right", "bx-menu");
        logoIcon.style.display = 'none';
    }
}