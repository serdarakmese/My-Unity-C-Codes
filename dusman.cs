using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dusman : MonoBehaviour

{
    Animator ZombiAnim;
    
    public Transform hedef;
    public float mesafe;
    NavMeshAgent Agent;


        void Start()
    {
        
        ZombiAnim = GetComponent<Animator>();
        Agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ZombiAnim.SetFloat("hız", Agent.velocity.magnitude);
        mesafe = Vector3.Distance(transform.position, hedef.position);

        Agent.destination = hedef.position;
        if(mesafe<=20) 
        {
            Agent.enabled=true;
        }
        else
        {
            Agent.enabled=false;
        }



    }
}
