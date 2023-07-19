using SmartHintDev.Domain.Core;
using SmartHintDev.Domain.Enum;

namespace SmartHintDev.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Bloqueado { get; set; }
        public string Senha { get; set; }

        public Cliente(string nome,
                       string email,
                       string telefone,
                       TipoPessoa tipoPessoa,
                       string cpfCnpj,
                       string inscricaoEstadual,
                       bool isento,
                       Genero genero,
                       DateTime dataNascimento,
                       string senha)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataCriacao = DateTime.Now;
            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            Isento = isento;
            Genero = genero;
            DataNascimento = dataNascimento;
            Bloqueado = false;
            Senha = senha;
        }

        public Cliente(string? nome, DateTime? dataCriacao, string? email, bool? bloqueado, string? telefone)
        {
            Nome= nome ?? "";
            Email = email ?? "";
            Telefone = telefone ?? "";
            DataCriacao = dataCriacao != null ? dataCriacao.Value : DateTime.MinValue;
            Bloqueado= bloqueado.GetValueOrDefault();
        }

        public void Atualizar(string nome,
                      string email,
                      string telefone,
                      TipoPessoa tipoPessoa,
                      string cpfCnpj,
                      string inscricaoEstadual,
                      bool isento,
                      Genero genero,
                      DateTime dataNascimento,
                      bool bloqueado,
                      string senha)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            Isento = isento;
            Genero = genero;
            DataNascimento = dataNascimento;
            Bloqueado = bloqueado;
            Senha = senha;
        }
    }
}
