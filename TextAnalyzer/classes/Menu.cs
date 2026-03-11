using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.classes
{
    public class Menu
    {
        private string? _textoOriginal = String.Empty;
        private string _textoNormalizado = String.Empty;

        public void MostrarMenu() {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| Bem vindo-a ao Text Analyzer! |");
            Console.WriteLine("|                               |");
            Console.WriteLine("| Sistema criado para analisar  |");
            Console.WriteLine("| trechos de textos e apontar   |");
            Console.WriteLine("| informações relevantes dele.  |");
            Console.WriteLine("|                               |");
            Console.WriteLine("---------------------------------");
        }

        public void ObterTextoOriginal() {
            Console.WriteLine("Digite seu texto:");
            this._textoOriginal = (Console.ReadLine() ?? "").Trim();

            if (this._textoOriginal == String.Empty)
                throw new Exception("Não foi digitado texto, portanto o sistema será encerrado.");
        }

        public void Analisar() {
            Console.WriteLine("\n\nAguarde, analizando texto...\n\n");

            NormalizarTexto();
            ExibirDadosAnaliseGeral();
            ExibirDadosPalavrasMaiusculas();
            ExibirDadosPalavrasMinusculas();
            ExibirDadosNumeros();         
        }

        private void NormalizarTexto() {
            this._textoNormalizado = _textoOriginal.Replace(".", " ");
            this._textoNormalizado = this._textoNormalizado.Replace(",", " ");
        }

        private int ContarPalavras() {
            string[] palavras = this._textoNormalizado.Split(" ");
            return palavras.Count();
        }

        private int ContarCaracteres() {
            return this._textoNormalizado.Length;
        }

        private string[] ListarPalavras() {
            return this._textoNormalizado.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        private void ExibirDadosPalavrasMaiusculas() {
            Console.WriteLine("\n\nPalavras Maiúsculas:");

            List<string> palavrasMaiusculas = new();

            foreach (var palavra in ListarPalavras())
            {
                if (char.IsUpper(palavra[0]))
                    palavrasMaiusculas.Add(palavra);
            }

            Console.WriteLine($"\nQuantidade de palavras: {palavrasMaiusculas.Count()}");
            Console.WriteLine($"\nLista de palavras maiúsculas:");

            foreach (var palavraMaiuscula in palavrasMaiusculas)
            {
                Console.WriteLine($"  {palavraMaiuscula}");
            }
        }

        private void ExibirDadosPalavrasMinusculas() {
            Console.WriteLine("\n\nPalavras Minúsculas:");
            List<string> palavrasMinusculas = new();

            foreach (var palavra in ListarPalavras())
            {
                if (char.IsLower(palavra[0]))
                    palavrasMinusculas.Add(palavra);
            }

            Console.WriteLine($"\nQuantidade de palavras: {palavrasMinusculas.Count()}");
            Console.WriteLine($"\nLista de palavras minúsculas:");

            foreach (var palavraMinuscula in palavrasMinusculas)
            {
                Console.WriteLine($"  {palavraMinuscula}");
            }

        }

        private void ExibirDadosNumeros() {
            Console.WriteLine("\n\nNúmeros:");

            List<string> numeros = new();

            foreach (var palavra in ListarPalavras()) {
                if (char.IsNumber(palavra[0]))
                    numeros.Add(palavra);
            }

            Console.WriteLine($"\nQuantidade de números: {numeros.Count()}");
            Console.WriteLine($"\nLista de números:");

            foreach (var numero in numeros)
            {
                Console.WriteLine($"  {numero}");
            }
        }

        private void ExibirDadosAnaliseGeral() {
            Console.WriteLine("Análise do texto:\n");
            Console.WriteLine("Palavras\n");
            Console.WriteLine($"Quantidade de palavras: {ContarPalavras()} \n");
            Console.WriteLine("Lista de Palavras:");

            foreach (var palavra in ListarPalavras())
            {
                Console.WriteLine($"  {palavra}");
            }

            Console.WriteLine($"\nQuantidade de caracteres: {ContarCaracteres()}");
        }
    }
}
