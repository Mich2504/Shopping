using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Departamento/Estado")]//Es como el usuario lo vera
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
        public string Name { get; set; }
        //Para agregar un estado se necesita saber de que pais es
        public int CountryId { get; set; }
    }
}
