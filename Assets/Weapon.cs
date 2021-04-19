using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Shooting weapons
    public Transform firePoint;
    GameObject player;
    public GameObject bullet;

    public float groundLevel = .25f;
    
    // item backpack
    int cycle = 0;

    // Throwables
    public GameObject grenade;
    public GameObject trap;

    public GameObject poison;

    public float throwForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transform
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Get ground level at player position 
        //groundLevel = new Vector3 (transform.position.x, GameObject.Find("Plane").transform.position.y, transform.position.z);
        // Shoot
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Shoot();
        // }

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
                if(player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "grenade(Clone)"){
                    // Call throw
                    Throw(grenade);
                } else if (player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "trap(Clone)"){
                    Place(trap);
                } else if (player.GetComponent<player_inventory>().itemBackpack[cycle].itemName == "gas(Clone)"){
                    Throw(poison);
                }

                // Delete from player inventory
                player.GetComponent<player_inventory>().itemBackpack[cycle].itemName = null;
            }
        }

    }

    // void Shoot ()
    // {
    //     Instantiate(bullet, firePoint.position, firePoint.rotation);
    // }

    void Throw( GameObject throwable)
    {
        // Spawn in throwable and give weapon tag
        var throwItem = Instantiate(throwable, new Vector3 (transform.position.x - 5, groundLevel, transform.position.z), firePoint.rotation);
        throwItem.tag = "Weapon";

        // Use object script
        if(throwItem.name == "grenade(Clone)"){
            throwItem.GetComponent<grenade_script>().enabled = true;
            // throwItem.GetComponent<Collider>().isTrigger = false;
        } else if(throwItem.name == "poison(Clone)"){
            throwItem.GetComponent<poison_script>().enabled = true;
        }
    }

    void Place(GameObject placeable){

        // Spawn in placeable
        var placeItem = Instantiate(placeable, new Vector3 (transform.position.x - 5, groundLevel, transform.position.z), transform.rotation);
        placeItem.tag = "Weapon";
    }
}

    
