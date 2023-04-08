using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Img1, Img2, Img3, PowerupMulti, PowerupSpread, PowerupShield;
    private playercontroller pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
    }

    private void Update()
    {
        if (pc.pState == playercontroller.planeState.Multi)
        {
            PowerupMulti.SetActive(true);
            StartCoroutine(Cooldown(PowerupMulti));
        }
        if (pc.pState == playercontroller.planeState.Shield)
        {
            PowerupShield.SetActive(true);
            StartCoroutine(Cooldown(PowerupShield));
        }
        if (pc.pState == playercontroller.planeState.Spread)
        {
            PowerupSpread.SetActive(true);
            StartCoroutine(Cooldown(PowerupSpread));
        }
        if (pc.HP == 3)
        {
            Img1.SetActive(false);
        }
        if (pc.HP == 2)
        {
            Img2.SetActive(false);
        }
        if (pc.HP == 1)
        {
            Img3.SetActive(false);
        }
    }

    IEnumerator Cooldown(GameObject a)
    {
        yield return new WaitForSeconds(10f);
        a.SetActive(false);
    }
}
