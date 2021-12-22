using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public Transform ShootPoint;
    [SerializeField] private float TimeShoot;
    [SerializeField] private float TimeStartShoot;
    private Animator Plant_anim;
    [SerializeField] private GameObject Plants;
    
    private void Start()
    {
        Plant_anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (TimeShoot <= 0)
        {
            Instantiate(bullet, ShootPoint.position, transform.rotation);
            TimeShoot = TimeStartShoot;
        }
        else

        {
            TimeShoot -= Time.deltaTime;
        }
        Plant_anim.SetBool("Plant_Shoot", true);
    }
   
}
