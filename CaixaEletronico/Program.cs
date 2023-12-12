using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string usuarioCadastrado = "usuario";
        string salt = GerarSal(); 
        string senhaCadastrada = HashSenha("senha123", salt); 
        int saldo = 1000;

        Console.WriteLine("Bem-vindo ao Caixa Eletrônico!");

        if (AutenticarUsuario(usuarioCadastrado, senhaCadastrada, salt))
        {
            
            ExibirMenu(ref saldo);
        }
        else
        {
            Console.WriteLine("Usuário ou senha incorretos. Encerrando programa.");
        }
    }

    static bool AutenticarUsuario(string usuarioCadastrado, string senhaCadastrada, string salt)
    {
        Console.Write("Digite o usuário: ");
        string usuarioDigitado = Console.ReadLine();

        Console.Write("Digite a senha: ");
        string senhaDigitada = Console.ReadLine();

        
        string senhaDigitadaHash = HashSenha(senhaDigitada, salt);

        
        return usuarioDigitado == usuarioCadastrado && senhaDigitadaHash == senhaCadastrada;
    }

   
    static string GerarSal()
    {
        byte[] randomBytes = new byte[32];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(randomBytes);
        }
        return Convert.ToBase64String(randomBytes);
    }

  
    static string HashSenha(string senha, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] senhaComSal = Encoding.UTF8.GetBytes(senha + salt);
            byte[] hashBytes = sha256.ComputeHash(senhaComSal);
            return Convert.ToBase64String(hashBytes);
        }
    }

    static void ExibirMenu(ref int saldo)
    {
        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Consultar Saldo");
            Console.WriteLine("2 - Realizar Saque");
            Console.WriteLine("3 - Realizar Depósito");
            Console.WriteLine("4 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine($"Seu saldo atual é: R$ {saldo}");
                    break;

                case "2":
                    Console.Write("Digite o valor do saque: R$ ");
                    int saque = int.Parse(Console.ReadLine());

                    if (saque > saldo)
                    {
                        Console.WriteLine("Saldo insuficiente!");
                    }
                    else
                    {
                        saldo -= saque;
                        Console.WriteLine($"Saque de R$ {saque} realizado com sucesso. Saldo atual: R$ {saldo}");
                    }
                    break;

                case "3":
                    Console.Write("Digite o valor do depósito: R$ ");
                    int deposito = int.Parse(Console.ReadLine());

                    saldo += deposito;
                    Console.WriteLine($"Depósito de R$ {deposito} realizado com sucesso. Saldo atual: R$ {saldo}");
                    break;

                case "4":
                    Console.WriteLine("Obrigado por usar o Caixa Eletrônico. Volte sempre!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
