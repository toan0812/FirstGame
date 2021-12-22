using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Enemies : MonoBehaviour
{
    [SerializeField] private float Enemies_speed;
    [SerializeField] private int StartingPoint;
    [SerializeField] Transform[] Points;
    private int i = 0;

    void Start()
    {
        transform.position = Points[StartingPoint].position;


    }


    void Update()
    {
        if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Enemies_speed * Time.deltaTime);
      
    }


   





}
