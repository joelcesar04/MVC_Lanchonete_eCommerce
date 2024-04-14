using System.ComponentModel.DataAnnotations;

namespace LanchesMac.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria.")]
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public ICollection<Lanche> Lanches { get; set; }
    }
}
