using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nisanal : MonoBehaviour
{
public Vector3 nisanpos;
public Vector3 normalpos;  

public float aimspeed;

   
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, nisanpos, aimspeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, normalpos, aimspeed * Time.deltaTime);
        }
    }
}
