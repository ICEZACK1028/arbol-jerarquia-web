namespace JerarquiaEmpleados.Web.Models
{
    public class EmpleadoViewModel
    {
        public int Codigo { get; set; }
        public string Puesto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? CodigoJefe { get; set; }
        public int Nivel { get; set; }
        public string? Ruta { get; set; }

        // amra el árbol en memoria 
        public List<EmpleadoViewModel> Hijos { get; set; } = new();
    }
}