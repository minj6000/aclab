using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadioFrequency : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] GameObject TL;
    private float ModifiedY;
    private Transform OriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Outline>().enabled = true;
        OriginalPos = this.transform;
        ModifiedY = this.transform.position.y - 0.4f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Frequency()
    {
        if (OriginalPos.position.y > ModifiedY)
        {
            //다음 이벤트 일어남
            Music.Play();
            Music.DOFade(0.6f, 5f);
            Debug.Log("Frequency Set");
            TL.SetActive(true);
            this.GetComponent<Outline>().enabled = false;
        }
    }
}
