using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class AnimatedSprite : MonoBehaviour
{
    protected SpriteRenderer sp;
    protected Animator animator;
    protected void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
}
