using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
    public float gravityTimer = 1.0f;
    Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
        r = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityTimer-= Time.deltaTime;
        if (gravityTimer <= 0f)
        {
            r.useGravity = true;
        }
    }

    void OnTriggerEnter (Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
