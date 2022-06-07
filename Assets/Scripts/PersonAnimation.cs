using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAnimation : MonoBehaviour
{
    public Sprite[] images;

    public float animationFPS;
    private PersonScript controller;
    private SpriteRenderer sRenderer;

    private float frameTimer = 0;
    private int frameIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PersonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0.0f)
        {
            frameTimer = 1 / animationFPS;
            frameIndex %= images.Length;
            sRenderer.sprite = images[frameIndex];
            frameIndex++;
        }
    }
}
