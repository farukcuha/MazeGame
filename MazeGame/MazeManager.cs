namespace MazeGame
{
    class MazeManager
{
    static Random random = new Random();

    public static int[,] createMaze()
    {
        int[,] randomMaze = new int[30, 30];

        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                randomMaze[i, j] = random.Next(0, 2);
            }
        }
        return randomMaze;
    }

    public static int[,] getMazeFromFile(string filePath)
    {
        string text = File.ReadAllText(@filePath);
        string[] lines = text.Split(Environment.NewLine);
        int[,] arr = new int[30, 30];

        for (int i = 0; i < 30; i++)
        {
            string line = lines[i].Trim();
            int index = 0; 
            if (i == 0)
            {
                for (int j = 2; j <= 60; j = j + 2)
                {
                    arr[i, index] = Convert.ToInt16(line[j].ToString());
                    index++;
                }
            }
            else
            {
                for (int k = 1; k <= 60; k = k + 2)
                {
                    arr[i, index] = Convert.ToInt16(line[k].ToString());
                    index++;
                }
            }
        }
        return arr;
    }
    public static void writeToTextFile(int[,] maze, string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName + ".txt"))
            {
                for (int i = 0; i < 30; i++)
                {
                    if (i == 0)
                    {
                        writer.Write("{{");
                    }
                    else
                    {
                        writer.Write("{");
                    }
                    for (int a = 0; a < 30; a++)
                    {
                        if (a != 29)
                        {
                            writer.Write(maze[i, a]);
                            writer.Write(",");
                        }
                        else
                        {
                            writer.Write(maze[i, a]);
                        }
                    }
                    if (i == 29)
                    {
                        writer.Write("}}");
                    }
                    else
                    {
                        writer.Write("},\n");
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
}