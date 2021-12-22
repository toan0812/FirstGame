using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform Player;
    bool isFlipped = false;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;

        if (transform.position.x > Player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180f, 0);
            isFlipped = false;
        }
        else if(transform.position.x < Player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180f, 0);
            isFlipped = true;
        }
    }
}
