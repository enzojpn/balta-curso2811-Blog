
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{


    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage ="o campo nome é obrigatório!")]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

    }
}