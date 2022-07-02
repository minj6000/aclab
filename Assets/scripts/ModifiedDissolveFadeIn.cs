using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ModifiedDissolveFadeIn : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public bool fadestart;
    public float speed = 0f;
    public bool fade;

    private void Start(){
        fadestart = false;
        fade = false;
        meshRenderer = this.GetComponent<MeshRenderer>();
        Material[] m = meshRenderer.materials;

        this.GetComponent<MeshCollider>().enabled = false;
        foreach (Material mm in m)
        {
            mm.SetFloat("_Cutoff", 1);
        }
    }

    public float t = -1f;
    private void Update()
    {

        if (fadestart)
        {
            fadein();
        }

    }


    void fadein()
    {
        speed = 1.5f;
        Material[] mats = meshRenderer.materials;
        foreach (Material m in mats)
        {
            m.SetFloat("_Cutoff", - Mathf.Sin(t * speed));
            if (m.GetFloat("_Cutoff") < 0.05f && fadestart)
            {
                this.GetComponent<ModifiedDissolveFadeIn>().speed = 0;
                fadestart = false;
                this.GetComponent<MeshCollider>().enabled = true;
            }
        }
        t += Time.deltaTime / 10;

        meshRenderer.materials = mats;
    }
}
