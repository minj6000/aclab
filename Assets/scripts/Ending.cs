using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField] AudioSource treesound;
    // Start is called before the first frame update
    void Start()
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
        tree.SetActive(true);
        StartCoroutine(soundfade());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator soundfade()
    {
        treesound.volume = 0;
        yield return new WaitForSeconds(0.2f);
        treesound.Play();
        yield return new WaitForSeconds(0.1f);
        treesound.DOFade(0.3f, 10f);

    }
}
