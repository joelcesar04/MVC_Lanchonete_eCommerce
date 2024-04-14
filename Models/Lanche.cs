using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }

        [Required(ErrorMessage = "Informe o nome do lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O nome do lanche deve ter entre 10 e 80 caracteres")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição sobre o lanche")]
        [MinLength(20, ErrorMessage = "A descrição deve ter no mínimo 20 caracteres")]
        [MaxLength(80, ErrorMessage = "A descrição deve ter no máximo 80 caracteres")]
        [Display(Name = "Descrição do Lanche")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Informe a descrição detalhada sobre o lanche.")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no mínimo 20 caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada deve ter no máximo 200 caracteres")]
        [Display(Name = "Descrição Detalhada do Lanche")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o valor do lanche.")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(1, 999.99, ErrorMessage = "O valor deve estar entre R$ 1,00 e R$ 999,99")]
        [Display(Name = "Valor")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O caminho da imagem deve ter no máximo 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O caminho da imagem deve ter no máximo 200 caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
