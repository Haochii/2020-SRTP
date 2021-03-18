using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    float ttl = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void des()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "sculpture")
        {
            ParticleSystem exp = GetComponent<ParticleSystem>();
            exp.Play();
            this.Invoke("des", ttl);            
            Debug.Log("OK");
        }
    }
}
