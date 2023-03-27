using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entities
{
    //Esta clase se copnvierte en una tabla en la base de datos
    public class Country
    {
        public int Id { get; set; }
        [Display (Name = "Pais")]//Es como el usuario lo vera
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage ="El campo (0) es obligatorio.")]//Validacion de que el nombre no sea null
        public string Name { get; set; }
        //Relacion con la clase States
        public ICollection <State> States { get; set; }
        //Ejemplo de propiedad de lectura la cual regresara el numero de estados ect
        [Display(Name = "Departamentos/Estados")]
        public int StatesNumber => States == null ? 0 : States.Count;//no se mapea en la base de datos la calcula el modelo, se valida con un operador ternario para que no truene el programa


    }
}
