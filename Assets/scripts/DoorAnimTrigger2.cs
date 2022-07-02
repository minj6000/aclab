using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class DoorAnimTrigger2 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource au;
    public AudioSource Narr3;
    // Start is called before the first frame update
    void Start()
    {
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
        this.GetComponent<Animator>().SetBool("Open", true);
        au.Play();
        Narr3.Play();
        this.GetComponent<Outline>().enabled = false;
    }
}
