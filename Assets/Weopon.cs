using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weopon : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
   

    void Update()

    {
      // gun.transform.position=new Vector2(0,-1);
     if (Input.GetButtonDown("Fire1"))
     {
        Shoot(); 
     }
     
    }

      void Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
    }

}