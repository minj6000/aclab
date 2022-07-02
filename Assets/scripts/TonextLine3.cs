using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TonextLine3 : MonoBehaviour
{
    public GameObject[] txttoappear;
    public string tagNameForGameobj;
    public AudioSource Narr;
    // Start is called before the first frame update
    void Start()
    {
        txttoappear = GameObject.FindGameObjectsWithTag(tagNameForGameobj);

        this.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {

        this.GetComponent<Outline>().enabled = false;
    }
    private void OnMouseDown()
    {
        if (!Narr.isPlaying)
        {
            this.GetComponent<Outline>().enabled = false;
            this.GetComponent<SpriteRenderer>().DOFade(0, 5f);

            foreach (GameObject obj in txttoappear)
            {
                if (obj.GetComponent<SpriteRenderer>() != null)
                {
                    obj.GetComponent<SpriteRenderer>().DOFade(1, 5f);
                }
                if (obj.GetComponent<ParticleSystem>() != null)
                {
                    obj.GetComponent<ParticleSystem>().Play();
                }
                if (obj.GetComponent<Light>() != null)
                {
                    obj.GetComponent<Light>().DOIntensity(11, 5f);
                }
                if (obj.GetComponent<AudioSource>() != null)
                {
                    obj.GetComponent<AudioSource>().Play();
                }
                if (obj.GetComponent<GameMng>() != null)
                {
                    obj.GetComponent<GameMng>().AshOn();
                }
            }
            StartCoroutine(deactive());
        }

        

    }
    IEnumerator deactive()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
