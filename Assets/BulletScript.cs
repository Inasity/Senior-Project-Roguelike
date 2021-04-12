using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
<<<<<<< Updated upstream
    public float gravityTimer = 1.0f;
    Rigidbody r;
    public float lifeTime;
=======
<<<<<<< HEAD
    private Transform player;
=======
    public float gravityTimer = 1.0f;
    Rigidbody r;
    public float lifeTime;
>>>>>>> 60e6b8d41ca9185e84814266f7de97a7843deb36
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
        // Set player transform
        player = GameObject.Find("Player").transform;

        rb.velocity = transform.forward * speed;
=======
>>>>>>> Stashed changes
        // rb.velocity = transform.forward * speed;
        // r = this.gameObject.GetComponent<Rigidbody>();
        StartCoroutine(DeathDelay());
        transform.localScale = new Vector3(PlayerController.bulletSize, PlayerController.bulletSize, PlayerController.bulletSize);
<<<<<<< Updated upstream
=======
>>>>>>> 60e6b8d41ca9185e84814266f7de97a7843deb36
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        // gravityTimer-= Time.deltaTime;
        // if (gravityTimer <= 0f)
        // {
        //     r.useGravity = true;
        // }
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Enemy")
        {
        Debug.Log(hitInfo.name);
        hitInfo.gameObject.GetComponent<EnemyController>().Death();
<<<<<<< Updated upstream
        Destroy(gameObject);
        }

        else if(hitInfo.tag != "Player" && hitInfo.tag != "Room")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        // Debug.Log(hitInfo.name);
=======
>>>>>>> Stashed changes
        Destroy(gameObject);
        }

        else if(hitInfo.tag != "Player" && hitInfo.tag != "Room")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
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
