using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: CHECA QUE EL PUERTO DE SALIDA SEA EL CORRECTO
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7045/images/noimage.png"
            : $"https://shopping1curso.blob.core.windows.net/products/{ImageId}";

    }
}
