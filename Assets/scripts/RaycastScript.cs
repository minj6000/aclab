using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaycastScript : MonoBehaviour
{
    public float range = 5;
    public AudioSource au;
    bool auplay;
    // Start is called before the first frame update
    void Start()
    {
        auplay = true;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, range))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.layer == 6)
            {
/*                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<ObjectInteract>().on = true;
                }*/

                if (au.isPlaying == false && auplay)
                {
                    StartCoroutine(soundfade());
                }
            }
            if (hit.collider.gameObject.layer == 5)
            {
                if (au.isPlaying == false && auplay)
                {
                    StartCoroutine(soundfade());
                }
            }
        }
    }
    IEnumerator soundfade()
    {
        au.volume = 0;
        yield return new WaitForSeconds(0.2f);
        au.Play();
        yield return new WaitForSeconds(0.1f);
        au.DOFade(0.3f, 5f);
        auplay = false;
    }
}
