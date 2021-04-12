using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Shooting weapons
    public Transform firePoint;
    private Transform player;
    public GameObject bullet;

    private Vector3 groundLevel;
    
    // item backpack
    int cycle = 0;

    // Throwables
    public GameObject grenade;
    public GameObject trap;

    public GameObject poison;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transform
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Get ground level at player position 
        groundLevel = new Vector3 (transform.position.x, GameObject.Find("Plane").transform.position.y, transform.position.z);
        // Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Cycle throwables
        if(player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == null){
            // If cycle is over 3, reset to 0
            if(cycle >= 2) cycle = 0;
            else cycle++;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            // If cycle is over 3, reset to 0
            if(cycle >= 2) cycle = 0;
            else cycle++;

            //Debug.Log(player.GetComponent<player_inventory>().itemBackpack[cycle].itemName);
        }

        // Throw Item
        if (Input.GetKeyDown(KeyCode.Q)){
            // Check if current cycle is not empty, then throw item
            if(player.GetComponent<player_inventory>().itemBackpack[cycle].itemName != null){
                // Check the name of the object
                if(player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "grenade"){
                    // Call throw
                    Throw(grenade);
                } else if (player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "trap"){
                    Place(trap, groundLevel);
                } else if (player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "gas"){
                    Throw(poison);
                }

                // Delete from player inventory
                player.GetComponent<player_inventory>().itemBackpack[cycle].itemName = null;
            }
        }

    }

    void Shoot ()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Throw( GameObject throwable)
    {
        // Spawn in throwable and give weapon tag
        var throwItem = Instantiate(throwable, firePoint.position, firePoint.rotation);
        throwItem.tag = "Weapon";

        // Use object script
        if(throwItem.name == "grenade(Clone)"){
            throwItem.GetComponent<grenade_script>().enabled = true;
            throwItem.GetComponent<Collider>().isTrigger = false;
            // Give it upwards velocity where aiming
            Rigidbody throwItemRB = throwItem.AddComponent<Rigidbody>();
            throwItemRB.AddForce((firePoint.forward * 5f) + (Vector3.up * 5f), ForceMode.Impulse);
        } else if(throwItem.name == "poison(Clone)"){
            throwItem.GetComponent<poison_script>().enabled = true;
        }

        
    }

    void Place(GameObject placeable, Vector3 _groundLevel){

        // Spawn in placeable
        var placeItem = Instantiate(placeable, _groundLevel, transform.rotation);
        placeItem.tag = "Weapon";
    }
}

    
