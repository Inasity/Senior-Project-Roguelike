using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_melee_damage : MonoBehaviour
{
    // Variables    
    private float speed;                    // Speed from melee enemy movements
    private Transform player;               // To get player position
    private const float HIT_COOLDOWN = 1f;  // Cooldown for damaging the player
    private float hitTime;                  // Holds the time passed since hit
    bool justHit;                           // no explanation needed

    // Start is called before the first frame update
    void Start()
    {
        // Set player transform
        player = GameObject.Find("Player").transform;

        // Grab player health
        health = Health.health;
        
        // Get the speed of this melee enemy from it's movement script
        speed = gameObject.GetComponent<melee_enemy_movement>().speed;

        // Set hitTime at 0 so the first hit is allowed
        hitTime = 0;
        justHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get distance between player and enemy
        Vector3 path = player.position - transform.position;
        float dist = path.magnitude;
        float step = speed * Time.deltaTime;

        // If within hitting distance, do damage
        if(step + 1f >= dist){
            // Lower the player health if no cooldown
            if(hitTime <= 0) Health.health--;

            justHit = true;
        }

        // Start cooldown
        if(justHit == true) hitTime += Time.deltaTime;

        // If we reached cooldown, reset hit time to zero to allow player to hit
        if(hitTime >= HIT_COOLDOWN) {
            hitTime = 0;
            justHit = false;
        }
    }
}
