using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    // Start is called before the first frame update
    public Room room;

    [System.Serializable]
    public struct Grid
    {
        public int columns, rows;
        public float verticalOffset, horizontalOffset;
    }
    public Grid grid;
    public GameObject gridTile;
    public List<Vector3> availablePoints = new List<Vector3>();

    void Awake()
    {
        room = GetComponentInParent<Room>();
        grid.columns = room.Width - 25;
        grid.rows = room.Height - 20;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid.verticalOffset += room.transform.localPosition.x;
        grid.horizontalOffset += room.transform.localPosition.z;

        for(int y = 0; y < grid.rows; y+=10)
        {
            for(int x = 0; x < grid.columns; x+=10)
            {
                GameObject go = Instantiate(gridTile, transform);
                go.GetComponent<Transform>().position = new Vector3(y - (grid.rows - grid.verticalOffset), -9, x - (grid.columns - grid.horizontalOffset));
               go.name = "X: " + x + ", Y:" + y;
               availablePoints.Add(go.transform.position); 
               go.SetActive(false);
            }
        }

        GetComponentInParent<ObjectRoomSpawner>().InitialiseObjectSpawning();
    }
}
