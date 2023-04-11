using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    [Tooltip("Sprite iniziale dal quale far iniziare l'animazione")]
    public Sprite firstSprite;
    [Tooltip("Sprite dell'animazione")]
    public Sprite[] animationSprites;


    private float animationTime = 0.125f;
    private int animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
        spriteRenderer.sprite = firstSprite;
    }

    private void NextFrame()
    {
        animationFrame++;

       if (animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationFrame];
        }
    }

}
