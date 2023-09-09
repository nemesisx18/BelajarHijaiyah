using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkEffect : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("Sparkle");
    }
}
