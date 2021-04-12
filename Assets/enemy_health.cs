using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    // Health of enemy object
    public int health;

    // Timer for damaged appearance (blink red)
    private const float DAMAGE_TIMER_COOLDOWN = .09f;
    private float damageTimeElapse;
    private GameObject capsule;         // Reference to enemy model to change it's color red

    // Damage variables
    public int grenadeDamage = 4;
    public int trapDamage = 3;
    public int poisonDamage = 2;

    // Collision detection to deal damage
    private bool collision = false;
    private float dealDamageTimer = 1;
    private Collider collisionObject;

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
        // Check if collision is true, and dealDamageTimer is less than zero
        // Then deal damage and reset timer
        dealDamageTimer -= Time.deltaTime;
        if(collision == true && dealDamageTimer <= 0 && collisionObject != null){
            DamageEnemy(collisionObject);
            dealDamageTimer = 1;
        }

        // Do something when hit
        // Turn hit timer on to change back to normal color, color was changed to red in DamageEnemy()
        if(capsule.GetComponent<MeshRenderer>().material.color == Color.red){
            damageTimeElapse -= Time.deltaTime;

            // When damage timer is up, reset color to white
            if(damageTimeElapse < 0){
                damageTimeElapse = DAMAGE_TIMER_COOLDOWN;
                capsule.GetComponent<MeshRenderer>().material.color = Color.white;
                if(capsule.transform.childCount > 0){
                    capsule.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;
                }
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
        if(other.tag == "Weapon"){
            collisionObject = other;
            collision = true;

            // Bullet damage doesn't work if not done here
            if(other.name == "Bullet(Clone)"){
                DamageEnemy(other);
            }
        }
    }

    void OnTriggerExit(Collider other){
        collision = false;
    }

    public void DamageEnemy(Collider other){
        // Check if Player weapons have damaged the enemy
        if(other.tag == "Weapon"){
            // Bullet does one damage
            if(other.name == "Bullet(Clone)") {
                health--;
                
                // Destroy the bullet
                // Debug.Log(hitInfo.name);
                //Destroy(other);
            }

            // *** Add other player weapons here ***
            if(other.name == "grenade(Clone)"){
               health -= grenadeDamage;
            }
            
            if(other.name == "trap(Clone)"){
                health -= trapDamage;
            }

            if(other.name == "poison(Clone)"){
                health -= poisonDamage;
            }

            // *** Do stuff when hit, like blink enemy red *** 
            // Turn red when hit
            capsule.GetComponent<MeshRenderer>().material.color = Color.red;
            if(capsule.transform.childCount > 0){
                capsule.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
