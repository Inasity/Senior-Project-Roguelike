using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade_script : MonoBehaviour
{
    public float timeDelay = 2f;
    float startTimer;
    float explosionTimer;
    public GameObject explosion;

    public int damage = 2;
    public float explosiveForce = 10f;
    public float explosiveRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if(startTimer >= timeDelay){
            Explode();
            GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveRadius);

        foreach(Collider nearbyObject in colliders){
            // Do damage to enemies
        }

        Destroy(gameObject);
    }
}
