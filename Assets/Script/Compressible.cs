using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compressible : MonoBehaviour
{
    
    public bool isCompressing = false;
    public bool isRestoring = false;
    public float CompressedScaleLimit = 0.1f;
    public float TransformStep = 0.01f;
    public float CompressedTime = 2.0f;
    public float CompressingTime = 0.9f;
    public float RestoringTime = 2.7f;
    private float CompressingTimeStep;
    private float RestoringTimeStep;

    // Start is called before the first frame update
    void Start()
    {
        CompressingTimeStep = CompressingTime / ((1.0f - CompressedScaleLimit) / TransformStep);
        RestoringTimeStep = RestoringTime / ((1.0f - CompressedScaleLimit) / TransformStep);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "100T" && !isCompressing)
        {
            //被压扁了
            isCompressing = true;
            StartCoroutine(Compress());
        }
    }
    IEnumerator Compress()
    {
        while (true)
        {
            float scaleY = this.GetComponent<Transform>().localScale.y;
            if (scaleY < CompressedScaleLimit)
            {
                yield return new WaitForSeconds(CompressedTime);
                isRestoring = true;
                StartCoroutine(Restore());
                yield return new WaitUntil(() => isRestoring == false);
                isCompressing = false;
                break;
            }
            this.GetComponent<Transform>().localScale = new Vector3(1, scaleY - TransformStep, 1);

            yield return new WaitForSeconds(CompressingTimeStep); // first
            //Specific functions put here 
            //Debug.Log(Time.time);   // then
            // Note the order of codes above.  Different order shows different outcome.
        }
    }

    IEnumerator Restore()
    {
        while (true)
        {
            //Debug.Log("Restore");
            float scaleY = this.GetComponent<Transform>().localScale.y;
            if (scaleY >= 1.0f)
            {
                isRestoring = false;
                break;
            }
            this.GetComponent<Transform>().localScale = new Vector3(1, scaleY + TransformStep, 1);
            yield return new WaitForSeconds(RestoringTimeStep); // first
            //Specific functions put here 
            //Debug.Log(Time.time);   // then
            // Note the order of codes above.  Different order shows different outcome.
        }
    }

}
