using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public int MaxHP = 10;
    public int HP = 10;
    public int score = 0;
    public GameObject ForceField;
    public GameObject bullet;
    public GameObject sideBullet;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool invincible = false;
    [SerializeField] private bool tap = false;
    public Transform projectileSpawnBase;
    public List<Transform> projectileSpawnSpread;
    public float horizontalMove;
    public float moveSpeed = 2f;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rb;
   /* private InputAction touchMovement;
    private InputAction touchFire;
    private PlayerInput PI;*/
    [SerializeField] private Vector2 touchVec2, touchVec22,finalPos;
    private Lean.Touch.LeanTouch lean;
    private float fraction;
    public enum planeState {None,Shield,Spread,Multi};
    public planeState pState;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = MaxHP;
        pState = planeState.None;
       /* PI = GameObject.FindGameObjectWithTag("InputManager").GetComponent<PlayerInput>();
        touchMovement = PI.actions.FindAction("Move");
        touchFire = PI.actions.FindAction("Fire");*/
        lean = GameObject.FindGameObjectWithTag("YungLean").GetComponent<Lean.Touch.LeanTouch>();
        finalPos = new Vector2(0.2996f, -4.28f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0,0,0,0);
        if (canMove)
        {
             finalPos = new Vector2(Camera.main.ScreenToWorldPoint(touchVec22).x, -4.28f);
            /* horizontalMove = Mathf.Clamp((finalPos.x * moveSpeed),-1f,1f);
             rb.velocity = new Vector2(rb.velocity.x, 0);
             Vector3 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
             rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.3f);*/
            if (fraction < 1)
            {
                fraction += Time.deltaTime * moveSpeed;
                transform.position = Vector2.Lerp(transform.position, finalPos, fraction);
            }
            if (fraction > 1)
            {
                fraction = 0;
            }


        }
        if (pState == planeState.None)
        {
            invincible = false;
            ForceField.SetActive(false);
        }
        /*  for (int i = 0; i < Input.touchCount; ++i)
          {*/
        if (/*Input.GetTouch(i).phase == TouchPhase.Began ||*/(tap/*|| Input.GetKeyDown(KeyCode.Mouse0)*/) && canShoot && (pState == planeState.None||pState==planeState.Shield))
            {
                tap = false;
            
                
                GameObject throwableWeapon = Instantiate(bullet, projectileSpawnBase.position, Quaternion.identity) as GameObject;
                Vector2 direction = new Vector2(transform.localScale.x, 0);
                throwableWeapon.name = "PlayerBullet";
                canShoot = false;
            if (HP == 4)
            {
                anim.SetBool("isFiring", true);
            }
            else if (HP == 3)
            {
                anim.SetBool("isFiringDamage1", true);
            }
            else if (HP == 2)
            {
                anim.SetBool("isFiringDamage2", true);
            }
            else if (HP == 1)
            {
                anim.SetBool("isFiringDamage3", true);
            }
            StartCoroutine(BaseShootDelay());
            }
        if (/*Input.GetTouch(i).phase == TouchPhase.Began ||*/ /*Input.GetKeyDown(KeyCode.Mouse0)*/tap && canShoot && pState == planeState.Spread)
        {
            tap = false;

            GameObject throwableWeapon1 = Instantiate(bullet, projectileSpawnSpread[0].position, Quaternion.identity) as GameObject;
            GameObject throwableWeapon2 = Instantiate(bullet, projectileSpawnSpread[1].position, Quaternion.identity) as GameObject;
            GameObject throwableWeapon3 = Instantiate(sideBullet, projectileSpawnSpread[2].position, Quaternion.identity) as GameObject;
            GameObject throwableWeapon4 = Instantiate(sideBullet, projectileSpawnSpread[3].position, Quaternion.identity) as GameObject;
            throwableWeapon1.name = "PlayerBullet";
            throwableWeapon2.name = "PlayerBullet";
            throwableWeapon3.name = "PlayerBullet";
            throwableWeapon4.name = "PlayerBullet";
            if (HP == 4)
            {
                anim.SetBool("isFiringSpread", true);
            }
            else if (HP == 3)
            {
                anim.SetBool("isFiringDamage1Spread", true);
            }
            else if (HP == 2)
            {
                anim.SetBool("isFiringDamage2Spread", true);
            }
            else if (HP == 1)
            {
                anim.SetBool("isFiringDamage3Spread", true);
            }

            Vector2 direction1 = new Vector2(projectileSpawnSpread[2].transform.localScale.x, projectileSpawnSpread[2].transform.localScale.y);
            Vector2 direction2 = new Vector2(-projectileSpawnSpread[3].transform.localScale.x, projectileSpawnSpread[3].transform.localScale.y);
            throwableWeapon3.GetComponent<sidebullet>().direction = direction1;
            throwableWeapon4.GetComponent<sidebullet>().direction = direction2;
            throwableWeapon3.GetComponent<SpriteRenderer>().flipX=true;
            canShoot = false;
            StartCoroutine(SpreadShootDelay());
        }
        if (tap/*|| Input.GetKeyDown(KeyCode.Mouse0))*/ && canShoot && pState == planeState.Multi)
       
        {
            tap = false;
            GameObject throwableWeapon1 = Instantiate(bullet, projectileSpawnSpread[0].position, Quaternion.identity) as GameObject;
            GameObject throwableWeapon2 = Instantiate(bullet, projectileSpawnSpread[1].position, Quaternion.identity) as GameObject;
            throwableWeapon1.name = "PlayerBullet";
            throwableWeapon2.name = "PlayerBullet";
            Vector2 direction = new Vector2(transform.localScale.x, 0);
            if (HP == 4)
            {
                anim.SetBool("isFiringMulti", true);
            }
            else if (HP == 3)
            {
                anim.SetBool("isFiringDamage1Multi", true);
            }
            else if (HP == 2)
            {
                anim.SetBool("isFiringDamage2Multi", true);
            }
            else if (HP == 1)
            {
                anim.SetBool("isFiringDamage3Multi", true);
            }
            canShoot = false;
            StartCoroutine(MultiShootDelay());
        }
        if (pState == planeState.Shield)
        {
            invincible = true;
            ForceField.SetActive(true);
            
        }
        /*}*/
        
       

    }
    void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerTap += HandleFingerTap;
        Lean.Touch.LeanTouch.OnFingerSwipe += FingerMove;
    }

    void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerTap -= HandleFingerTap;
        Lean.Touch.LeanTouch.OnFingerSwipe += FingerMove;
    }

    void HandleFingerTap(Lean.Touch.LeanFinger finger)
    {
        if(finger.Tap)
        tap = true;
        
        /*touchVec2 = finger.StartScreenPosition;*/
    }

    void FingerMove(Lean.Touch.LeanFinger finger)
    {
        if (finger.Swipe)
        {
            touchVec2 = finger.StartScreenPosition;
            touchVec22 = finger.LastScreenPosition;
        }
    }

    public void GetPickupShield()
    {
        pState = planeState.Shield;
        StartCoroutine(Cooldown());
    }
    public void GetPickupSpread()
    {
        pState = planeState.Spread;
        StartCoroutine(Cooldown());
    }
    public void GetPickupMulti()
    {
        pState = planeState.Multi;
        StartCoroutine(Cooldown());
    }


    public void TakeDamage()
    {
        if (!invincible)
        {
            HP--;
        }
        if (HP == 3)
        {
            anim.SetBool("Damage1", true);
        }
        else if (HP == 2)
        {
            anim.SetBool("Damage1", false);
            anim.SetBool("Dmg2", true);
        }
        else if(HP == 1)
        {
            anim.SetBool("Dmg2", false);
            anim.SetBool("Damage3", true);
        }
        if (HP <= 0)
        {
            StartCoroutine(WaitToDead());
            
        }
    }

    public void ScoreIncrease(int i)
    {
        score += i;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(10f);
        pState = planeState.None;
    }
    IEnumerator BaseShootDelay()
    {
        yield return new WaitForSeconds(0.2f);
        if (HP == 4)
        {
            anim.SetBool("isFiring", false);
        }
        else if (HP == 3)
        {
            anim.SetBool("isFiringDamage1", false);
        }
        else if (HP == 2)
        {
            anim.SetBool("isFiringDamage2", false);
        }
        else if (HP == 1)
        {
            anim.SetBool("isFiringDamage3", false);
        }
        canShoot = true;
    }
    IEnumerator SpreadShootDelay()
    {
        yield return new WaitForSeconds(0.2f);
        if (HP == 4)
        {
            anim.SetBool("isFiringSpread", false);
        }
        else if (HP == 3)
        {
            anim.SetBool("isFiringDamage1Spread", false);
        }
        else if (HP == 2)
        {
            anim.SetBool("isFiringDamage2Spread", false);
        }
        else if (HP == 1)
        {
            anim.SetBool("isFiringDamage3Spread", false);
        }
        canShoot = true;
    }
    IEnumerator MultiShootDelay()
    {
        yield return new WaitForSeconds(0.2f);
        if (HP == 4)
        {
            anim.SetBool("isFiringMulti", false);
        }
        else if (HP == 3)
        {
            anim.SetBool("isFiringDamage1Multi", false);
        }
        else if (HP == 2)
        {
            anim.SetBool("isFiringDamage2Multi", false);
        }
        else if (HP == 1)
        {
            anim.SetBool("isFiringDamage3Multi", false);
        }
        canShoot = true;
    }
  
    IEnumerator WaitToDead()
    {
        anim.SetBool("isDead", true);
        canShoot = false;
        canMove = false;
        yield return new WaitForSeconds(0.4f);
        rb.velocity = new Vector2(0, rb.velocity.y);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadSceneAsync(0);
    }
}




