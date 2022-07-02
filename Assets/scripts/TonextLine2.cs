using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TonextLine2 : MonoBehaviour
{
    public GameObject OldHouse;
    public GameObject[] OBJToappear;
    public string tagName;

    // Start is called before the first frame update
    void Start()
    {

        this.GetComponent<Outline>().enabled = false;
        OldHouse.SetActive(false);
        OBJToappear= GameObject.FindGameObjectsWithTag(tagName);

    }

    // Update is called once per frame
    void Update()
    {
        OBJToappear = GameObject.FindGameObjectsWithTag(tagName);
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
        OldHouse.SetActive(true);
        StartCoroutine(housefadin());

        this.GetComponent<Outline>().enabled = false;
    }

    


    IEnumerator housefadin()
    {
        yield return new WaitForSeconds(1f);
        foreach(GameObject obj in OBJToappear)
        {
            if (obj.GetComponent<MeshRenderer>() != null)
            {
                obj.GetComponent<MeshRenderer>().material.DOFade(1, 5f);
            }
        }
    }

}
