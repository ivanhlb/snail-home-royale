using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get { return sp; } }
    protected SpriteRenderer sp;
    protected Animator animator;
    protected virtual void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
}
