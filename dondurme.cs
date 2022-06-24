using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    RaycastHit nesne;
    void Start()
    {
        
    }

    
    void OnMouseDown()
    {
        
        transform.Rotate(new Vector3 (0,90,0));
        Ray isik_yolla = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            
        if (Physics.Raycast(isik_yolla,out nesne))
        {
            if (nesne.collider.gameObject.tag == "Kutu") 
            {
                Debug.Log("Nesne Döndürüldü");
            }        
        }       
        
    }
}
