using LGS.Common_20200526;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNetWork : MonoBehaviour
{

    public TextMesh registerText;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
       
        NetStatus.Instant.RegisterNetWorkChangeCallBack(NetWorkChange);
        textMesh.text = "获取当前网络信息中";
        registerText.text = "网络状态变化时触发";
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = NetStatus.Instant.SCGetNetWorkInfo();
    }

    private void NetWorkChange(NetworkReachability preNetWorkStatus, NetworkReachability internetReachability)
    {
        registerText.text = "网络状态变化时触发===》"+internetReachability.ToString();
    }
    
}
