using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destryoBullet : MonoBehaviour
{
    public GameObject trig;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Gaming");
        }
    }
}

