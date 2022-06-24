using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public AudioSource seskaynak;
    public AudioClip korkusesi;

    public GameObject yaratık;
    bool calistir;
    void Start() 
    {
        seskaynak.clip = korkusesi;
        calistir = false;
    }

    void OnTriggerEnter(Collider other) //Duvara girince
    {
        if (other.gameObject.tag == "Player") 
        { if(!calistir)
        {
            seskaynak.Play();
            yaratık.SetActive(true);
            calistir = true;
        }
        
        }
    }


}
