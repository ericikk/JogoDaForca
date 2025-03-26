namespace JogoDaForca.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string palavraSecreta = "MELANCIA";
                char[] letrasSecretas = new char[palavraSecreta.Length];

                for (int caractere = 0; caractere < palavraSecreta.Length; caractere++)
                {
                    letrasSecretas[caractere] = '_';
                }

                int quantidadeErros = 0;
                bool jogadorEnforcou = false;
                bool jogadorAcertou = false;

                do
                {
                    string dicaDaPalavra = String.Join("", letrasSecretas);

                    Console.Clear();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Palavra Secreta: " + dicaDaPalavra);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Quantidade de Erros: " + quantidadeErros);
                    Console.WriteLine("-------------------------------");

                    Console.Write("Digite uma letra: ");
                    char chute = Console.ReadLine()[0];

                    bool letraEncontrada = false;

                    for (int contador = 0; contador < palavraSecreta.Length; contador++)
                    {
                        char letraAtual = palavraSecreta[contador];
                        if (chute == letraAtual)
                        {
                            letrasSecretas[contador] = letraAtual;
                            letraEncontrada = true;
                        }
                    }

                    if (!letraEncontrada)
                    {
                        quantidadeErros++;
                    }

                    dicaDaPalavra = String.Join("", letrasSecretas);

                    jogadorAcertou = dicaDaPalavra == palavraSecreta;
                    jogadorEnforcou = quantidadeErros > 5;

                    if (jogadorAcertou)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Você acertou a palavra secreta!! A palavra era: " + palavraSecreta);
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    else if (jogadorEnforcou)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Você errou! Tente novamente. A palavra era: " + palavraSecreta);
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }

                } while (!jogadorAcertou && !jogadorEnforcou);
            }
        }
    }
}
