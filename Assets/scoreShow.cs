using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreShow : MonoBehaviour
{
    private playercontroller pc;
    private TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = pc.score.ToString();
    }
}
