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
    public bool isEnemyBullet = false;
    private Vector3 lastPos;
    private Vector3 currPos;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = transform.forward * speed;
        // r = this.gameObject.GetComponent<Rigidbody>();
        StartCoroutine(DeathDelay());
        if(!isEnemyBullet)
        {
            transform.localScale = new Vector3(PlayerController.bulletSize, PlayerController.bulletSize, PlayerController.bulletSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnemyBullet)
        {
            currPos = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, 40f * Time.deltaTime);
            if(currPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = currPos;
        }
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Enemy" && !isEnemyBullet)
        {
        Debug.Log(hitInfo.name);
        hitInfo.gameObject.GetComponent<EnemyController>().DamageEnemy(1);
        Destroy(gameObject);
        Debug.Log("Hit an enemy");
        }

        if(hitInfo.tag == "Player" && isEnemyBullet)
        {
            hitInfo.gameObject.GetComponent<Health>().DamagePlayer(1);
            Destroy(gameObject);
        }

        if(hitInfo.tag == "Wall")
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

    
