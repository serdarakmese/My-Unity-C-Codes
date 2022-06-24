using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakteranim : MonoBehaviour
{
    AudioSource seskaynak;
    public AudioClip reloadsesi;
    
    
    private Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
        seskaynak=GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("persuader", true);
            seskaynak.Play();
            seskaynak.clip=reloadsesi;
        }
        else
        {
            animator.SetBool("persuader", false);
        }
        
    }
}
