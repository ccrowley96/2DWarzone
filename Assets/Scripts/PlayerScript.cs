using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    int health;
    int smallAmmo;
    int heavyAmmo;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        smallAmmo = 100;
        heavyAmmo = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int amount){
        health += amount;
    }

    public void SubHealth(int amount){
        health -= amount;
    }


    public void AddAmmo(int amount, bool small){
        if(small){
            smallAmmo += amount;
        } else {
            heavyAmmo += amount;
        }
    }

    public void SubAmmo(int amount, bool small){
        if(small){
            smallAmmo -= amount;
        } else {
            heavyAmmo -= amount;
        }
    }

}
