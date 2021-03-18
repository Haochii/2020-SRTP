using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SC.XR.Unity.Module_InputSystem;

public class EmojiTemplate : MonoBehaviour
{
    public bool isEditing = false;
    public int emojiType = 0;
    public Vector3 originPos;
    public Quaternion originRot;
    public Vector3 originScale;
    private bool isRecorded = false;
    public SCPointEventData resetEvent;
    public void reset()
    {
        transform.position = originPos;
        transform.rotation = originRot;
        transform.localScale = originScale;

        isEditing = false;
        
        Debug.Log("Template Reset");

    }
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        originRot = transform.rotation;
        originScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void editing()
    {
        isEditing = true;
        Debug.Log("Editing Template");
    }
}
