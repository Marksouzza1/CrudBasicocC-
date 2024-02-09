
using System.ComponentModel.DataAnnotations;
namespace Crud.Domain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public Cliente(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
        }
    }

}
