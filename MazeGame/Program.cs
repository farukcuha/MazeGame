namespace MazeGame
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                initializer:;
                Console.Clear();
                printHeader();
                Console.WriteLine("Labirentin nasıl oluşturulacağını giriniz:");
                Console.WriteLine("Dosyadan okumak için D tuşuna basınız.");
                Console.WriteLine("Rasgele oluşturmak için R tuşuna basınız.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D:
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("Okunacak labirentin dosya yolunu giriniz -> ");
                        string? mazeFilePath;
                        mazeFilePath = Console.ReadLine();
                        if(mazeFilePath != null){
                            Console.WriteLine("Labirent " + mazeFilePath + " yolundan alınıyor...");
                            Thread.Sleep(1000);
                            Console.WriteLine(mazeFilePath + " youlndaki labirent alındı...");
                            Thread.Sleep(1000);
                            Console.WriteLine("Labirent çözülüyor...");
                            Thread.Sleep(1000);
                            MazeGame.Game game = new MazeGame.Game();
                            game.mazeFilePath = mazeFilePath;
                            game.gameMode = GameMode.FILE; 
                            game.startGame();
                            Console.WriteLine("Ana menüye dönmek için bir tuşa bas!");
                            goto initializer;
                        } else {
                            goto initializer;
                        }
                    case ConsoleKey.R:
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("Oluşturulacak labirentin adını giriniz -> ");
                        string? mazeFileName;
                        mazeFileName = Console.ReadLine();
                        if(mazeFileName != null){
                            Console.WriteLine("Labirent oluşturuluyor...");
                            Thread.Sleep(1000);
                            Console.WriteLine("Labirent " + mazeFileName + " adıyla olşturuldu...");
                            Thread.Sleep(1000);
                            Console.WriteLine("Labirent çözülüyor...");
                            Thread.Sleep(1000);
                            MazeGame.Game game = new MazeGame.Game();
                            game.outputMazeName = mazeFileName;
                            game.gameMode = GameMode.RANDOM; 
                            game.startGame();
                            goto initializer;
                        } else {
                            goto initializer;
                        }
                    default: 
                        Console.WriteLine("Geçersiz tuşa bastınız!");
                        break;
                }
            }

        }

        static void printHeader()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("| *Labirent oyununa hogeldiniz.*                               |");
            Console.WriteLine("|                                                              |");
            Console.WriteLine("| *Yapmak istediğiniz işlemi seçiniz.*                         |");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
        }

    }
}












