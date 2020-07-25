using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDisplay : MonoBehaviour
{

    public Pickup thisPickup;
    string pickupName;
    int healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        pickupName = thisPickup.pickupName;
        healthPoints = thisPickup.points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name + " picked up, " + this.name + "!");
        collider.gameObject.GetComponent<PlayerScript>().AddHealth(this.healthPoints);

        Destroy(this.gameObject);
    }


}
