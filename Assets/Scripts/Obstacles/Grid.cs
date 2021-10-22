
using System;
using Array2DEditor;
using UnityEngine;
[Serializable]
public class Grid
{

    public Node[,] grid;
    public bool useBools;
    public Array2DBool boolArray;
    public Vector3 startPos;

    public float spacingX;
    public float spacingY = 0f;
    public float spacingZ;

    public int rows;
    public int cols;

    public Grid(Vector3 startPos, float spacingX, float spacingZ, int rows, int cols)
    {
        this.startPos = startPos;
        this.spacingX = spacingX;
        this.spacingZ = spacingZ;
        this.rows = rows;
        this.cols = cols;
        SetUpGrid();
    }



    public void SetUpGrid()
    {
        grid = new Node[rows, cols];
        grid[0, 0] = new Node(startPos);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                float x = startPos.x + col * spacingX;
                float y = startPos.y;
                float z = startPos.z + row * spacingZ;
                Vector3 currentPos = new Vector3(x,y,z);
                if (useBools)
                {
                    grid[row, col] = new Node(currentPos, boolArray.GetCell(col, row));
                }
                else
                {
                    grid[row,col] = new Node(currentPos, true);
                }
            }
        }
        
    }
}
