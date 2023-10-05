using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BodyPart : MonoBehaviour
{
    private const string Hand = "Hand";

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipBody(bool isLeft)
    {
        if(LayerMask.NameToLayer(Hand) == gameObject.layer)
        _spriteRenderer.flipY = isLeft;
        else
        _spriteRenderer.flipX = isLeft;
    }
}
