using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimFinished : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject EnvelopTimeline;
    [SerializeField] AudioSource envelopAu;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Grabbable>().enabled = false;
        this.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Done") == true)
        {
            this.GetComponent<Grabbable>().enabled = true;
            this.GetComponent<Outline>().enabled = true;
        }
    }

    public void BookGrabFinished()
    {
        this.GetComponent<Outline>().enabled = false;
        EnvelopTimeline.SetActive(true);
        envelopAu.Play();
    }
}
