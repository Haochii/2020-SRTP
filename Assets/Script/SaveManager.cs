using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public EmojiManager emojiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //检测用户主动退出：
        if (Input.GetKey(KeyCode.Escape))
        {
            emojiManager.SavetoFile();
        }
    }

    private bool isPause;
    //这个是用来检测玩家后台关闭应用（移动端）
    private void OnApplicationPause(bool pause)
    {
        if (pause) //后台杀死了应用
        {
            isPause = true;
            emojiManager.SavetoFile();            
        }
        else
        {
            isPause = false;
        }
    }
    //用户通过退出（Application.Quit）退出时调用：别听他们瞎说什么安卓不触发这个，一样触发
    private void OnApplicationQuit()
    {
        if (!isPause) //这里加一个用户没有自己清除后台判断（通过上面的周期函数就知道了）
        {
            emojiManager.SavetoFile();
        }
    }

}
