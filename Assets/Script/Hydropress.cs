using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydropress : MonoBehaviour
{
    public Vector3 originalposition;
    public float disappearTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        originalposition = this.GetComponent<Transform>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetPosition()
    {
        this.GetComponent<Transform>().position = originalposition;
        this.GetComponent<Transform>().rotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        this.GetComponent<MeshRenderer>().enabled = false;
        DisableGravity();
    }
    public void EnableGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<MeshRenderer>().enabled = true;
        Invoke("resetPosition",disappearTime);
    }

    public void DisableGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
    }
    
}
