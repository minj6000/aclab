using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenGrab : MonoBehaviour
{
    [SerializeField] Animator Bookanim;
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
}
