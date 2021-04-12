using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy_movement : MonoBehaviour
{
    // Enemy movement variables
    public float speed = 10.0f;

    // Private variables
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transforms
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if in the same room, set the path to player
        // *** check room here ***
        Vector3 path = player.transform.position - transform.position;
        
        // Pathing variables
        float dist = path.magnitude;
        Vector3 dir = path.normalized;
        float step = speed * Time.deltaTime;
        Vector3 velocity = dir * step;
        velocity.y = 0;

        // Move to player if distance too far
        if(step + 1f <= dist){
            transform.position = transform.position + (dir * step);
        }
    }

    // Function to check if player is in room (for future when rooms are made)
}
