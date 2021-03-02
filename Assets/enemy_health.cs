using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    // Private variables 
    int health;

    // Start is called before the first frame update
    void Start()
    {
        // Assign base enemy health number depending on tag
        if(gameObject.tag == "Melee Enemy") {
            health = 3;
            
            // *** Can add more health depending on enemy name ***
            // ex) if(gameObject.name == 'charger'") {health += 3}
        }
        else if (gameObject.tag == "Range Enemy") {health = 5;}
        else if (gameObject.tag == "Boss") {health = 20;}
    }

    // Update is called once per frame
    void Update()
    {
        // Check if no more health left
        if(health <= 0){
            // Kill enemy
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if Player weapons have damaged the enemy
        if(other.tag == "Weapon"){
            // Bullet
            if(other.name == "Bullet(Clone)"){
                health--;
            }
            // *** Add other weapons here ***

            // *** Do stuff when hit, like blink enemy red *** 
        }
    }
}
