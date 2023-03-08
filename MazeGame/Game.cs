namespace MazeGame
{
    class Game
    {
        int[,] maze = new int[30, 30];
        List<Coordinat> path = new List<Coordinat>();
        List<Coordinat> mines = new List<Coordinat>();
        DisplayMode displayMode = DisplayMode.GAME;
        public GameMode gameMode;
        public string? mazeFilePath;
        public string? outputMazeName;

        public void startGame()
        {
            if (gameMode == GameMode.FILE){
                maze = MazeManager.getMazeFromFile(mazeFilePath!);
            } else {
                maze = MazeManager.createMaze();
                PathManager.placePath(maze, PathManager.createRandomPath());
                MazeManager.writeToTextFile(maze, outputMazeName!);
            }
            MazeSolver mazeSolver = new MazeSolver(maze);
            path = mazeSolver.solveMaze();
            mines = MiningManager.getRandomMines(maze, path);
            initDisplaying();       
        }

        public void initDisplaying()
        {
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                printInstructions();
                printMaze();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.X:
                        displayMode = DisplayMode.PATH;
                        break;
                    case ConsoleKey.B:
                        displayMode = DisplayMode.MINE;
                        break;
                    case ConsoleKey.L:
                        displayMode = DisplayMode.GAME;
                        break;
                    case ConsoleKey.Enter:
                        displayMode = DisplayMode.PATH_COORDINATES;
                        break;
                    case ConsoleKey.Escape:
                        goto endOfGame;

                }
            }
            endOfGame:;
        }

        void printMaze()
        {

            Console.WriteLine();
            Console.WriteLine(" ------------------------------");

            if (displayMode == DisplayMode.PATH_COORDINATES)
            {
                path.Reverse();
                foreach (Coordinat path in path) Console.WriteLine("x = " + path.x + " , " + "y = " + path.y);
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < 30; j++)
                    {
                        int point = maze[j, i];
                        switch (displayMode)
                        {
                            case DisplayMode.GAME:
                                if (point == Point.WALL) Console.Write("◼");
                                else Console.Write(" ");
                                break;
                            case DisplayMode.MINE:
                                string sM = " ";
                                foreach (Coordinat mine in mines) if (mine.x == j && mine.y == i) sM = "B";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(sM);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case DisplayMode.PATH:
                                string sP = " ";
                                foreach (Coordinat path in path) if (path.x == j && path.y == i) sP = "X";
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(sP);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" ------------------------------");
        }

        void printInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Yolu görmek için X'e basınız.                 |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Bombaları görmek için B'ye basınız.           |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Orijinal labirenti görmek için L'ye basınız.  |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Yol kordinatlarını görmek için entere basınız.|");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Oyunu sonlandırmak için ESC'ye basınız.       |");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}