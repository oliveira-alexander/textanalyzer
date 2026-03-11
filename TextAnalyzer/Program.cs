using TextAnalyzer.classes;

namespace TextAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.MostrarMenu();
            menu.ObterTextoOriginal();
            menu.Analisar();

            Console.WriteLine("\n\nPressione qualquer tecla para encerrar...");
            Console.ReadLine();
        }
    }
}
