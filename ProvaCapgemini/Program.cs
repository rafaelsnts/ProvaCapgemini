using System;
using System.Text.RegularExpressions;

namespace ProvaCapgemini
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int opcao = 0;
            Console.WriteLine("Qual questao voce gostaria de ver?");
            Console.WriteLine("Primeira questão, Digite 1");
            Console.WriteLine("Segunda questão, Digite 2");
            Console.WriteLine("Terceira questão, Digite 3");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite um numero:");
                    Questao01(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 2:
                    Console.WriteLine("Digite sua senha: ");
                    Questao02(Console.ReadLine());
                    break;

                case 3:
                    Console.WriteLine("[QUESTAO INCOMPLETA] Digite uma palavra qualquer");
                    Questao03(Console.ReadLine());
                    break;
            }
        }

        public static void Questao01(int _entrada)
        {
            int contador = _entrada - 1;

            for (int i = 0; i < _entrada; i++)
            {
                //Loop que print os espacos vazios e os asteriscos no final da string
                for (int j = 0; j < _entrada; j++)
                {
                    if (j < contador)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();

                //Remove a casa decimal do asteriscos, ou seja, se no primeiro loop
                //ele entrava na ultima casa, no proximo ele entra na penultima
                //e no proximo na antepenultima e por ai vai..
                contador--;
            }
        }

        public static void Questao02(string _senha)
        {
            char[] _senhaQuebrada = _senha.ToCharArray();

            bool val_Caracter = false;
            bool val_Digitos = false;
            bool val_Minuscula = false;
            bool val_Maiuscula = false;
            bool val_Especial = false;

            //Validacao 6 caracter
            if (_senhaQuebrada.Length >= 6)
            {
                val_Caracter = true;
            }

            //Validacao de 1 digito
            for (int i = 0; i < _senhaQuebrada.Length; i++)
            {
                if (Char.IsDigit(_senhaQuebrada[i]))
                {
                    val_Digitos = true;
                }
            }

            //Validacao de 1 minuscula
            for (int i = 0; i < _senhaQuebrada.Length; i++)
            {
                if (Char.IsLetter(_senhaQuebrada[i]))
                {
                    if (_senhaQuebrada[i].ToString() == _senhaQuebrada[i].ToString().ToLower())
                    {
                        val_Minuscula = true;
                    }
                }
            }

            //Validacao de 1 maiuscula
            for (int i = 0; i < _senhaQuebrada.Length; i++)
            {
                if (Char.IsLetter(_senhaQuebrada[i]))
                {
                    if (_senhaQuebrada[i].ToString() == _senhaQuebrada[i].ToString().ToUpper())
                    {
                        val_Maiuscula = true;
                    }
                }
            }

            //Validacao do caracter especial !@#$%^&*()-+
            for (int i = 0; i < _senhaQuebrada.Length; i++)
            {
                if (_senhaQuebrada[i].ToString().Contains('!') || _senhaQuebrada[i].ToString().Contains('@') ||
                    _senhaQuebrada[i].ToString().Contains('#') || _senhaQuebrada[i].ToString().Contains('$') ||
                    _senhaQuebrada[i].ToString().Contains('%') || _senhaQuebrada[i].ToString().Contains('^') ||
                    _senhaQuebrada[i].ToString().Contains('&') || _senhaQuebrada[i].ToString().Contains('*') ||
                    _senhaQuebrada[i].ToString().Contains('(') || _senhaQuebrada[i].ToString().Contains(')') ||
                    _senhaQuebrada[i].ToString().Contains('-') || _senhaQuebrada[i].ToString().Contains('+'))
                {
                    val_Especial = true;
                }
            }

            if (val_Caracter == false || val_Digitos == false || val_Minuscula == false
                || val_Maiuscula == false || val_Especial == false)
            {
                string validado = val_Caracter ? "Validado" : "Nao Validado";
                Console.Write($"Validacao de Caracter: {validado}");

                if (!(_senha.Length >= 6))
                {
                    Console.Write($" - faltam {6 - _senha.Length} digitos para senha forte");
                }

                Console.WriteLine();
                validado = val_Digitos ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Digitos: {validado}");

                validado = val_Minuscula ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Minuscula: {validado}");

                validado = val_Maiuscula ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Maiuscula: {validado}");

                validado = val_Especial ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de C.Especial: {validado}");
            }
            else
            {
                Console.WriteLine("Senha perfeita!");
            }
        }

        public static void Questao03(string _palavra)
        {
            //Anagramas
            //Achar as letras iguais
            char[] palavraQuebrada = _palavra.ToCharArray();
            char[] letrasIguais = new char[_palavra.Length];
            int cont_letrasIguais = 0;

            for (int i = 1; i < palavraQuebrada.Length; i++)
            {
                if (palavraQuebrada[i] == ' ')
                {
                    break;
                }
                for (int j = 0; j < palavraQuebrada.Length; j++)
                {
                    if (i != j)
                    {
                        if (palavraQuebrada[i].Equals(palavraQuebrada[j]))
                        {
                            letrasIguais[cont_letrasIguais] = palavraQuebrada[i];
                            cont_letrasIguais++;
                            palavraQuebrada[i] = ' ';
                            palavraQuebrada[j] = ' ';
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Letras iguais: ");
            for (int i = 0; i < letrasIguais.Length; i++)
            {
                Console.WriteLine($"{letrasIguais[i]}");
            }
            Console.ReadLine();

            // Não terminei a terceira questão.
        }
    }
}