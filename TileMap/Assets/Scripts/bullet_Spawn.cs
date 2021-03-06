using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Spawn : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    void Start()
    {
        Invoke("destroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void destroyBullet()
    {
        Destroy(gameObject);
    }
}
