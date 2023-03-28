using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]//Es como el usuario lo vera
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
        public string Name { get; set; }
        //Relacion con la clase States
        public int StateId { get; set; }
    }
}

