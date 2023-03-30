using Shooping.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class City//Pertenece a un estado
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]//Es como el usuario lo vera
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
        public string Name { get; set; }
        [JsonIgnore]//soluciona el problema de json en registre
        //Relacion con la clase States
        public State State { get; set; }
        public ICollection<User>Users { get; set; }
    }
}
