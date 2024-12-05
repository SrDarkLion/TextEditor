using System;
using System.Threading;
using System.IO;


namespace TextEditor
{
    class Program
    {
        static void Main(string[] args) {
            Menu();
        }

        static void Menu() {
            Console.Clear();

            Console.WriteLine("Olá, o que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("3 - Sair");

            
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && short.TryParse(input, out short option)) {
         
            switch (option) {
                case 1:
                    Abrir();
                break;
                case 2:
                    Editar();
                break;
                case 3:
                    Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1000);
                    Menu();
                break;
            }
            }

            static void Abrir() {
                Console.Clear();

                Console.WriteLine("Qual é o caminho do arquivo?");
                string path = Console.ReadLine();

                using(var file = new StreamReader(path)) {
                    string text = file.ReadToEnd();
                    Console.Clear();
                    Console.WriteLine(text);
                }

                Console.WriteLine("");
                Console.ReadLine();
                Menu();
            }

            static void Editar() {

                
                Console.Clear();

                Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
                Console.WriteLine("<---------------------------------->");
                string text = "";

                do
                {
                    text += Console.ReadLine();
                    text += Environment.NewLine;

                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Salvar(text);
            }
            
            static void Salvar(string text) {
                Console.Clear();
                Console.WriteLine("Qual caminho deseja salvar seu arquivo?");

                var path = Console.ReadLine();

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Caminho inválido. Por favor, tente novamente.");
                    return; // Retorna ao menu ou interrompe o método
                }

                using(var file = new StreamWriter(path)) {
                    file.Write(text);
                }

                Console.WriteLine($"Aquivo {path} salvo com sucesso!");
                Console.ReadLine();
                Menu();
            }
        }
    }
}