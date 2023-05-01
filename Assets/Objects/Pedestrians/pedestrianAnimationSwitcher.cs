using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianAnimationSwitcher : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void pedHit()
    {
        animator.SetTrigger("hit");
    }

}
