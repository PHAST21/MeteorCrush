using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    public GameObject Pickup1,Pickup2,Pickup3;
    public Transform spawnPoint;

    // Start is called before the first frame update
    public void SpawnPickup()
    {
        spawnPoint.transform.localPosition = new Vector2(Random.Range(-0.5f, 0.51f), Random.Range(0f, 1.1f));
        switch (Random.Range(0, 3))
        {
            case 0:
                GameObject throwableWeapon = Instantiate(Pickup1, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon.name = "Shield";
                break;
            case 1:
                GameObject throwableWeapon2 = Instantiate(Pickup2, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon2.name = "Spread";
                break;
            case 2:
                GameObject throwableWeapon3 = Instantiate(Pickup3, spawnPoint.transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                throwableWeapon3.name = "Multi";
                break;
        }
    }


}
