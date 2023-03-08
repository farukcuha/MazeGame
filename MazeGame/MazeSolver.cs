namespace MazeGame
{
    class MazeSolver
{
    Coordinat endPoint = new Coordinat(0, 0);
    int[,] maze;
    List<Coordinat> pathList = new List<Coordinat>();
    List<Coordinat> triedList = new List<Coordinat>();
    public MazeSolver(int[,] maze){
        this.maze = maze;
    }

    public List<Coordinat> solveMaze()
    {
        foreach(Coordinat start in findStartPoints(maze)){
             foreach(Coordinat end in findEndPoints(maze)){
                endPoint = end;
                int[,] temp = (int[,]) maze.Clone();
                if (move(temp, new Coordinat(start.x, start.y))){
                    goto breakingLoops;
                }
            }
        }
        breakingLoops:;
        return pathList;
    }
    private bool isValidPoint(int[,] maze, Coordinat point)
    {
        if (point.x >= 0 && point.x < 30 && point.y >= 0 && point.y < 30) 
        return maze[point.x, point.y] == Point.GAP;
        return false;
    }

    private bool move(int[,] maze, Coordinat point)
    {
        if (isValidPoint(maze, new Coordinat(point.x, point.y)))
        {

            if (point.x == endPoint.x && point.y == endPoint.y) return true;

            maze[point.x, point.y] = 2;
            triedList.Add(new Coordinat(point.x, point.y));

            //up
            bool returnValue = move(maze, new Coordinat(point.x, point.y + 1));
            //right
            if (!returnValue) returnValue = move(maze, new Coordinat(point.x + 1, point.y));
            //down
            if (!returnValue) returnValue = move(maze, new Coordinat(point.x, point.y - 1));
            //left
            if (!returnValue) returnValue = move(maze, new Coordinat(point.x - 1, point.y));
            
            if (returnValue){
                maze[point.x, point.y] = 3;
                pathList.Add(new Coordinat(point.x, point.y));
            }

            return returnValue;
        }
        return false;
    }

    private List<Coordinat> findStartPoints(int[,] maze)
    {
        List<Coordinat> list = new List<Coordinat>();

        Coordinat startPoint = new Coordinat(0, 0);
        if(maze[startPoint.x, startPoint.y] != 1) list.Add(startPoint);

        for(int i = 1; i < 30; i++){
            Coordinat cornerPoint = new Coordinat(i, i); 

            for(int j = 0; j < i; j++){
                Coordinat hPoint = new Coordinat(j, i);
                if(maze[hPoint.x, hPoint.y] != 1) list.Add(hPoint);
                
                Coordinat vPoint = new Coordinat(i, j);
                if(maze[vPoint.x, vPoint.y] != 1) list.Add(vPoint);
            }
            if(maze[cornerPoint.x, cornerPoint.y] != 1) list.Add(cornerPoint);
        }
        return list;
    }

    private List<Coordinat> findEndPoints(int[,] maze)
    {
        List<Coordinat> list = new List<Coordinat>();

        Coordinat cornerPoint = new Coordinat(29, 29);
        if(maze[cornerPoint.x, cornerPoint.y] != 1) list.Add(cornerPoint);

        for(int i = 28; i != -1; i--){
            Coordinat hPoint = new Coordinat(i, 29);
            if(maze[hPoint.x, hPoint.y] != 1) list.Add(hPoint);

            Coordinat vPoint = new Coordinat(29, i);
            if(maze[vPoint.x, vPoint.y] != 1) list.Add(vPoint);
        }
        return list;
    }
}
}