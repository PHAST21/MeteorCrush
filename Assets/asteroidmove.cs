using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidmove : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;
	private playercontroller characterController2D;
	public float HP;
	public int scoreAmt;
	private Rigidbody2D rb;
	public float rotateSpeed;
	private Animator anim;
	/*	private bool rightProjectile;*/
	private CircleCollider2D col;
	// Start is called before the first frame update
	private void Awake()
	{
		characterController2D = FindObjectOfType<playercontroller>();
	}
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		/*if (bossEnemy.facingRight)
		{
			*//*rightProjectile = true;*//*
		}*/
		col = GetComponent<CircleCollider2D>();
		col.enabled = true;
	}

    private void Update()
    {
        if (HP <= 0)
        {
			StartCoroutine(WaitToDie());
        }
    }
    void FixedUpdate()
	{

		float rotateAmount = Vector3.Cross(direction, transform.up*-1).z;
		rb.angularVelocity = -rotateSpeed * rotateAmount;
		rb.velocity = transform.up*-1 * speed;
	}
	public void TakeDamage(int i)
    {
		HP -= i;
    }


	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("AsteroidLimit"))
		{
			hasHit = true;
			characterController2D.ScoreIncrease(5);
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.SendMessage("TakeDamage");
			hasHit = true;
			Destroy(gameObject);
			/*StartCoroutine(CollisionDisable());*/
		}
		else if(collision.gameObject.CompareTag("Asteroid")) 
		{
            StartCoroutine(CollisionDisable());
            /*col.enabled = true;*/
            /*rb.isKinematic = false;*/
            /*Destroy(gameObject);*/
        }
	}

	IEnumerator WaitToDie()
    {
		anim.SetBool("isDead", true);
		yield return new WaitForSeconds(0.2f);
		characterController2D.ScoreIncrease(scoreAmt);
		Destroy(gameObject);
    }
    IEnumerator CollisionDisable()
    {
        col.enabled = false; ;
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
    }
}
