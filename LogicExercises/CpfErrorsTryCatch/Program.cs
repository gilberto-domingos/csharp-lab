using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite seu CPF: ");
        string cpf = Console.ReadLine();

        if (IsCpfValid(cpf, out string message))
        {
            Console.WriteLine($"CPF {cpf} é válido!");
        }
        else
        {
            Console.WriteLine($"CPF inválido: {message}");
        }

        Console.WriteLine("\nPressione qualquer tecla para encerrar...");
        Console.ReadKey();
    }

    public static bool IsCpfValid(string cpf, out string message)
    {
        message = string.Empty;

        try
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                message = "CPF não pode estar vazio.";
                return false;
            }

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                message = "CPF deve conter 11 dígitos.";
                return false;
            }

            if (new string(cpf[0], cpf.Length) == cpf)
            {
                message = "CPF com todos os dígitos iguais é inválido.";
                return false;
            }

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(tempCpf[i]))
                {
                    message = "CPF deve conter apenas números.";
                    return false;
                }

                soma += (tempCpf[i] - '0') * multiplicador1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            tempCpf += digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                if (!char.IsDigit(tempCpf[i]))
                {
                    message = "CPF deve conter apenas números.";
                    return false;
                }

                soma += (tempCpf[i] - '0') * multiplicador2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            bool valido = cpf.EndsWith(digito);

            if (!valido)
                message = "Dígitos verificadores não conferem.";

            return valido;
        }
        catch (Exception ex)
        {
            message = $"Erro inesperado ao validar o CPF: {ex.Message}";
            return false;
        }
    }
}
