using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;
    public int Height;
    public int Z;
    public int X;
    public Room(int z, int x)
    {
        Z = z;
        X = x;
    }

    private bool updatedDoors = false;
    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;
    public List<Door> doors = new List<Door>();
    // Start is called before the first frame update
    void Start()
    {
        if(RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene chief");
            return;
        }

        Door[] ds = GetComponentsInChildren<Door>();
        foreach(Door d in ds)
        {
            doors.Add(d);
            switch(d.doorType)
            {
                case Door.DoorType.right:
                rightDoor = d;
                break;
                case Door.DoorType.left:
                leftDoor = d;
                break;
                case Door.DoorType.top:
                topDoor = d;
                break;
                case Door.DoorType.bottom:
                bottomDoor = d;
                break;
            }
        }

        RoomController.instance.RegisterRoom(this);
    }

    void Update()
    {
        if(name.Contains("End") && !updatedDoors)
        {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(Door door in doors)
        {
            switch(door.doorType)
            {
                case Door.DoorType.right:
                if(GetRight() == null)
                {
                    door.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    door.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
                case Door.DoorType.left:
                if(GetLeft() == null)
                {
                    door.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    door.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
                case Door.DoorType.top:
                if(GetTop() == null)
                {
                    door.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    door.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
                case Door.DoorType.bottom:
                if(GetBottom() == null)
                {
                    door.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    door.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            }
        }
    }

    public Room GetRight()
    {
        if(RoomController.instance.DoesRoomExist(Z + 1, X))
        {
            return RoomController.instance.FindRoom(Z + 1, X);
        }
        return null;
    }

    public Room GetLeft()
    {
        if(RoomController.instance.DoesRoomExist(Z - 1, X))
        {
            return RoomController.instance.FindRoom(Z - 1, X);
        }
        return null;
    }

    public Room GetTop()
    {
        if(RoomController.instance.DoesRoomExist(Z, X - 1))
        {
            return RoomController.instance.FindRoom(Z, X - 1);
        }
        return null;
    }

    public Room GetBottom()
    {
        if(RoomController.instance.DoesRoomExist(Z, X + 1))
        {
            return RoomController.instance.FindRoom(Z, X + 1);
        }
        return null;
    }

    public Vector3 GetRoomCentre()
    {
        return new Vector3( X * Height, 60, Z * Width);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(Height, 0, Width));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}
