using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveEmojis
{
    public List<Vector3> EmojiPosList = new List<Vector3>();
    public List<Vector3> EmojiScaleList = new List<Vector3>();
    public List<Quaternion> EmojiRotList = new List<Quaternion>();
    public List<Vector3> EmojiVelocityList = new List<Vector3>();
    public List<int> EmojiTypeList = new List<int>();

}