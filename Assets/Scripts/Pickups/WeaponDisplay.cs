using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{

    public Weapon weapon;
    public int damage;
    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        damage = weapon.damage;
        bulletSpeed = weapon.bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(collider.gameObject.tag = "Player"){}
        Debug.Log(collider.gameObject.name + " picked up, " + this.name + "!");
        collider.gameObject.GetComponent<PlayerScript>().Equip(this.gameObject);

        //Destroy(this.gameObject);
        this.gameObject.transform.SetParent(collider.gameObject.transform, false);
    }
}
