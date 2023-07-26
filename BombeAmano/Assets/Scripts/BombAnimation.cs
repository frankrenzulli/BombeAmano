using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D cirlceCollider;

    [Tooltip("Sprite iniziale dal quale far iniziare l'animazione")]
    public Sprite firstSprite;
    [Tooltip("Sprite dell'animazione")]
    public Sprite[] animationSprites;


    private float animationTime = 0.125f;
    private int animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cirlceCollider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
        cirlceCollider.enabled = true;
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
