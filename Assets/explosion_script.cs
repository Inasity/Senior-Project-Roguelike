using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{
    float explosionTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer += Time.deltaTime;
        if(explosionTimer >= .3f){
            Destroy(gameObject);
        }
    }
}
