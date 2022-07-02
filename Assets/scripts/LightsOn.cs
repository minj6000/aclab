using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightsOn : MonoBehaviour
{
    [SerializeField] Light lgt;
    // Start is called before the first frame update
    void Start()
    {

        lgt.intensity = 0;
        this.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseDown()
    {
        lgt.DOIntensity(8.5f, 2.5f);
        

    }

    private void OnMouseExit()
    {
        this.GetComponent<Outline>().enabled = false;
    }
}
