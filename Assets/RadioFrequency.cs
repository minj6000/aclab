using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadioFrequency : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    private float ModifiedY;
    private Transform OriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = this.transform;
        ModifiedY = this.transform.position.y - 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < ModifiedY)
        {
            //다음 이벤트 일어남
            Music.Play();
            Music.DOFade(0.6f, 5f);
            Debug.Log("Frequency Set");
        }
    }
}
