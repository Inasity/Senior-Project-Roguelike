using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    // Private variables 
    int health;
    private const float DAMAGE_TIMER_COOLDOWN = .09f;
    private float damageTimeElapse;
    private GameObject capsule;

    // Start is called before the first frame update
    void Start()
    {
        // Set time elapse
        damageTimeElapse = DAMAGE_TIMER_COOLDOWN;

        // Set capsule gameobject
        capsule = transform.GetChild(0).gameObject;

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
        // Do something when hit
        // Turn hit timer on to change to normal color
        if(capsule.GetComponent<MeshRenderer>().material.color == Color.red){
            damageTimeElapse -= Time.deltaTime;

            // When damage timer is up, reset color to white
            if(damageTimeElapse < 0){
                damageTimeElapse = DAMAGE_TIMER_COOLDOWN;
                capsule.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
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
            // Bullet does one damage
            if(other.name == "Bullet(Clone)") health--;

            // *** Add other player weapons here ***

            // *** Do stuff when hit, like blink enemy red *** 
            // Turn red when hit
            capsule.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
