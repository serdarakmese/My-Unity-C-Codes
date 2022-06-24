using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class AtesEtme : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public float Menzil;
    public GameObject mermiefekti;
    public float minX, maxX;
    public float minY, maxY;
    public Transform Camera;
    Vector3 rot;
    public float mermi;
    public float sarjor;
    public float tasinanmermi;
    float eklenenmermi;
    float reloadTimer;
    public Text MermiSayac;
   



    
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        
        MermiSayac.text= "" + mermi + "/" + tasinanmermi;
        eklenenmermi = sarjor-mermi;
        if (eklenenmermi>tasinanmermi)
        {
            eklenenmermi=tasinanmermi;
        }

        if (Input.GetKeyDown(KeyCode.R) && eklenenmermi > 0 && tasinanmermi > 0)
        
        if (Time.time > reloadTimer)
        {
            StartCoroutine(Reload());
            reloadTimer=Time.time;
        }

        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer && mermi > 0) //Mouse ile ateş etme koşulu
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
            
            Instantiate(mermiefekti, hit.point, Quaternion.LookRotation(hit.normal)); //Mermi izi efekti için kullanılır
            

        }

        rot= Camera.transform.localRotation.eulerAngles;

        if(rot.x !=0 || rot.y!=0)
        {Camera.transform.localRotation=Quaternion.Slerp(Camera.transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime * 3);}

        

        
    }

    void Fire()
    {
        if (mermi<=0) 
        {AtesEdebilir = false;}
        if (mermi > 0) 
        {AtesEdebilir =true; mermi--;}
        
        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil)) //Ateş etme sisteminin nasıl olacağı
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);

           
           
        }
       recoil();
    
     void recoil()
     {
         float recX=Random.Range(minX, maxX);
         float recY=Random.Range(minY, maxY);
         Camera.transform.localRotation = Quaternion.Euler(rot.x - recY, rot.y + recX, rot.z); //Silah geri tepme işlemi
     }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.2f);
        mermi = mermi + eklenenmermi;
        tasinanmermi = tasinanmermi - eklenenmermi;
    }
     

}