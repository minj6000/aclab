using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ModifiedDissolveScript : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float speed = 0f;

    private void Start(){
        meshRenderer = this.GetComponent<MeshRenderer>();
        Material[] m = meshRenderer.materials;

        foreach(Material mm in m)
        {
            mm.SetFloat("_Cutoff", 0f);
        }
    }

    private float t = 0.0f;
    private void Update()
    {
        Material[] mats = meshRenderer.materials;


        foreach (Material m in mats)
        {
            m.SetFloat("_Cutoff", Mathf.Sin(t * speed));
            if(m.GetFloat("_Cutoff") > 0.9f)
            {
                StartCoroutine(turnoff());
            }
        }
        t += Time.deltaTime / 8;
        
        // Unity does not allow meshRenderer.materials[0]...
        meshRenderer.materials = mats;
    }
    IEnumerator turnoff()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
