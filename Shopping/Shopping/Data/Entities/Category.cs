using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entities
{
    public class Category
    {//hay que mapear la bd en la clase DataContext
        public int Id { get; set; }
        [Display(Name = "Categoria")]//Es como el usuario lo vera
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
        public string Name { get; set; }
    }
}
