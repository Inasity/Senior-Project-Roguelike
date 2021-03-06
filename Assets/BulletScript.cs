using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Set player transform
        player = GameObject.Find("Player").transform;

        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider hitInfo)
    {
        // Debug.Log(hitInfo.name);
        // Check collision tag to make sure projectiles don't destroy eachother
        if(hitInfo.tag != "Weapon"){
            Destroy(gameObject);
        }

        // If a bullet has hit a player, reduce health
        if(hitInfo.name == "Player"){
            player.GetComponent<Health>().health--;
        }
    }
}
