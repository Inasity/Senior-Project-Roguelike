using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class RoomInfo
{
    public string name;
    public int Z;
    public int X;
}

public class RoomController : MonoBehaviour
{

    public static RoomController instance;
    string currentWorldName = "Basement";
    RoomInfo currentLoadRoomData;
    Room currRoom;
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();
    public List<Room> loadedRooms = new List<Room>();
    bool isLoadingRoom = false;
    bool spawnedBossRoom = false;
    bool updatedRooms = false;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // LoadRoom("Start", 0, 0);
        // LoadRoom("Empty", 1, 0);
        // LoadRoom("Empty", -1, 0);
        // LoadRoom("Empty", 0, 1);
        // LoadRoom("Empty", 0,-1);
    }

    void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue()
    {
        if(isLoadingRoom)
        {
            return;
        }

        if(loadRoomQueue.Count == 0)
        {
            if(!spawnedBossRoom)
            {
                StartCoroutine(SpawnBossRoom());
            }
            else if (spawnedBossRoom && !updatedRooms)
            {
                foreach(Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                UpdateRooms();
                updatedRooms = true;
            }
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    IEnumerator SpawnBossRoom()
    {
        spawnedBossRoom = true;
        yield return new WaitForSeconds(0.5f);
        if(loadRoomQueue.Count == 0)
        {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Room temptRoom = new Room(bossRoom.Z, bossRoom.X);
            Destroy(bossRoom.gameObject);
            var roomToRemove = loadedRooms.Single(r => r.Z == temptRoom.Z && r.X == temptRoom.X);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", temptRoom.Z, temptRoom.X);
        }
    }
    public void LoadRoom( string name, int z, int x)
    {
        if(DoesRoomExist(z, x))
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.Z = z;
        newRoomData.X = x;

        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;
        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        if(!DoesRoomExist(currentLoadRoomData.Z, currentLoadRoomData.X))
        {
            room.transform.position = new Vector3
            (
                currentLoadRoomData.X * room.Height,
                0,
                currentLoadRoomData.Z * room.Width
            );

            room.Z = currentLoadRoomData.Z;
            room.X = currentLoadRoomData.X;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.Z + "," + room.X;
            room.transform.parent = transform;

            isLoadingRoom = false;
            
            if(loadedRooms.Count == 0)
            {
                CameraController.instance.currRoom = room;
            }

            loadedRooms.Add(room);
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }
    }

    public bool DoesRoomExist(int z, int x)
    {
        return loadedRooms.Find(item => item.Z == z && item.X == x) != null;
    }

    public Room FindRoom(int z, int x)
    {
        return loadedRooms.Find(item => item.Z == z && item.X == x);
    }

    public string GetRandomRoomName()   //Add new rooms here please
    {
        string[] possibleRooms = new string[]
        {
            "BasicMelee",
            "BasicRanged",
            "BasicMixed",
            "StrongMelee",
            "StrongRanged",
            "StrongMixed",
            "RangedMixed",
            "MeleeMixed"
        };

        return possibleRooms[Random.Range(0, possibleRooms.Length)];
    }

    public void OnPlayerEnterRoom(Room room)
    {
        CameraController.instance.currRoom = room;
        currRoom = room;

        UpdateRooms();
    }

    private void UpdateRooms()
    {
        foreach(Room room in loadedRooms)
        {
            if(currRoom != room)
            {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if(enemies != null)
                {
                    foreach(EnemyController enemy in enemies)
                    {
                        enemy.notInRoom = true;
                        Debug.Log("Not in room");
                    }
                }
            }
            else
            {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if(enemies != null)
                {
                    foreach(EnemyController enemy in enemies)
                    {
                        enemy.notInRoom = false;
                        Debug.Log("In the room chief");
                    }
                }
            }
        }
    }
    
}
