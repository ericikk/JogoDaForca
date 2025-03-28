namespace JogoDaForca.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> categorias = new Dictionary<string, string[]>
                {
                    { "Frutas", new string[] { "ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU", "CARAMBOLA", "CUPUACU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MACA", "MANGABA", "MANGA", "MARACUJA", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" } },
                    { "Animais", new string[] { "CACHORRO", "GATO", "ELEFANTE", "TIGRE", "LEAO", "GIRAFA", "ZEBRA", "MACACO", "CAVALO", "COELHO" } },
                    { "Países", new string[] { "BRASIL", "ARGENTINA", "CHILE", "URUGUAI", "PARAGUAI", "PERU", "BOLIVIA", "VENEZUELA", "COLOMBIA", "EQUADOR" } }
                };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Jogo da Forca");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Escolha uma categoria:");
                int index = 1;
                foreach (var categoria in categorias.Keys)
                {
                    Console.WriteLine($"{index}. {categoria}");
                    index++;
                }

                int escolhaCategoria = int.Parse(Console.ReadLine());
                string categoriaEscolhida = categorias.Keys.ElementAt(escolhaCategoria - 1);
                string[] palavras = categorias[categoriaEscolhida];

                Random geradorDeNumeros = new Random();
                int indicePalavraEscolhida = geradorDeNumeros.Next(palavras.Length);
                string palavraSecreta = palavras[indicePalavraEscolhida];

                char[] letrasSecretas = new char[palavraSecreta.Length];
                for (int caractere = 0; caractere < palavraSecreta.Length; caractere++)
                {
                    letrasSecretas[caractere] = '_';
                }

                int quantidadeErros = 0;
                bool jogadorEnforcou = false;
                bool jogadorAcertou = false;
                List<char> letrasChutadas = new List<char>();

                do
                {
                    string dicaDaPalavra = String.Join("", letrasSecretas);

                    Console.Clear();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("-------------------------------");

                    if (quantidadeErros == 0)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                    }
                    else if (quantidadeErros == 1)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                    }
                    else if (quantidadeErros == 2)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                    }
                    else if (quantidadeErros == 3)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |        /x\\      ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                    }
                    else if (quantidadeErros == 4)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |        /x\\      ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |        / \\      ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                    }
                    else if (quantidadeErros == 5)
                    {
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |        /x\\      ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |        / \\      ");
                        Console.WriteLine(" |        ---       ");
                        Console.WriteLine("_|____              ");
                    }

                    Console.WriteLine("Palavra Secreta: " + dicaDaPalavra);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Quantidade de Erros: " + quantidadeErros);
                    Console.WriteLine("Letras já chutadas: " + string.Join(", ", letrasChutadas));
                    Console.WriteLine("-------------------------------");

                    Console.Write("Digite uma letra ou uma palavra: ");
                    string entrada = Console.ReadLine().ToUpper();

                    if (entrada.Length == 1)
                    {
                        char chute = entrada[0];

                        if (letrasChutadas.Contains(chute))
                        {
                            Console.WriteLine("Você já chutou essa letra. Tente novamente.");
                            Console.ReadKey();
                            continue;
                        }

                        letrasChutadas.Add(chute);

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
                    }
                    else
                    {
                        if (entrada == palavraSecreta)
                        {
                            jogadorAcertou = true;
                        }
                        else
                        {
                            quantidadeErros++;
                        }
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
                        Console.Clear();
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Jogo da Forca");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/        |        ");
                        Console.WriteLine(" |         |        ");
                        Console.WriteLine(" |         o        ");
                        Console.WriteLine(" |        /x\\      ");
                        Console.WriteLine(" |         x        ");
                        Console.WriteLine(" |        / \\      ");
                        Console.WriteLine(" |        ---       ");
                        Console.WriteLine("_|____              ");
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
