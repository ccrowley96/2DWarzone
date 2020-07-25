using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform bulletSpawnLoc;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot(15);
            Debug.Log("Shooting!");
        }
    }

    void Shoot (int dmg) {
        Debug.Log("In shoot");
        //RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnLoc.position, bulletSpawnLoc.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletSpawnLoc.up * bulletForce, ForceMode2D.Impulse);

        // if(hitInfo){
        //     Enemy enemy = hitInfo.transform.GetComponent<PlayerScript>();
        //     if(enemy != null){
        //         enemy.TakeDamage(dmg);
        //     }
        // }
    }


}
