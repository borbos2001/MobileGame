
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeftSide = true;
    public bool WallBottom = true;
    public bool PlaceLeftSide = true;
    public bool PlaceBottom = true;
    public bool PlaceToMove = true;
    public bool CutPlaceLeft = true;
    public bool CutPlaceDown = true;

    public bool visited = false;
    public int DistanceFromStart;

}
public class MazeGeberetion
{
    public int width = 7;
    public int height = 6;

    public int numExitY;
    
    public MazeGeneratorCell[,] GeneratorCells()
    {
        numExitY = UnityEngine.Random.Range(0, height - 1);
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[width, height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }


        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, height - 1].WallLeftSide = false;
            maze[x, height - 1].PlaceToMove = false;
            maze[x, height - 1].CutPlaceDown = false;
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[width - 1, y].WallBottom = false;
            maze[width - 1, y].PlaceToMove = false;
            maze[width - 1, y].CutPlaceLeft = false;
        }



        RemoveWallWithBackTracker(maze);
        return maze;
    }

    private void RemoveWallWithBackTracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, numExitY];
        current.visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisited = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].visited) unvisited.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].visited) unvisited.Add(maze[x, y - 1]);
            if (x < width - 2 && !maze[x + 1, y].visited) unvisited.Add(maze[x + 1, y]);
            if (y < height - 2 && !maze[x, y + 1].visited) unvisited.Add(maze[x, y + 1]);

            if (unvisited.Count > 0)
            {
                MazeGeneratorCell chosen = unvisited[UnityEngine.Random.Range(0, unvisited.Count)];
                RemoveWall(current, chosen);
                chosen.visited = true;
                stack.Push(chosen);
                current = chosen;

                chosen.DistanceFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);

    }
    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    { 
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
            {
                a.WallBottom = false;
                a.PlaceLeftSide = false;
            }
            else
            {
                b.WallBottom = false;
                b.PlaceLeftSide = false;
            }
        }
        else
        {
            if (a.X > b.X)
            {
                a.WallLeftSide = false;
                a.PlaceBottom = false;
            }
            else
            {
                b.WallLeftSide = false;
                b.PlaceBottom = false;
            }
        }
    }
}


