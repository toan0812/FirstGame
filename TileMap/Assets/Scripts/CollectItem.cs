using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    private int Apples;
    private int Oranges;
    private int Health = 3;
    [SerializeField] private Text AppleText;
    [SerializeField] private Text OrangeText;
    [SerializeField] private Text LifesText;
    Shooting_Spawn Shooting;
    private void Start()
    {
        Shooting = GetComponent<Shooting_Spawn>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Appies"))
        {
            Destroy(collision.gameObject);
            Apples++;
            AppleText.text = "Apples: " + Apples;

        }
        else if (collision.gameObject.CompareTag("Orangies"))
        {
            Destroy(collision.gameObject);
            Oranges++;
            OrangeText.text = "Oranges: " + Oranges;

        }
        else if(collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            Health++;
            LifesText.text = "Lifes: " + Health;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Health--;
            LifesText.text = "Lifes: " + Health;
        }
    }
    private void Update()
    {
        Shooting.Shoot();
        Apples--;
    }

}
