using JerarquiaEmpleados.Web.Models;
using System.Net.Http.Json;

namespace JerarquiaEmpleados.Web.Services
{
    public class EmpleadoApiService : IEmpleadoApiService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmpleadoViewModel>> ObtenerArbolAsync()
        {
            var resultado = await _httpClient.GetFromJsonAsync<List<EmpleadoViewModel>>("api/empleados/arbol");
            return resultado ?? new List<EmpleadoViewModel>();
        }

        public async Task InsertarAsync(EmpleadoFormViewModel empleado)
        {
            var payload = new { empleado.Puesto, empleado.Nombre, empleado.CodigoJefe };
            var response = await _httpClient.PostAsJsonAsync("api/empleados", payload);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarAsync(int codigo, EmpleadoFormViewModel empleado)
        {
            var payload = new { empleado.Puesto, empleado.Nombre, empleado.CodigoJefe };
            var response = await _httpClient.PutAsJsonAsync($"api/empleados/{codigo}", payload);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarAsync(int codigo)
        {
            var response = await _httpClient.DeleteAsync($"api/empleados/{codigo}");
            response.EnsureSuccessStatusCode();
        }
    }
}