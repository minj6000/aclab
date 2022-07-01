using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadioFrequency : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    private float ModifiedZ;
    private Transform OriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = this.transform;
        ModifiedZ = this.transform.position.z - 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < ModifiedZ)
        {
            //���� �̺�Ʈ �Ͼ
            Music.Play();
            Music.DOFade(0.6f, 5f);
            Debug.Log("Frequency Set");
        }
    }
}
