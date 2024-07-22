namespace PrimerAvancePOO2.Entities
{
    public class Componentes
    {
    public Guid Id { get; set; }
    public string Name { get; set; }    
    public string Descripcion { get; set; }
    public int precio { get; set; } 

    public int cantidad { get; set; }   
   

/* ESTE ES LA RELACION ENTRE COMPONENTES Y PROVEEDOR*/
    public Guid? ProveedorId { get; set; }

    public  Proveedor? Proveedor { get; set; }

    }
}