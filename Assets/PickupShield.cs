using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShield : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;	
	private Rigidbody2D rb;
	public float rotateSpeed;
	/*	private bool rightProjectile;*/
	private CircleCollider2D col;

	// Start is called before the first frame update
	private void Awake()
	{
		/*characterController2D = FindObjectOfType<playercontroller>();*/
	}
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		/*if (bossEnemy.facingRight)
		{
			*//*rightProjectile = true;*//*
		}*/
		col = GetComponent<CircleCollider2D>();
		col.enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		float rotateAmount = Vector3.Cross(direction, transform.up).z;
		rb.angularVelocity = -rotateSpeed * rotateAmount;
		rb.velocity = transform.up*-1 * speed;
		if (hasHit)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("AsteroidLimit"))
		{
			hasHit = true;
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("Player"))
		{
			hasHit = true;
			collision.gameObject.SendMessage("GetPickupShield");
			Destroy(gameObject);
			
		}
		else
		{
            StartCoroutine(CollisionDisable());
            /*col.enabled = true;*/
            /*rb.isKinematic = false;*/
            /*Destroy(gameObject);*/
        }
	}

    IEnumerator CollisionDisable()
    {
        col.enabled = false; ;
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
    }
}
