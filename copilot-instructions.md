Estándares de codificación del proyecto
Este documento define reglas obligatorias de arquitectura, estilo y diseño para todo el código generado o modificado en el proyecto.
Copilot Chat debe seguir estas reglas estrictamente.
Estándares generales de codificación en C#
Use var solo cuando el tipo sea obvio por el lado derecho de la asignación; de lo contrario, use tipos explícitos.
Mantenga la longitud de las líneas por debajo de 120 caracteres.
Use una indentación consistente e incluya siempre llaves ({}), incluso en sentencias de una sola línea.
Agrupe las directivas using colocando primero System.* y luego las demás en orden alfabético.
Evite clases, métodos o propiedades excesivamente grandes; prefiera composición sobre tamaño.
El código debe priorizar legibilidad y claridad sobre “optimización prematura”.
Convenciones de nombres
Use PascalCase para:
Componentes Blazor
Clases
Métodos
Propiedades
Use camelCase para:
Parámetros
Variables locales
Prefije los campos privados con _ (por ejemplo, _userService).
Los archivos de componentes Blazor deben coincidir exactamente con el nombre de la clase del componente
(ejemplo: CategoryModal.razor → CategoryModal).
Los nombres de States, Services y Coordinators DEBEN reflejar el modelo fuerte o feature que representan
(ejemplo: CategoryState, CategoryCoordinator, ICategoryService).
Buenas prácticas específicas de Blazor
Divida los componentes grandes en componentes hijos pequeños, reutilizables y enfocados exclusivamente en UI.
Use @code { } en lugar de @functions { }.
Cuando la complejidad aumente, separe el marcado y la lógica usando clases parciales (.razor + .razor.cs).
Los componentes Blazor (incluyendo modals) NUNCA deben contener lógica de negocio.
Los componentes NUNCA deben inyectar ni llamar Services, Repositories o APIs.
Evite modificar directamente los parámetros enlazados ([Parameter]) dentro de componentes hijos.
Todos los eventos expuestos por componentes DEBEN usar EventCallback o EventCallback<T>.
NO usar Action, Func<T> ni delegados personalizados en parámetros.
Use CascadingParameter únicamente para estado transversal (autenticación, tema, cultura).
Prefiera OnInitializedAsync() sobre OnInitialized() cuando se utilicen operaciones asincrónicas.
Los componentes NO deben navegar ni usar NavigationManager.
Buenas prácticas de State Management
Implemente State Containers para cada modelo o entidad fuerte (según DDD).
NO crear un AppState global con múltiples modelos.
Cada modelo fuerte DEBE tener su propio State independiente.
Un State representa el estado de la UI, no el dominio ni la entidad persistente.
Un State puede contener:
DTOs o ViewModels
Flags de UI (IsLoading, IsSaving, HasError)
Un State NO debe:
Contener entidades de dominio
Contener modelos de EF
Llamar servicios
Conocer la UI
Contener lógica de negocio
Cada componente debe depender idealmente de un solo State.
La UI NUNCA debe mutar el State directamente.
NO usar INotifyPropertyChanged en States.
Pantallas, componentes y coordinators
Las pantallas (Pages) actúan como orquestadores de casos de uso.
Las Pages pueden:
Llamar Services o Coordinators
Coordinar múltiples componentes
Manejar flujos (guardar, cerrar modal, refrescar datos)
Las Pages NO deben contener lógica condicional compleja ni bloques extensos de try/catch.
Cuando una Page:
Maneja más de un caso de uso
Coordina loaders y errores
Tiene lógica de flujo compleja
DEBE extraerse esa lógica a un Coordinator.
Los Coordinators:
Orquestan Services + State
Manejan loaders, errores y flujos
NO renderizan UI
NO dependen de componentes
Buenas prácticas de loaders
Los loaders representan transiciones de estado, no efectos visuales.
Use el tipo de loader según su alcance:
Global Loader: bloquea toda la aplicación
Page Loader: bloquea una pantalla
Component / Section Loader: bloquea una sección específica
Action / Button Loader: bloquea una acción puntual
NO usar un solo IsLoading para toda la aplicación.
Los loaders NO deben ser gestionados dentro de componentes reutilizables.
El estado de carga DEBE vivir en el State o ser controlado por un Coordinator.
Buenas prácticas de rendimiento
Minimice re-renderizados dividiendo la UI en componentes pequeños y específicos.
Use @key en bucles @foreach para ayudar a Blazor a rastrear correctamente los elementos del DOM.
Evite async void; utilice siempre async Task.
La desuscripción a eventos debe ser automática mediante una clase base; los componentes no deben manejar Dispose.
No abuse de ShouldRender(); prefiera una arquitectura de componentes correcta.
Estructura del proyecto
Use app.css para estilos globales y reutilizables.
Use Scoped CSS (Component.razor.css) cuando el diseño sea específico y no reutilizable.
Organice el código por feature o modelo fuerte, no por tipo técnico.
Ejemplo:
/Category
  CategoryPage.razor
  /Components
    CategoryModal.razor
    CategoryList.razor
  CategoryState.cs
  CategoryCoordinator.cs
​
Cada pantalla debe construirse a partir de componentes pequeños y reutilizables.
Cree carpetas por modelo fuerte (Order, Category, User, etc.).
CQRS
Se permite usar CQRS simple (Commands y Queries separados).
No mezcle lógica de lectura y escritura en el mismo flujo.
Evite sobre-ingeniería; CQRS debe ser pragmático.
Restricciones explícitas (OBLIGATORIAS)
NO usar CancellationToken ni incluirlo en la definición de métodos.
Copilot NO debe sugerir CancellationToken bajo ninguna circunstancia.
NO llamar servicios desde componentes reutilizables o modals.
NO implementar lógica de negocio en la UI.
NO usar INotifyPropertyChanged.
NO crear un AppState global.
Reglas críticas (Copilot Chat)
Estas reglas son innegociables:
Components are UI-only.
Components never call services, APIs or repositories.
Pages orchestrate use cases.
Coordinators handle complex flows.
One State per strong model.
States represent UI state, not domain.
No navigation inside components.
No CancellationToken.
No INotifyPropertyChanged.
Regla final
La complejidad debe vivir en la infraestructura y la capa de aplicación, nunca en los componentes.
