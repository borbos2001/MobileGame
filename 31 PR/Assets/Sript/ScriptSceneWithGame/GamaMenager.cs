using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaMenager : MonoBehaviour
{
    [SerializeField] private GameObject _end;
    [SerializeField] private GameObject _cellPrefab;
    public int numExitY = 0;
    private int i = 1;
    private Vector3 positionNextGeneration = new Vector3(0, 0, 0);
    

    private void Start()
    {
        Time.timeScale = 1f;
        MazeGeberetion generator = new MazeGeberetion();
        MazeGeneratorCell[,] maze = generator.GeneratorCells();
        PlaceMazeExit(maze);
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int z = 0; z < maze.GetLength(1); z++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(-x * 4, 0, z * 4) - positionNextGeneration, Quaternion.identity).GetComponent <Cell>();
                c.WallDown.SetActive(maze[x, z].WallLeftSide);
                c.WallLeft.SetActive(maze[x, z].WallBottom);
                c.PlaceToMove.SetActive(maze[x, z].PlaceToMove);
                c.CutPlaceLeft.SetActive(maze[x,z].CutPlaceLeft);
                c.CutPlaceDown.SetActive(maze[x,z].CutPlaceDown);
                if (maze[x, z].PlaceLeftSide == false)
                {
                    c.PlaneLeft.tag = "Plane";
                }
                if (maze[x, z].PlaceBottom == false)
                {
                    c.PlaneDown.tag = "Plane";
                }
;            }
        }
    }
    public void Generation()
    {
        positionNextGeneration = new Vector3(positionNextGeneration.x + 24, 0, 0);
        _end.transform.position = new Vector3(_end.transform.position.x - 24, _end.transform.position.y, _end.transform.position.z);
        Start();
    }
    private void PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        maze[0, numExitY].WallLeftSide = false;
        maze[0, numExitY].PlaceBottom = false;
        numExitY = UnityEngine.Random.Range(0, 6 - 1);
        maze[7 - 1, numExitY].WallLeftSide = false;
        maze[7 - 1, numExitY].PlaceBottom = false;
    }
}
