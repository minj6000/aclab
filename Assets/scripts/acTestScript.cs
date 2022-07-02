using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class acTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 15.0f;
    public float turnSpeed = 80.0f;

    private float h;
    private float v;

    private void Update()
    {
        h = Input.GetAxis("Horizontal");  // -1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");     // -1.0f ~ 1.0f

        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * v);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * h);
    }

    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.CompareTag("Collison"))
        {
            collison.gameObject.SetActive(false);
        }
    }

   
}
