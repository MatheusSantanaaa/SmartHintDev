using System.Text.RegularExpressions;

namespace SmartHintDev.Domain.Core.Utils
{
    internal class CpfCnpjValidacao
    {
        public const int CpfMaxLength = 11;
        public const int CnpjMaxLength = 14;

        public static bool ValidarCnpjCpf(string cnpjCpf)
        {
            if (EhCpf(cnpjCpf)) return true;
            if (EhCnpj(cnpjCpf)) return true;

            return false;
        }

        public static bool EhCpf(string cpf)
        {
            if (cpf.Length != CpfMaxLength) return false;
            if (TemDigitosRepetidos(cpf)) return false;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            var regex = new Regex(@"^\d{11}$");
            if (!regex.IsMatch(cpf)) return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (var i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (var i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto;
            var a = cpf.EndsWith(digito);

            return a;
        }

        public static string FormatarCpf(string cpf)
        {
            string response = cpf.Trim();
            if (response.Length == CpfMaxLength) return response;

            response = response.Replace(".", string.Empty);
            response = response.Replace(".", string.Empty);
            response = response.Replace("-", string.Empty);

            return response;
        }

        private static bool TemDigitosRepetidos(string valor)
        {
            string[] numerosInvalidos =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            return numerosInvalidos.Contains(valor);
        }

        public static bool EhCnpj(string cnpj)
        {
            if (cnpj.Length != CnpjMaxLength) return false;
            if (TemDigitosRepetidosCnpj(cnpj)) return false;

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            var regex = new Regex(@"^\d{14}$");
            if (!regex.IsMatch(cnpj)) return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (var i = 0; i < 12; i++) soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (var i = 0; i < 13; i++) soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto;
            return cnpj.EndsWith(digito);
        }

        private static bool TemDigitosRepetidosCnpj(string valor)
        {
            string[] numerosInvalidos =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            return numerosInvalidos.Contains(valor);
        }
    }
}
