using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Idle,
    Follow,
    Die,
    Attack
};

public enum EnemyType
{
    Melee,
    Ranged
};

public class EnemyController : MonoBehaviour
{
    
    GameObject player;
    public EnemyState currState = EnemyState.Idle;
    public EnemyType enemyType;
    public float range;
    public float speed;
    private bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;
    private bool coolDownAttack = false;
    public float coolDown;
    public float attackRange;
    public bool notInRoom = false;
    public GameObject bulletPrefab;
    public float Health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            case(EnemyState.Idle):
                //Idle();
            break;
            case(EnemyState.Wander):
                Wander();
            break;
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Die):
            break;
            case(EnemyState.Attack):
                Attack();
            break;
        }

        if(!notInRoom)
        {
            if(IsPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Follow;
            }
            else if(!IsPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Wander;
            }
            if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {   
                currState = EnemyState.Attack;
            }
        }

        else
        {
            currState = EnemyState.Idle;
        }   
        
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        randomDir = new Vector3(0, Random.Range(0, 360), 0); //rotates enemy along the y-axis
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    void Wander()
    {
        if(!chooseDir)
        {
            //StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if(IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Attack()
    {
        if(!coolDownAttack)
        {
            switch(enemyType)
            {
                case(EnemyType.Melee):
                    player.GetComponent<Health>().DamagePlayer(1);
                    StartCoroutine(CoolDown());
                break;
                case(EnemyType.Ranged):
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<BulletScript>().GetPlayer(player.transform);
                    bullet.GetComponent<BulletScript>().isEnemyBullet = true;
                    
                    StartCoroutine(CoolDown());
                    Debug.Log("Enemy fired");
                break;
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void DamageEnemy(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Death();
        }
    }

    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }
}
