using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask isBoss;

    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit2 = Physics2D.Raycast(transform.position, transform.right, distance, isBoss);
        if (raycastHit2.collider != null)
        {
            if (raycastHit2.collider.CompareTag("Boss"))
            {
                raycastHit2.collider.GetComponent<Boss_Health>().TakeDamage(damage);

            }
        }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);

    }
}
