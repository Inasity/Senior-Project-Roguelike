using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static float health = 3;
    public static int numOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

=======
<<<<<<< HEAD
        // No negative health
        if(health <= 0) health = 0;
        
=======

>>>>>>> 60e6b8d41ca9185e84814266f7de97a7843deb36
>>>>>>> Stashed changes
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            KillPlayer();
        }
    }

    private static void KillPlayer()
    {

    }

    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(numOfHearts, health + healAmount);
    }

    public static void AddStimp(float stimp)
    {
        PlayerController.Stimpies += stimp;
    }
}
