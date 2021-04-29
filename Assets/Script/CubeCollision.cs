using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public float TimeToDes = 2.0f;
    public float TotalTime = 5.0f;
    private bool isExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        while (TotalTime >= 0)
        {
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }

    void Update()
    {
        if (TotalTime <= 0)
        {
            //Debug.Log("Self Destory")
            playAnim();
            this.Invoke("des", TimeToDes);
        }
    }

    public void des()
    {
        Destroy(this.gameObject);
    }

    private void playAnim()
    {

            ParticleSystem exp = GetComponent<ParticleSystem>();
            //AudioSource ad = GetComponent<AudioSource>();
            exp.Play();

        //TODO    
        GameObject.Find("bomb(Clone)").GetComponent<AudioSystem>().PlayAudioOneShot(GameObject.Find("bomb(Clone)"), SCAudiosConfig.AudioType.Explode, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "sculpture")
        {
            playAnim();
            this.Invoke("des", TimeToDes);            
            //Debug.Log("OK");
        }

    }
}
