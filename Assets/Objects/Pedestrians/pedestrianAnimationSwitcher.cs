using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianAnimationSwitcher : MonoBehaviour
{
    Animator animator;
    AudioSource DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        DeathSound = GetComponent<AudioSource>();
    }

    public void pedHit()
    {
        animator.SetTrigger("hit");
        if(DeathSound) DeathSound.Play();
    }

}
