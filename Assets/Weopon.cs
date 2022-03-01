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
      // Vector3 difference = Camera.ScreenTowordoint(Input.mousePosition) - transform.position;
      // float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
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