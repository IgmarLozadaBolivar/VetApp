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

let botonPlay = document.getElementById("botonPlay");
botonPlay.addEventListener("click", function (e) {
    e.preventDefault();
    Consulta1();
});

/* const urlAuth = "http://localhost:5285/api/Veterinario/cirujanosVasculares2";
const headers = new Headers({ 'Content-Type': 'application/json' });

async function Consulta1() {
    const config = {
        method: 'GET',
        headers: headers,
    }

    try {
        const response = await fetch(urlAuth, config);

        if (response.ok) {
            const result = await response.json();

            const nombre = result[0].Nombre;
            const email = result[0].Email;
            const telefono = result[0].Telefono;

            Swal.fire({
                title: '¡Bienvenido!',
                text: 'Deseas realizar esta consulta?',
                icon: 'question',
                confirmButtonText: 'Si',
                cancelButtonText: 'No',
                showCancelButton: true,
                allowOutsideClick: false,
                allowEscapeKey: false,
            });

            if (result) {
                Swal.fire({
                    title: '¡Resultado!',
                    html: `<p>Nombre: ${nombre}</p><p>Email: ${email}</p><p>Teléfono: ${telefono}</p>`,
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                });
            }
        } else {
            alert("Autenticación fallida. Verifique sus credenciales o regístrese.");
        }
    } catch (error) {
        console.error("Error al realizar la Autenticación:", error);
    }
} */

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