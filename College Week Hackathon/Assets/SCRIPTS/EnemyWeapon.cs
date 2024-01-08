using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletprefab;

    // Update is called once per frame



    public void Shoot()
    {


        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);




    }
}
