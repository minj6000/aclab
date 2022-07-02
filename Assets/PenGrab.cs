using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenGrab : MonoBehaviour
{
    [SerializeField] Animator Bookanim;
    [SerializeField] AudioSource Txtau;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BookOpen()
    {
        Bookanim.SetBool("Open", true);
    }

    public void BookClose()
    {
        Bookanim.SetBool("Close", true);
    }

    public void Bookanimation()
    {
        StartCoroutine(BookAnim());
    }

    IEnumerator BookAnim()
    {
        Bookanim.SetBool("Open", true);
        yield return new WaitForSeconds(3.5f);
        Txtau.Play();
        yield return new WaitForSeconds(4.5f);
        Bookanim.SetBool("Close", true);
    }
}
