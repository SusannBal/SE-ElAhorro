# ElAhorro Frontend

Este es el proyecto frontend para la tienda **ElAhorro**, desarrollado con React 18, TypeScript, Vite y Tailwind CSS, siguiendo una **Arquitectura Atómica**.

## 🚀 Tecnologías Principales

- **Framework:** React 18
- **Bundler:** Vite
- **Lenguaje:** TypeScript
- **Estilos:** Tailwind CSS + PostCSS
- **Enrutamiento:** React Router DOM v6
- **Manejo de Formularios:** React Hook Form
- **Peticiones HTTP:** Axios (con interceptores)
- **Estado Global:** Zustand (con middleware de persistencia)
- **PDFs:** `@react-pdf/renderer` (preparado en dependencias)

## 📁 Estructura del Proyecto (Atomic Design)

```
src/
├── components/
│   ├── atoms/        # Botones (Button), Etiquetas (Badge), Inputs
│   ├── molecules/    # Tarjetas de Producto (ProductCard), Barras de Búsqueda (SearchBar)
│   └── organisms/    # Cabecera (Header), Grilla de Productos (ProductGrid)
├── hooks/            # Custom hooks (ej. useProducts)
├── layouts/          # Layouts principales (MainLayout)
├── pages/            # Vistas (HomePage, CartPage)
├── services/         # API HTTP con Axios (api.ts, productService.ts)
├── store/            # Estado global con Zustand (cartStore.ts)
├── types/            # Interfaces TypeScript globales
└── utils/            # Funciones utilitarias (formatPrice, etc.)
```

## 🛠️ Instalación y Uso

1. **Instalar dependencias:**
   ```bash
   npm install
   ```

2. **Servidor de desarrollo:**
   ```bash
   npm run dev
   ```
   Abre [http://localhost:5173](http://localhost:5173/) en tu navegador.

3. **Construir para producción (Build):**
   ```bash
   npm run build
   ```

4. **Previsualizar producción:**
   ```bash
   npm run preview
   ```

## 🎨 Decisiones de Diseño
- **Colores:** Se definió una paleta personalizada en `tailwind.config.js` (`primary` verdes para ahorro/confianza, `secondary` azules).
- **Tipografía:** Se usa *Poppins* (importada vía Google Fonts en `index.html`) para un aspecto moderno y limpio.
- **Componentes:** Todos agrupados por exportaciones de barril (`index.ts`) junto con aliases (`@components/`, `@store/`, etc.) mapeados en Vite y TypeScript.
