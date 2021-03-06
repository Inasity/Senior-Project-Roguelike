using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_enemy_movement : MonoBehaviour
{
    // Enemy movement variables
    public float speed = 5.0f;
    public float STOP_DISTANCE = 10f;

    // Private variables
    private Transform player;
    private float step;

    // Pathing variables
    Vector3 path;
    float dist;
    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set player transforms
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Look at player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        // Repath to player every frame
        path = player.position - transform.position;
        dist = path.magnitude;
        dir = path.normalized;
        step = speed * Time.deltaTime;

        // If too far from player, stop shooting and get closer
        if(step + STOP_DISTANCE <= dist){
            // Integrate movement
            transform.position = transform.position + (dir * step);
        
            // Stop shooting script
            GetComponent<Enemy_range_damage>().enabled = false;
        } else {
            // Enable shooting script
            GetComponent<Enemy_range_damage>().enabled = true;
        }
    }

    // Function to check if player is in room (for future when rooms are made)
}
