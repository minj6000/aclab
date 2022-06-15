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
    MeshRenderer mr;
    Material[] mats;

    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Outline>().enabled = false;
        on = false;
        objToDisappear = GameObject.FindGameObjectsWithTag("disappear");
        objToAppear = GameObject.FindGameObjectsWithTag("Street");
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            StartCoroutine(meshFade());

            on = false;

        }
    }

    private float t = 0f;
    IEnumerator meshFade()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject obj in objToDisappear)
        {
            if(obj.GetComponent<MeshRenderer>() != null)
            {
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
        foreach (GameObject obj in objToAppear)
        {
            obj.GetComponent<ModifiedDissolveFadeIn>().fadestart = true;

        }

        foreach (GameObject obj in objToDisappear)
        {
            obj.GetComponent<MeshCollider>().enabled = false;
        }

    }

    private void OnMouseOver()
    {
        this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseDown()
    {
        on = true;
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
        auForStreet.DOFade(1f,10f);
        
    }
}
