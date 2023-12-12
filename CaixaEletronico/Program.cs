using System;

class Program
{
    static void Main()
    {
        int saldo = 1000;  
        
        Console.WriteLine("Bem-vindo ao Caixa Eletrônico!");

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
