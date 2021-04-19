using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float moveSpeed = 20f;  //20f feels like good speed to start with, maybe lower like 17f
    public static float moveSpeedStart = 20f;
    Rigidbody rigidbody;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public static float fireDelay = .5f;
    public static float fireDelayStart = .5f;
    public Transform firePoint;
    public static int collectedAmount = 0;
    public static float bulletSize = 5;
    public static float bulletSizeStart = 5;
    public static float Stimpies = 0;
    public static float bulletDamage = 1f;
    public static float bulletDamageStart = 1f;
    public Text StimpsText;
    public GameObject levelloader;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");

        if(Input.GetKey("right"))
            {
                this.transform.rotation = Quaternion.Euler(0, 0f, 0);
                if(Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, 0);
            lastFire = Time.time;
        }
            }
        else if(Input.GetKey("left"))
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0f);
                if(Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, 0);
            lastFire = Time.time;
        }
            }
        else if(Input.GetKey("up"))
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 270f, 0f);
                if(Time.time > lastFire + fireDelay)
        {
            Shoot(0, shootVert * -1);
            lastFire = Time.time;
        }
            }
        else if(Input.GetKey("down"))
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 90f, 0f);
                if(Time.time > lastFire + fireDelay)
        {
            Shoot(0, shootVert * -1);
            lastFire = Time.time;
        }
            }

        if (Input.GetKeyDown("space") && Stimpies > 0 && Health.health < Health.numOfHearts)
        {
            Health.HealPlayer(1);
            Stimpies--;
        }

        StimpsText.text = "" + Stimpies;

        // if(Time.time > lastFire + fireDelay)
        // {
        //     Shoot(shootHor, shootVert * -1);
        //     lastFire = Time.time;
        // }

        rigidbody.velocity = new Vector3(vertical * moveSpeed * -1, 0, horizontal * moveSpeed);
    }

    void Shoot (float z, float x)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Vector3 bulletVector = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, 
            0,
            (z < 0) ? Mathf.Floor(z) * bulletSpeed : Mathf.Ceil(z) * bulletSpeed
        );
        bullet.GetComponent<Rigidbody>().velocity = bulletVector.normalized * bulletSpeed;
    }

    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        if (fireDelay > 0.1f)
        {
            fireDelay -= rate;
        }
        if (fireDelay <= 0f)
        {
            fireDelay = 0.1f;
        }
    }

    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }

    public static void BulletDamageChange(float damage)
    {
        bulletDamage += damage;
    }
    public static void resetStats(float speed, float fireRate, float size, float damage)
    {
        moveSpeed = speed;
        fireDelay = fireRate;
        bulletSize = size;
        bulletDamage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss Room")
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1);
        levelloader.GetComponent<LevelLoader>().LoadVictoryScreen();
    }

}
