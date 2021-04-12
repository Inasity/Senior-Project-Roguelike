using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
    public float gravityTimer = 1.0f;
    Rigidbody r;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = transform.forward * speed;
        // r = this.gameObject.GetComponent<Rigidbody>();
        StartCoroutine(DeathDelay());
        transform.localScale = new Vector3(PlayerController.bulletSize, PlayerController.bulletSize, PlayerController.bulletSize);
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
        Destroy(gameObject);
    }
}

    
