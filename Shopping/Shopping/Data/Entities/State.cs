using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class State
    {
            public int Id { get; set; }
            [Display(Name = "Departamento/Estado")]//Es como el usuario lo vera
            [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
            [Required(ErrorMessage = "El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
            public string Name { get; set; }
        [JsonIgnore]//con esta linea de codigo se soluciona el problema de json en registre
        public Country Country { get; set; }
        //Tiene una lista de ciudades (Relacion con la clase City.cs)
        public ICollection<City> Cities{ get; set; }
        //Propiedad de lectura
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
    
}

