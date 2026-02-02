**Estándares de codificación del proyecto**

**Estándares generales de codificación en C#**

- Use `var` solo cuando el tipo sea obvio; de lo contrario, use tipos explícitos.
- Mantenga la longitud de las líneas por debajo de 120 caracteres.
- Use una indentación consistente e incluya siempre llaves (`{}`), incluso en sentencias de una sola línea.
- Agrupe las directivas `using` colocando primero `System.*` y luego las demás en orden alfabético.

**Convenciones de nombres**

- Use **PascalCase** para nombres de componentes, clases, métodos y propiedades.
- Use **camelCase** para parámetros y variables locales.
- Prefije los campos privados con `_` (por ejemplo, `_userService`).
- Los archivos de componentes Blazor deben coincidir con el nombre de la clase del componente (por ejemplo, `MyComponent.razor` debe contener `MyComponent`).

**Buenas prácticas específicas de Blazor**

- Divida los componentes grandes en componentes hijos más pequeños y reutilizables.
- Use `@code { }` en lugar de `@functions { }`.
- Mantenga separados el marcado de la interfaz de usuario y la lógica en C# cuando la complejidad crezca (por ejemplo, use clases parciales).
- Evite modificar directamente los parámetros enlazados (`[Parameter]`) en componentes hijos.
- Use `EventCallback<T>` en lugar de `Action` o delegados personalizados para eventos de parámetros.
- Use `CascadingParameter` para pasar datos como el estado de autenticación, el tema o la cultura.
- Prefiera `OnInitializedAsync()` sobre `OnInitialized()` cuando use `await`.

**Buenas prácticas de rendimiento**

- Minimice los re-renderizados utilizando `ShouldRender()` o lógica condicional en la UI.
- Use `@key` en bucles `@foreach` para ayudar a Blazor a rastrear los elementos del DOM.
- Evite usar `async void`; utilice `async Task` en su lugar.
- Libere los recursos de los componentes implementando `IDisposable` cuando estos los utilicen.

Estructura de proyecto

- Usar un archivo app.css para el diseno general de pagina y estilos que se repitan
- Usar CSS con alcance (Scoped CSS) en componentes o pantallas cuando sea necesario ejemplo tienen un diseno que no se repite
- Implementar States para modelos fuertes basados en DDD
- Cada pantalla se debe construir en componentes pequenos y reuzables
