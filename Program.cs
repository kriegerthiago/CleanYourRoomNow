internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Go Clean your room!Now!!!");
        Console.WriteLine("Press 1 - Select folder // 2 - Exit");

        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
        {
            Console.WriteLine("");
            Console.WriteLine("Cole o diretório da pasta raíz que queira organizar.");

            string toCLeanFolder = Console.ReadLine();
            Console.WriteLine("Diretório: " + toCLeanFolder);

            if (!Directory.Exists(toCLeanFolder))
            {
                Console.WriteLine("Este diretório não existe, tente novamente");
            }
            else
            {
                string[] arquivos = Directory.GetFiles(toCLeanFolder);
                int arquivosLenght = arquivos.Length;
                int arquivosProcessados = 0;

                foreach (var file in arquivos)
                {
                    string extensao = Path.GetExtension(file).Replace(".", "").ToUpper();
                    string extensaoFolder = Path.Combine(toCLeanFolder, extensao);
                    if (!Directory.Exists(extensaoFolder))
                    {
                        Directory.CreateDirectory(extensaoFolder);
                    }

                    string nome = Path.GetFileName(file);
                    string novoPath = Path.Combine(extensaoFolder, nome);
                    File.Move(file, novoPath);
                    arquivosProcessados++;

                    double progresso = (double)arquivosProcessados / arquivosLenght * 100;

                    Console.WriteLine($"\rProgresso: {progresso}%");
                    Thread.Sleep(500);
                }
                Console.WriteLine("Organização Concluída. Quarto Arrumado.");
            }
        }
        else
        {
            Console.WriteLine("Programa Desligado.");
        }
    }
}