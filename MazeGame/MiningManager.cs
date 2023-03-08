using System;
using System.Collections.Generic;

namespace MazeGame
{
	public class MiningManager
	{
		public static List<Coordinat> getRandomMines(int[,] maze, List<Coordinat> path)
        {
			Random random = new Random();
			List<Coordinat> mines = new List<Coordinat>();

			while(mines.Count < 3){
				int x = random.Next(0, 30);
				int y = random.Next(0, 30);
				Coordinat mineCoordinat = new Coordinat(x, y);
				
				if(maze[mineCoordinat.x, mineCoordinat.y] == Point.GAP){
					foreach(Coordinat p in path){
						if(p.x == mineCoordinat.x && p.y == mineCoordinat.y){
							goto cancelMineAdding;
						}
					}
					mines.Add(mineCoordinat);
					cancelMineAdding:;
				}
			}
			return mines;
        }
	}
}