using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawns : MonoBehaviour
{
    public GameObject throwableObject1, throwableObject2, throwableObject3;
    public GameObject spawnPoint;
    [SerializeField] private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        /*InvokeRepeating("ShootFunc", 2.0f, 0.75f);*/
    }


    public void ShootFunc()
    {
        if (canAttack)
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        spawnPoint.transform.localPosition = new Vector2(Random.Range(-0.5f, 0.51f), Random.Range(0f, 1.1f));
        canAttack = false;
        switch (Random.Range(0,3)) {
            case 0:
                GameObject throwableWeapon = Instantiate(throwableObject1, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon.name = "Small Asteroid";
                break;
            case 1:
                GameObject throwableWeapon2 = Instantiate(throwableObject2, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon2.name = "Mid Af Asteroid";
                break;
            case 2:
                GameObject throwableWeapon3 = Instantiate(throwableObject3, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon3.name = "Big Asteroid";
                break;
        }
        
        yield return new WaitForSecondsRealtime(3f);
        canAttack = true;
    }
}
