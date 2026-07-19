using JerarquiaEmpleados.Web.Models;

namespace JerarquiaEmpleados.Web.Services
{
    public interface IEmpleadoApiService
    {
        Task<List<EmpleadoViewModel>> ObtenerArbolAsync();
        Task InsertarAsync(EmpleadoFormViewModel empleado);
        Task ActualizarAsync(int codigo, EmpleadoFormViewModel empleado);
        Task EliminarAsync(int codigo);
    }
}