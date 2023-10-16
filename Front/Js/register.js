Swal.fire({
    title: '¡Bienvenido!',
    text: 'Te invito a que te registres!',
    icon: 'info',
    confirmButtonText: 'Aceptar'
});

const urlRegister = "http://localhost:5285/User/registrar";
const headers = new Headers({ 'Content-Type': 'application/json' });
const boton = document.getElementById('botonRegistro');

boton.addEventListener("click", function (e) {
    e.preventDefault();
    registrarUsuario();
});

async function registrarUsuario() {
    let inputEmail = document.getElementById('email').value;
    let inputUsuario = document.getElementById('username').value;
    let inputPassword = document.getElementById('password').value;

    let data = {
        "email": inputEmail,
        "username": inputUsuario,
        "password": inputPassword
    }

    const config = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    };

    try {
        const response = await fetch(`${urlRegister}`, config);

        if (response.status === 200) {
            Swal.fire({
                title: '¡Registro exitoso!',
                text: 'Tu registro ha sido completado con exito!',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = '../Html/login.html';
                }
            });
        } else {
            console.error("La solicitud no fue exitosa. Estado:", response.status);
        }
    } catch (error) {
        console.error("Error de red: ", error);
    }
}