using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{
    public string name;
    public string description;
    public Sprite itemImage;
}

public class CollectionController : MonoBehaviour
{

    public Item item;

    public float healthChange;

    public float moveSpeedChange;

    public float attackSpeedChange;

    public float bulletSizeChange;
    public int healthMaxChange;
    public float bulletdamagechange;
    public float stimpChange;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.collectedAmount++;
            Health.HealPlayer(healthChange);
            Health.IncreasePlayerHealth(healthMaxChange);
            Health.AddStimp(stimpChange);
            PlayerController.MoveSpeedChange(moveSpeedChange);
            PlayerController.FireRateChange(attackSpeedChange);
            PlayerController.BulletSizeChange(bulletSizeChange);
            PlayerController.BulletDamageChange(bulletdamagechange);
            Destroy(gameObject);
        }
    }
    
}
