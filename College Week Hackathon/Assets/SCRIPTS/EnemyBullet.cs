using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
    
        HealthManager player = hitInfo.GetComponent<HealthManager>();
        if (player != null) {

            player.TakeDamage(damage);
        
        }

        Destroy(gameObject);
    }
}
