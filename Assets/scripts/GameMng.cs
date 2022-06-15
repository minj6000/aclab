using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMng : MonoBehaviour
{
    [SerializeField] GameObject Ash;
    [SerializeField] GameObject AshWritingManager;
    public bool Written;
    [SerializeField] GameObject Narr6;
    [SerializeField] GameObject Narr6Au;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Written)
        {
            Narr6Au.gameObject.SetActive(true);
            Narr6.GetComponent<SpriteRenderer>().DOFade(1, 5f);
        }
    }
    public void AshOn()
    {
        Ash.gameObject.SetActive(true);
        AshWritingManager.SetActive(true);
    }
}
