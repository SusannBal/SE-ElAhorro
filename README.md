# 🛒 Sistema de Gestión "El Ahorro"

Este proyecto es una solución integral para la gestión de una tienda, compuesta por una API robusta construida con **.NET** y un cliente web moderno desarrollado con **React**.

## 📑 Tabla de Contenidos
- [Arquitectura General](#arquitectura-general)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Configuración del Backend (.NET API)](#backend-net-api)
- [Configuración del Frontend (React + Vite)](#frontend-react-vite)
- [Estructura del Proyecto](#estructura-del-proyecto)

---

## 🏗️ Arquitectura General

El sistema sigue una arquitectura desacoplada:
- **Backend:** Arquitectura en Capas (N-Layer) promoviendo la separación de responsabilidades y mantenibilidad.
- **Frontend:** Single Page Application (SPA) con arquitectura basada en componentes y gestión de estado global.

---

## 🛠️ Tecnologías Utilizadas

### **Backend**
- **Framework:** .NET 8.0+ / ASP.NET Core Web API
- **Persistencia:** Entity Framework Core (Code First)
- **Base de Datos:** SQL Server
- **Seguridad:** Autenticación basada en JWT (JSON Web Tokens)
- **Documentación:** Swagger / OpenAPI

### **Frontend**
- **Framework:** React 18
- **Herramienta de Construcción:** Vite (Alta velocidad)
- **Lenguaje:** TypeScript (Tipado estático)
- **Estilos:** Tailwind CSS (Diseño responsivo y moderno)
- **Estado:** Zustand (Gestión de estado simplificada)
- **Peticiones:** Axios (Cliente HTTP)
- **Reportes:** @react-pdf/renderer (Generación de facturas/reportes PDF)

---

## 🖥️ Backend (.NET API)

La API se encuentra en la carpeta `Tienda/Backent/Tienda`.

### **Capas del Proyecto**
1.  **Tienda.API:** Punto de entrada, controladores y configuración de servicios.
2.  **Tienda.Application:** Lógica de negocio, interfaces de servicios y DTOs (Data Transfer Objects).
3.  **Tienda.Domain:** Entidades principales del sistema y reglas de dominio.
4.  **Tienda.Infrastructure:** Implementación de acceso a datos (Repositories, DBContext) y servicios externos (Seguridad).

### **Ejecución rápida**
```powershell
cd "Tienda/Backent/Tienda/Tienda.API"
dotnet run
```
*Acceso a Swagger:* `https://localhost:7183/swagger`

---

## 🌐 Frontend (React + Vite)

El cliente se encuentra en la carpeta `frontend/frontend`.

### **Características Principales**
- **Routing:** React Router DOM para navegación fluida.
- **Formularios:** React Hook Form para validaciones eficientes.
- **Diseño:** Totalmente responsivo mediante clases de utilidad de Tailwind.

### **Estructura de Carpetas (`src/`)**
- `components/`: Componentes reutilizables (Botones, inputs, modales).
- `pages/`: Vistas principales (Login, Dashboard, Productos, Clientes).
- `services/`: Lógica de consumo de la API mediante Axios.
- `store/`: Almacenes de estado global (Auth, Carrito).
- `layouts/`: Estructuras base de la página (Header, Sidebar).

### **Ejecución rápida**
```bash
cd "frontend/frontend"
npm install
npm run dev
```
*Acceso local:* `http://localhost:5173`

---

## 📂 Estructura del Repositorio

```text
.
├── Tienda/                     # Código fuente del Backend
│   └── Backent/
│       └── Tienda/
│           ├── Tienda.API/          # Controladores y Configuración
│           ├── Tienda.Application/  # Lógica de Negocio
│           ├── Tienda.Domain/       # Entidades
│           └── Tienda.Infrastructure/# Datos y Seguridad
└── frontend/                   # Código fuente del Frontend
    └── frontend/
        ├── src/                # Código React
        ├── public/             # Assets estáticos
        └── package.json        # Dependencias
```

---

## ⚙️ Configuración Requerida

### **Base de Datos**
Asegúrate de tener SQL Server corriendo y actualizar la cadena de conexión en:
`Tienda/Backent/Tienda/Tienda.API/appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=ElAhorro;..."
}
```

### **Variables de Entorno**
El frontend está configurado para conectarse a la API en `https://localhost:7183/api`. Si cambias el puerto del backend, ajusta la configuración en los servicios de Axios.

---
*Desarrollado para el proyecto de Sistemas de Información II.*
