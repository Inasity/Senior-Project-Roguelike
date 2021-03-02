using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy_movement : MonoBehaviour
{
    // Enemy movement variables
    public float speed = 5.0f;
    public float accel = 14.0f;
    public float maxVelocityChange = 10.0f;

    // Private variables
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transforms
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // set the path to player
        Vector3 path = player.position - transform.position;
        
        // Pathing variables
        float dist = path.magnitude;
        Vector3 dir = path.normalized;
        float step = speed * Time.deltaTime;
        Vector3 velocity = dir * step;
        velocity.y = 0;

        // Move to player
        if(step > dist){
            // If close enough to the player, do something

            // Stop when touching player
            transform.position = player.position;
        } else {
            transform.position = transform.position + (dir * step);
        }
    }

    // Function to check if player is in room (for future when rooms are made)
}
