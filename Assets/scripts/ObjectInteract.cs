using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectInteract : MonoBehaviour
{
    public GameObject[] objToDisappear;
    public GameObject[] objToAppear;
    public SpriteRenderer txt;
    public AudioSource auForStreet;
    public AudioSource auForthis;
    public AudioSource Narr1;

    private MeshRenderer mr;
    private Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Outline>().enabled = false;
        objToDisappear = GameObject.FindGameObjectsWithTag("disappear");
        objToAppear = GameObject.FindGameObjectsWithTag("Street");

        foreach (GameObject obj in objToDisappear)
        {
            if (obj.GetComponent<MeshRenderer>() != null)
            {

                obj.GetComponent<MeshRenderer>().material.SetFloat("_Cutoff", 0);
            }
        }
    }
     
        
    


    private float t = 0f;
    IEnumerator meshFade()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject obj in objToDisappear)
        {
            if (obj.GetComponent<ModifiedDissolveScript>() != null)
            {
                obj.GetComponent<ModifiedDissolveScript>().fadestart = true;
                obj.GetComponent<ModifiedDissolveScript>().speed = 0.15f;
            }
            
            if (obj.GetComponent<SpriteRenderer>() != null)
            {
                obj.GetComponent<SpriteRenderer>().DOFade(0, 8f);
            }
        }
        yield return new WaitForSeconds(8f);
        auForthis.DOFade(0, 15f);
        txt.DOFade(1f, 10).SetDelay(15f);
        yield return new WaitForSeconds(3f);
        Narr1.Play();
        StartCoroutine(soundfade());
        foreach (GameObject ob in objToAppear)
        {
            if(ob.GetComponent<ModifiedDissolveFadeIn>() != null)
               {
                    ob.GetComponent<ModifiedDissolveFadeIn>().fadestart = true;
               }
        }

        foreach (GameObject ob in objToDisappear)
        {
            ob.GetComponent<MeshCollider>().enabled = false;
        }

    }
    

    private void OnMouseOver()
    {
        this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseDown()
    {
        StartCoroutine(meshFade());

    }
    private void OnMouseExit()
    {

        this.GetComponent<Outline>().enabled = false;
    }


    IEnumerator soundfade()
    {
        auForStreet.volume = 0;
        yield return new WaitForSeconds(0.2f);
        auForStreet.Play();
        yield return new WaitForSeconds(0.1f);
        auForStreet.DOFade(1f, 10f);

    }
}


