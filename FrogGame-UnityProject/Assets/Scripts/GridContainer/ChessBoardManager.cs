using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardManager : MonoBehaviour
{

    [SerializeField] private int length;
    [SerializeField] private int width;
    [SerializeField] private float gridSpaceSize;

    [SerializeField] private GameObject gridCellPrefab;

    private GameObject[,] frogChessBoard;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Creates the Grid
    private void CreateGrid()
    {
        frogChessBoard = new GameObject[length, width];

        if (gridCellPrefab == null)
        {
            Debug.LogError("Need a prefab in gridCellPrefab!");
        }

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Create a new Tile object for each cell
                frogChessBoard[x, y] = Instantiate(gridCellPrefab, new Vector3(x * gridSpaceSize, y * gridSpaceSize), Quaternion.identity);
                frogChessBoard[x, y].GetComponent<Tile>().SetPosition(x, y);
                frogChessBoard[x, y].transform.parent = transform;
                frogChessBoard[x, y].gameObject.name = "Tile ( X: " + x.ToString() + " , Y: " + y.ToString() + ")";
            }
        }
    }

    public Vector2Int GetGridPositionFromWorld(Vector2 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.y / gridSpaceSize);

        x = Mathf.Clamp(x, 0, length);
        y = Mathf.Clamp(y, 0, width);

        return new Vector2Int(x, y);
    }

    public Vector2 GetWorldPositionFromGrid(Vector2Int gridPos)
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;

        return new Vector2(x, y);
    }

    public GameObject SelectTile(int x, int y)
    {
        return frogChessBoard[x, y];
    }

    public List<GameObject> FindGridChildrenWithTag(string tagName)
    {
        List<GameObject> returnList = new List<GameObject>();

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject currentTile = SelectTile(x, y);
                if (currentTile.transform.childCount > 0)
                {
                    // Add tile to list if it contains a child with the tag
                    foreach (Transform child in currentTile.transform)
                    {
                        if (child.gameObject.tag == tagName)
                        {
                            returnList.Add(currentTile);
                        }
                    }
                }
            }
        }

        return returnList;
    }
}