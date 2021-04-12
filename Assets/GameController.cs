using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    private static int health = 3;
    private static int maxHealth = 10;
    private static float moveSpeed = 25f;
    private static float fireRate = 0.5f;

    public static int Health { get => health; set => health = value;}

    public static int MaxHealth { get => maxHealth; set => maxHealth = value;}

    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value;}

    public static float FireRate { get => fireRate; set => fireRate = value;}


    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
