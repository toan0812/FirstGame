using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Spawn : MonoBehaviour
{

    [SerializeField] private GameObject Apples;
    public Transform ShootPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("F")){
                Shoot();
                timeBtwShots = startTimeBtwShots; }
        }
        else
            timeBtwShots -= Time.deltaTime;
    }
    public void Shoot()
    {
        Instantiate(Apples, ShootPoint.position, ShootPoint.rotation);
    }
}
