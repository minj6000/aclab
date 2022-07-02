using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineCheck : MonoBehaviour
{
    [SerializeField] GameObject PreselectedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PreselectedObj.GetComponent<Outline>().enabled == true)
        {
            this.GetComponent<Outline>().enabled = false;
        }
        else
        {
            this.GetComponent<Outline>().enabled = true;
        }
    }
}
