using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weopon : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
    public AudioSource ShootSound;   

    void Update()

    {
     if (Input.GetButtonDown("Fire1"))
     {
        Shoot(); 
        ShootSound.Play();
     }
     
    }

      void Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
    }

}