using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int a;
    public float timetoShoot = 1f;
    public float timeElapsed;
    public float waitTime = 0.5f;
    public bool canShoot = true;
    public List<GameObject> asteroidPos;
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed>timetoShoot&&canShoot)
        enabledShoot();
        
        /*switch (a=Random.Range(0, 5)) {
            case 0:
                asteroidPos[0].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 1:
                asteroidPos[1].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 2:
                asteroidPos[2].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 3:
                asteroidPos[3].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 4:
                asteroidPos[4].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 5:
                asteroidPos[5].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
        }*/
    }
    public void enabledShoot()
    {
        canShoot = false;
        switch (a = Random.Range(0, 5))
        {
            case 0:
                asteroidPos[0].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 1:
                asteroidPos[1].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 2:
                asteroidPos[2].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 3:
                asteroidPos[3].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 4:
                asteroidPos[4].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
            case 5:
                asteroidPos[5].GetComponent<AsteroidSpawns>().ShootFunc();
                break;
        }
        StartCoroutine(WaitForShoot());
    }
    IEnumerator WaitForShoot()
    {
       yield return new WaitForSeconds(waitTime);
        canShoot = true;
        timeElapsed = 0f;
    }
}
