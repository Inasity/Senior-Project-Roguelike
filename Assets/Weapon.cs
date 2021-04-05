using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Shooting weapons
    public Transform firePoint;
    private Transform player;
    public GameObject bullet;
    
    // item backpack
    int cycle = 0;

    // Throwables
    public GameObject grenade;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transform
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
        // Spawn in throwable
        var throwItem = Instantiate(throwable, firePoint.position, firePoint.rotation);

        // Give it upwards velocity where aiming
        throwItem.tag = "Weapon";
        throwItem.GetComponent<Collider>().isTrigger = false;
        Rigidbody throwItemRB = throwItem.AddComponent<Rigidbody>();
        throwItemRB.AddForce((firePoint.forward * 5f) + (Vector3.up * 5f), ForceMode.Impulse);

        // Use object script
        if(throwItem.name == "grenade(Clone)"){
            throwItem.GetComponent<grenade_script>().enabled = true;
        }
    }
}

    
