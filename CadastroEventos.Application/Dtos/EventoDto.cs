using System.ComponentModel.DataAnnotations;

namespace CadastroEventos.Application.Dtos
{
    public class EventoDto 
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            // MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo 4 caracteres."),
            // MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo 50 caracteres.")
            StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres." )
        ]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Quantidade de Pessoas")]
        [Range(1, 1200, ErrorMessage = "A {0} deve ser maior que 1 e menor que 1200.")]
        public int QtdePessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", 
        ErrorMessage = "Não é uma imagem válida. (gif, jpeg, jpg, png, bmp)")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Phone(ErrorMessage = "O {0} deve ser um telefone válido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "é necessário um {0} válido.")]
        public string Email { get; set; }
    }
}