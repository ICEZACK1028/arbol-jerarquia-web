using JerarquiaEmpleados.Web.Models;
using JerarquiaEmpleados.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace JerarquiaEmpleados.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoApiService _apiService;

        public EmpleadosController(IEmpleadoApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Empleados
        public async Task<IActionResult> Index()
        {
            var lista = await _apiService.ObtenerArbolAsync();
            var arbol = ConstruirArbol(lista);
            return View(arbol);
        }

        // GET: /Empleados/Crear
        public async Task<IActionResult> Crear()
        {
            var modelo = new EmpleadoFormViewModel
            {
                EmpleadosDisponibles = await _apiService.ObtenerArbolAsync()
            };
            return View(modelo);
        }

        // POST: /Empleados/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(EmpleadoFormViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                modelo.EmpleadosDisponibles = await _apiService.ObtenerArbolAsync();
                return View(modelo);
            }

            try
            {
                await _apiService.InsertarAsync(modelo);
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"error al crear el empleado: {ex.Message}");
                modelo.EmpleadosDisponibles = await _apiService.ObtenerArbolAsync();
                return View(modelo);
            }
        }

        // GET: /Empleados/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var lista = await _apiService.ObtenerArbolAsync();
            var empleado = lista.FirstOrDefault(e => e.Codigo == id);

            if (empleado == null)
            {
                return NotFound();
            }

            var modelo = new EmpleadoFormViewModel
            {
                Codigo = empleado.Codigo,
                Puesto = empleado.Puesto,   
                Nombre = empleado.Nombre,
                CodigoJefe = empleado.CodigoJefe,
                EmpleadosDisponibles = lista.Where(e => e.Codigo != id).ToList()
            };

            return View(modelo);
        }

        // POST: /Empleados/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, EmpleadoFormViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                modelo.EmpleadosDisponibles = (await _apiService.ObtenerArbolAsync())
                    .Where(e => e.Codigo != id).ToList();
                return View(modelo);
            }

            try
            {
                await _apiService.ActualizarAsync(id, modelo);
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al actualizar - {ex.Message}");
                modelo.EmpleadosDisponibles = (await _apiService.ObtenerArbolAsync())
                    .Where(e => e.Codigo != id).ToList();
                return View(modelo);
            }
        }

        // POST: /Empleados/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _apiService.EliminarAsync(id);
            }
            catch (HttpRequestException ex)
            {
                TempData["Error"] = $"Error al eliminar - {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // construye la lista plana en un árobl
        private List<EmpleadoViewModel> ConstruirArbol(List<EmpleadoViewModel> lista)
        {
            var diccionario = lista.ToDictionary(e => e.Codigo);
            var raices = new List<EmpleadoViewModel>();

            foreach (var empleado in lista)
            {
                if (empleado.CodigoJefe.HasValue && diccionario.TryGetValue(empleado.CodigoJefe.Value, out var jefe))
                {
                    jefe.Hijos.Add(empleado);
                }
                else
                {
                    raices.Add(empleado);
                }
            }

            return raices;
        }
    }
}