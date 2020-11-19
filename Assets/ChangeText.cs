using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public TextMesh textMesh;

    public void ChangeTextShow3DButton()
    {
        if (textMesh)
        {
            textMesh.text = "点击了3D按钮";
        }
    }

    public void ChangeTextShow2DButton()
    {
        if (textMesh)
        {
            textMesh.text = "点击了2D按钮";
        }
    }

    public void ChangeTextShow2DButtonAuto()
    {
        if (textMesh)
        {
            textMesh.text = "自动点击了2D按钮";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}