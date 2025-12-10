# 📄 Requerimientos del Cliente – Personal Finance Tracker (API)

## 1. Descripción General
El cliente necesita una API que permita gestionar finanzas personales mediante el registro de ingresos, gastos, categorías y la visualización de estadísticas.  
El objetivo es ofrecer un sistema simple, seguro y accesible desde aplicaciones móviles o web.

---

## 2. Requerimientos Funcionales

### 2.1 Gestión de Usuarios
- **RF01:** El sistema debe permitir la creación de una cuenta usando email y contraseña.
- **RF02:** El usuario debe poder iniciar sesión de forma segura.
- **RF03:** Cada usuario debe acceder únicamente a sus propios datos (transacciones, categorías, estadísticas).

---

### 2.2 Gestión de Transacciones
- **RF04:** Registrar transacciones de tipo *ingreso* o *gasto*.
- **RF05:** Cada transacción debe incluir: monto, fecha, tipo, categoría y descripción.
- **RF06:** El usuario debe poder editar transacciones existentes.
- **RF07:** El usuario debe poder eliminar transacciones.
- **RF08:** Consultar un listado de todas sus transacciones.
- **RF09:** Filtrar transacciones por fecha, tipo o categoría.

---

### 2.3 Gestión de Categorías
- **RF10:** Crear categorías personalizadas (ej.: “Supermercado”, “Salario”, “Transporte”).
- **RF11:** Las categorías deben tener un tipo: *income* o *expense*.
- **RF12:** Consultar todas las categorías creadas por el usuario.

---

### 2.4 Estadísticas
- **RF13:** Visualizar el balance actual (ingresos totales - gastos totales).
- **RF14:** Ver ingresos y gastos de un período específico (mensual, semanal o rango de fechas).
- **RF15:** Ver resumen del gasto por categoría.
- **RF16:** (Opcional) Ver tendencias mensuales de ingresos y gastos.

---

## 3. Requerimientos No Funcionales

### 3.1 Seguridad
- **RNF01:** Las contraseñas deben almacenarse encriptadas.
- **RNF02:** El sistema debe utilizar autenticación segura (tokens, JWT o similar).

### 3.2 Rendimiento
- **RNF03:** La API debe responder rápidamente y mantener buena performance bajo carga moderada.
- **RNF04:** El sistema debe soportar múltiples usuarios concurrentes.

### 3.3 Accesibilidad
- **RNF05:** La API debe ser consumible fácilmente desde aplicaciones móviles o web mediante JSON.

### 3.4 Mantenibilidad
- **RNF06:** La arquitectura del sistema debe ser clara y escalable para futuras mejoras.
- **RNF07:** El código debe permitir agregar nuevas funcionalidades sin reescribir componentes principales.

---

## 4. Criterios de Aceptación
- **CA01:** El usuario puede registrarse e iniciar sesión sin errores.
- **CA02:** Al crear una transacción, aparece inmediatamente en el sistema.
- **CA03:** Los cambios realizados en una transacción (editar/eliminar) se reflejan correctamente.
- **CA04:** El balance se actualiza correctamente según las operaciones registradas.
- **CA05:** Los filtros de transacciones (categoría, tipo, fecha) funcionan correctamente.
- **CA06:** Las estadísticas coinciden con los datos ingresados por el usuario.

---
- Compartir datos con otros usuarios.
- Integración con bancos o servicios financieros.
