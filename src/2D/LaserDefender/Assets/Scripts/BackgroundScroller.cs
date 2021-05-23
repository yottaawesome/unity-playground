using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    float backgroundSpeed = 0.2f;

    Material material;
    Vector2 offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundSpeed);
    }

    // Per update, offset the texture to give the illusion
    // the background is moving
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
