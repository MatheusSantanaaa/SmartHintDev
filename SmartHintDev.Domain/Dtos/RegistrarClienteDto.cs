using SmartHintDev.Domain.Enum;

namespace SmartHintDev.Domain.Dtos
{
    public class RegistrarClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
