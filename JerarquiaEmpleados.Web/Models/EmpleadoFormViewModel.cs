namespace JerarquiaEmpleados.Web.Models
{
    public class EmpleadoFormViewModel
    {
        public int Codigo { get; set; }
        public string Puesto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? CodigoJefe { get; set; }

        // <select> del jefe
        public List<EmpleadoViewModel> EmpleadosDisponibles { get; set; } = new();
    }
}