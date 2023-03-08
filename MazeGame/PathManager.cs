namespace MazeGame
{
    class PathManager
{
    static Random random = new Random();
    
    public static List<Coordinat> createRandomPath()
    {
        List<Coordinat> pathes = new List<Coordinat>();
        Coordinat startPoint = new Coordinat(0, 0);
        pathes.Add(startPoint);

        while (pathes[pathes.Count - 1].x != 29 && pathes[pathes.Count - 1].y != 29)
        {
            int lastIndex = pathes.Count - 1;
            if (random.Next(0, 2) == 0)
            {
                Coordinat newPath = new Coordinat(pathes[lastIndex].x + 1, pathes[lastIndex].y);
                pathes.Add(newPath);
            }
            else
            {
                Coordinat newPath = new Coordinat(pathes[lastIndex].x, pathes[lastIndex].y + 1);
                pathes.Add(newPath);
            }
        }
        return pathes;
    }

    public static void placePath(int[,] maze, List<Coordinat> pathList){
        foreach(Coordinat path in pathList){
            maze[path.x, path.y] = Point.GAP;
        }
    }
}
}