# PersonalFinanceTracker
Aplicacion simple para llevar un seguimiento de las finanzas

📄 REQUERIMIENTOS DEL CLIENTE – Personal Finance Tracker (API)
🧩 1. Descripción general

Como cliente, necesito una API sencilla pero completa que me permita gestionar mis finanzas personales.
Quiero poder registrar mis ingresos y gastos, clasificarlos por categorías y visualizar resúmenes claros que me permitan entender mi situación financiera.

🧑‍💼 2. Requerimientos funcionales
🔐 2.1 Gestión de usuarios

El sistema debe permitirme crear una cuenta con email y contraseña.

Debo poder iniciar sesión y mantenerme autenticado de forma segura.

Solo yo debo poder ver mis transacciones, categorías y estadísticas.

💸 2.2 Gestión de transacciones

Quiero poder registrar ingresos y gastos.

Cada transacción debe tener: monto, fecha, tipo (ingreso/gasto), categoría y descripción.

Necesito poder editar una transacción si me equivoco.

También debo poder eliminar transacciones.

Necesito ver un listado completo de todas mis transacciones.

Debo poder filtrar transacciones por fecha, tipo o categoría.

🏷️ 2.3 Gestión de categorías

Debo poder crear mis propias categorías (ejemplo: “Supermercado”, “Salario”, “Transporte”).

Cada categoría debe indicar si es para ingresos o gastos.

Debo poder ver la lista de todas mis categorías.

📊 2.4 Estadísticas

Quiero ver mi balance actual (ingresos - gastos).

Quiero ver cuánto gasté o gané en un período (mensual, semanal o personalizado).

Necesito ver cuánto gasté por categoría.

Opcionalmente, me gustaría ver tendencias mensuales.

🏗️ 3. Requerimientos no funcionales
🔒 Seguridad

Mis datos deben estar protegidos y mi contraseña encriptada.

El sistema debe usar un método seguro de autenticación (por ejemplo, tokens).

⚡ Rendimiento

La API debe responder de forma rápida y estable.

Debe poder manejar varios usuarios sin que el rendimiento se degrade.

📱 Accesibilidad

La API debe poder ser consumida fácilmente por una app móvil o web.

🛠️ Mantenibilidad

Quiero que el sistema esté bien estructurado para que sea fácil agregar funciones en el futuro.

🧪 4. Criterios de aceptación

Puedo registrarme e iniciar sesión sin errores.

Puedo registrar una transacción y verla inmediatamente en mi lista.

Si elimino o edito una transacción, los cambios deben verse reflejados.

El balance debe actualizarse correctamente.

Los filtros deben funcionar (por categoría, tipo o fechas).

Las estadísticas deben coincidir con los datos registrados.
