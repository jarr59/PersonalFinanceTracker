namespace FinanceTracker.Web.Services.Categories
{
    public interface ICategoryServices
    {
        /// <summary>
        /// Crea una nueva categoría con el nombre, color e icono especificados. Lo agrega al estado de categorías para que la UI se actualice automáticamente.
        /// </summary>
        Task CreateCategoryAsync(string name, string colorHex, string iconSource);

        /// <summary>
        /// Actualiza una categoría existente con el id especificado, cambiando su nombre, color e icono. Luego actualiza el estado de categorías para reflejar los cambios en la UI.
        /// </summary>
        Task UpdateCategoryAsync(Guid id, string name, string colorHex, string iconSource);

        /// <summary>
        /// Carga todas las categorías desde el repositorio y las agrega al estado de categorías. Esto se utiliza para inicializar la lista de categorías en la UI.
        /// </summary>
        /// <returns></returns>
        Task LoadAllCategories();

        /// <summary>
        /// Elimina una categoría del estado de categorías utilizando su id. 
        /// </summary>
        /// Implementa el comando de eliminación en la capa de aplicación y lo ejecuta.
        Task DeleteCategoryAsync(Guid id);
    }
}
