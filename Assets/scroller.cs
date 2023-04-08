using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Renderer BgRenderer;

    void Update()
    {
        BgRenderer.material.mainTextureOffset += new Vector2(0,speed*Time.deltaTime);
    }
}