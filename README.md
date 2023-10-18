<!-- Encabezado -->
<img src="./assets/readme-img.jpg" alt="Imagen Farmacia" width="auto" height="auto">
<h1 align="center"><img width="32" height="32" src="https://img.icons8.com/color/48/veterinarian.png" alt="pills"/><b>VetApp</b></h1>
<br>
<!-- Descripcion -->
<p>Creación de un sistema de administración para una veterinaria. Este sistema permitirá a los administradores y al personal de la veterinaria gestionar de manera eficiente y efectiva todas las actividades relacionadas con la atención de mascotas y la gestión de clientes!</p>

<!-- Seccion 1 -->
<h2>Tecnologias</h2>
<p align="center">
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

- **Front-End Development**:
  ![HTML5](https://img.shields.io/badge/HTML5%20-%23E34F26.svg?style=flat&logo=html5&logoColor=white) ![CSS3](https://img.shields.io/badge/CSS%20-%231572B6.svg?style=flat&logo=css3&logoColor=white) ![JavaScript](https://img.shields.io/badge/JavaScript%20-%23F7DF1E.svg?style=flat&logo=javascript&logoColor=black)

- **Back-End Development**: 
  ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white)   

- **Softwares and Tools**: 
  ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=flat&logo=visual-studio-code&logoColor=white) ![Postman](https://img.shields.io/badge/Postman-FF6C37?style=flat&logo=postman&logoColor=white) ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=flat&logo=swagger&logoColor=white) ![Insomnia](https://img.shields.io/badge/Insomnia-black?style=flat&logo=insomnia&logoColor=5849BE)

- **Databases**:
  ![PostgresSQL](https://img.shields.io/badge/postgres-%23316192.svg?style=flat&logo=postgresql&logoColor=white)
  
</p>
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

<!-- Seccion 2 -->
<h3>Requerimientos funcionales:</h3><br>
𐤏 El sistema debe implementar protección en los endpoints utilizando JWT (JSON Web Tokens). El token tiene una duracion de 1 minuto. ✔ <br>
𐤏 Se debe implementar refresh token. ✔ <br>
𐤏 Debe restringir las peticiones a los endpoints según los roles de los usuarios. ✔ <br>
𐤏 Se debe permitir realizar procesos de creacion, edicion, eliminacion y listado de informacion de cada una de las tablas. ✔ <br>
𐤏 El backend debe permitir restringir peticiones consecutivos usando tecnicas de limitacion por IP. ✔ <br>
𐤏 El backend debe permitir realizar la paginacion en  las peticiones get de todos los controladores. 🛠 <br>
𐤏 Los controladores deben implementar 2 versiones diferentes (Query y Header). 🛠 <br>

<!-- Seccion 3 -->
<h3>Realizar las siguientes consultas Principales:</h3>
<h4>Grupo A:</h4>
- Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular ✔ <br>
- Listar los medicamentos que pertenezcan a el laboratorio Genfar. ✔ <br>
- Mostrar las mascotas que se encuentren registradas cuya especie sea felina. ✔ <br>
- Listar los propietarios y sus mascotas. ✔ <br>
- Listar los medicamentos que tenga un precio de venta mayor a 50000. ✔ <br>
- Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023. ✔ <br>

<h4>Grupo B:</h4>
- Listar todas las mascotas agrupadas por especie. ✔ <br>
- Listar todos los movimientos de medicamentos y el valor total de cada movimiento. ✔ <br>
- Listar las mascotas que fueron atendidas por un determinado veterinario. ✔ <br>
- Listar los proveedores que me venden un determinado medicamento. ✔ <br>
- Listar las mascotas y sus propietarios cuya raza sea Golden Retriver. ✔ <br>
- Listar la cantidad de mascotas que pertenecen a una raza a una raza. ✔ <br>
Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza. ⚠

<!-- Seccion 4 -->
<h3>Dependencias o paquetes Nuget utilizados:</h3>
<h4>API</h4>
- Serilog.AspNetCore - v7.0.0 <br>
- AspNetCoreRateLimit - v5.0.0 <br>
- System.IdentityModel.Tokens.Jwt - v7.0.2 <br>
- Microsoft.AspNetCore.Mvc.Versioning - v5.1.0 <br>
- Microsoft.EntityFrameworkCore.Design - v7.0.12 <br>
- Microsoft.AspNetCore.Authentication.JwtBearer - v7.0.12 <br>
- AutoMapper.Extensions.Microsoft.DependencyInjection - v12.0.1 <br>

<h4>Domain</h4>
- itext7.pdfhtml - v5.0.1 <br>
- FluentValidation.AspNetCore - v11.3.0 <br>
- Microsoft.EntityFrameworkCore - v7.0.12 <br>

<h4>Persistence</h4>
- CsvHelper - v30.0.1 <br>
- Microsoft.EntityFrameworkCore - v7.0.12 <br>
- Npgsql.EntityFrameworkCore.PostgreSQL - v7.0.11 <br>

<!-- Footer -->
<h5>Autores:</h5>
- <a href="https://github.com/IgmarLozadaBolivar">Igmar Lozada Bolivar</a><br>