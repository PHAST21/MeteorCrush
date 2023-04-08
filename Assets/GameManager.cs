using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public float speed;
   public float timeIngame;
   private AsteroidManager asm;
   private playercontroller pc;
   private asteroidmove big, mid, small;
   public GameObject Bigasteroid, midasteroid, smallasteroid;
    public GameObject PickupSpawn;
    private PickupSpawn ps;
    private bool firstPickup = true;
    private bool secondPickup = true;
    private bool thirdPickup = true;
    private bool fourthPickup = true;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        asm = GameObject.FindGameObjectWithTag("AsteroidManager").GetComponent<AsteroidManager>();
        ps = PickupSpawn.GetComponent<PickupSpawn>();
        big = Bigasteroid.GetComponent<asteroidmove>();
        mid = midasteroid.GetComponent<asteroidmove>();
        small= smallasteroid.GetComponent<asteroidmove>();
        
        speed = 0f;
        timeIngame = 0f;
        big.speed = 1;
        mid.speed = 2;
        small.speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.score > 50)
        {
            asm.timetoShoot = 1.5f;
        }
        if (pc.score > 70)
        {
            big.speed = 2;
            mid.speed = 4;
            small.speed = 6;
        }
        if (pc.score > 100&&firstPickup)
        {
            ps.SpawnPickup();
            firstPickup = false;
        }
        if (pc.score > 150)
        {
            asm.timetoShoot = 1f;
        }
        if (pc.score > 175) {
            big.speed = 3;
            mid.speed = 6;
            small.speed = 8;
        
        }
        if (pc.score > 200 && secondPickup)
        {
            ps.SpawnPickup();
            secondPickup = false; ;
        }
        if (pc.score > 300)
        {
            asm.timetoShoot = 0.5f;
        }
        if (pc.score > 350)
        {
            big.speed = 4;
            mid.speed = 8;
            small.speed = 10;
        }
        if (pc.score > 400&&thirdPickup)
        {
               ps.SpawnPickup();
               thirdPickup = false; ;
            
        }

        if (pc.score > 550 && fourthPickup)
        {
            ps.SpawnPickup();
            fourthPickup = false; ;
        }
            
    }
}
