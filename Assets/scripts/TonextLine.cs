using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Outline))]
public class TonextLine : MonoBehaviour
{
    public GameObject[] txtToappear;
    public string tagName;
    public AudioSource Narr2;
    public AudioSource LightFlickering;

    // Start is called before the first frame update
    void Start()
    {
        txtToappear = GameObject.FindGameObjectsWithTag(tagName);
        this.GetComponent<Outline>().enabled = false;
        foreach (GameObject txt in txtToappear)
        {
            if(txt.GetComponent<BoxCollider>() != null)
            {
                txt.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        txtToappear = GameObject.FindGameObjectsWithTag(tagName);
    }

    private void OnMouseEnter()
    {
        this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseDown()
    {
        Narr2.Play();
        LightFlickering.Play();
        this.GetComponent<SpriteRenderer>().DOFade(0,3f).SetEase(Ease.InOutQuad);
        this.GetComponent<Outline>().enabled = false;
        foreach (GameObject txt in txtToappear)
        {
            if (txt.GetComponent<BoxCollider>() != null)
            {
                txt.GetComponent<BoxCollider>().enabled = true;
            }
        }
        StartCoroutine(nexttxtFade());
    }

    IEnumerator nexttxtFade()
    {
        foreach(GameObject txt in txtToappear)
        {
            yield return new WaitForSeconds(0.5f);
            if (txt.GetComponent<SpriteRenderer>() != null)
            {
                txt.GetComponent<SpriteRenderer>().DOFade(1, 5f).SetEase(Ease.InOutQuad);
            }
            if (txt.GetComponent<Light>() != null)
            {
                txt.GetComponent<Light>().DOIntensity(3.5f, 5f);
                txt.GetComponent<LightFlickering>().isFlickering = false;
            }
        }
    }
}
