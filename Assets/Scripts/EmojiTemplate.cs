using System.Collections;
using System.Collections.Generic;
using SC.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmojiTemplate : DragComponent
{
    public bool isEditing = false;
    public int emojiType = 0;
    public Vector3 originPos;
    public Quaternion originRot;
    public Vector3 originScale;
    private bool isRecorded = false;

    public void reset()
    {
        transform.position = originPos;
        transform.rotation = originRot;
        transform.localScale = originScale;

        isEditing = false;
        Debug.Log("Template Reset");
        
    }

    public override void Start()
    {
        base.Start();
        originPos = transform.position;
        originRot = transform.rotation;
        originScale = transform.localScale;
    }
    public override void HideBoxEdit()
    {
        base.HideBoxEdit();
    }
    public override void ShowBoxEdit()
    {
        base.ShowBoxEdit();
    }
    public override void OnSCPointerDown(InputDevicePartBase part, SCPointEventData eventData)
    {
        base.OnSCPointerDown(part, eventData);
    }
    public override void OnSCPointerUp(InputDevicePartBase part, SCPointEventData eventData)
    {
        base.OnSCPointerUp(part, eventData);
    }

    public override void OnSCPointerDrag(InputDevicePartBase part, SCPointEventData eventData)
    {
        if (!isEditing)
        {
            isEditing = true;
        }  
        if(isEditing)
        {
            base.OnSCPointerDrag(part, eventData);
            changeLine();
        }
    }

    public override void Update()
    {
        base.Update();
        if(!isRecorded)
        {

        }
    }

    public override void InitEulerManager()
    {
        base.InitEulerManager();
    }

    public override void InitScaleManager()
    {
        base.InitScaleManager();
    }

}
