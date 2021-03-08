using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;
    public int Height;
    public int Z;
    public int X;
    // Start is called before the first frame update
    void Start()
    {
        if(RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene chief");
            return;
        }

        RoomController.instance.RegisterRoom(this);
    }

    public Vector3 GetRoomCentre()
    {
        return new Vector3( Z * Width, X * Height);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(Height, 0, Width));
    }
}
