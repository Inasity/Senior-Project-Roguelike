using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
