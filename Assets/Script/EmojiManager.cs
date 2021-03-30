using SC.XR.Unity;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EmojiManager : MonoBehaviour
{
    //Store emojis
    //public List<GameObject> editingEmoji = new List<GameObject>();
    public List<GameObject> emittedEmoji = new List<GameObject>();
    public List<GameObject> prefabEmoji = new List<GameObject>();
    public GameObject[] emojiTemplates;
    public string fileName = "Emojis.json";
    private string path = "";
    private bool isLoaded = false;
    public float emojiMinVelocity = 2.0f;
    public float emojiMaxVelocity = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath;
        emojiTemplates = GameObject.FindGameObjectsWithTag("Template");
    }


    // Update is called once per frame
    void Update()
    {
        if (!isLoaded)
        {
            LoadFile();
            isLoaded = true;
        }
        gotocenter();
    }

    private void gotocenter()
    {
        GameObject center = GameObject.FindWithTag("sculpture");
        foreach(GameObject emoji in emittedEmoji)
        {
            if(emoji != null && emoji.GetComponent<Emoji>().emojiType != 1)
            {
                if ((emoji.GetComponent<Transform>().position - center.GetComponent<Transform>().position).sqrMagnitude > 0.4 * 0.4)
                {
                    emoji.GetComponent<Rigidbody>().AddForce((center.GetComponent<Transform>().position - emoji.GetComponent<Transform>().position).normalized);
                }
            }
        }
    }
     
    public void EmitAllEmoji()
    {
        
        //Let template work
        for (int i = 0; i < emojiTemplates.Length; i++)
        {
            if (emojiTemplates[i].GetComponent<EmojiTemplate>().isEditing == true)
            {
                int emittedType = emojiTemplates[i].GetComponent<EmojiTemplate>().emojiType;

                for (int j=0; j<prefabEmoji.Count; j++)
                {
                    if(emittedType == prefabEmoji[j].GetComponent<Emoji>().emojiType)
                    {

                        GameObject emoji = Instantiate(prefabEmoji[j], emojiTemplates[i].GetComponent<Transform>().position, emojiTemplates[i].GetComponent<Transform>().rotation);
                        //emoji.transform.localScale = emojiTemplates[i].GetComponent<Transform>().localScale;

                        Rigidbody rigidBody = emoji.GetComponent<Rigidbody>();
                        float vx = Random.Range(emojiMinVelocity, emojiMaxVelocity);
                        float vy = Random.Range(emojiMinVelocity, emojiMaxVelocity);
                        float vz = Random.Range(emojiMinVelocity, emojiMaxVelocity);
                        rigidBody.velocity = new Vector3(vx, vy, vz);

                        emittedEmoji.Add(emoji);

                        emojiTemplates[i].GetComponent<EmojiTemplate>().reset();
                        emojiTemplates[i].GetComponent<CameraFollower>().enabled = true;

                        //Debug.Log("Emit Pressed");
                    }
                }
            }
        }
    }

    public void ClearAllEmoji()
    {
        for (int i = 0; i < emittedEmoji.Count; i++)
        {
            Destroy(emittedEmoji[i]);
        }
        emittedEmoji.Clear();
    }

    private SaveEmojis CreateSaveEmojisObject()
    {
        SaveEmojis saveEmojis = new SaveEmojis();

        for (int i = 0; i < emittedEmoji.Count; i++)
        {
            if(emittedEmoji[i] != null && emittedEmoji[i].GetComponent<Emoji>().emojiType != 1) // is not bomb
            {
                saveEmojis.EmojiTypeList.Add(emittedEmoji[i].GetComponent<Emoji>().emojiType);
                saveEmojis.EmojiPosList.Add(emittedEmoji[i].GetComponent<Transform>().position);
                saveEmojis.EmojiRotList.Add(emittedEmoji[i].GetComponent<Transform>().rotation);
                saveEmojis.EmojiScaleList.Add(emittedEmoji[i].GetComponent<Transform>().localScale);
                saveEmojis.EmojiVelocityList.Add(emittedEmoji[i].GetComponent<Rigidbody>().velocity);
            }     
        }
        Debug.Log("Emojis Saved");
        return saveEmojis;
    }

    public void SavetoFile()
    {
        // 1 
        SaveEmojis save = CreateSaveEmojisObject();
        string json = JsonUtility.ToJson(save);

        // 2
        string filePath = Path.Combine(path, fileName);
        if (!File.Exists(filePath))
        {
            FileStream fs = File.Create(filePath);
            fs.Flush();
            fs.Close();
        }
        File.WriteAllText(filePath, json);


        Debug.Log("Write OK");
    }

    public void LoadFile()
    {
        string filePath = Path.Combine(path, fileName);
        Debug.Log("filepath:"+ filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("Start Read");
            string json = File.ReadAllText(filePath);
            Debug.Log("json Read OK");
            SaveEmojis save = JsonUtility.FromJson<SaveEmojis>(json);
            Debug.Log("json to Object OK");
            Debug.Log(json);
            for (int i = 0; i < save.EmojiTypeList.Count; i++)
            {
                GameObject emoji = Instantiate(prefabEmoji[save.EmojiTypeList[i]-1], save.EmojiPosList[i], save.EmojiRotList[i]);
                emoji.GetComponent<Transform>().localScale = save.EmojiScaleList[i];

                Rigidbody rigidbody = emoji.GetComponent<Rigidbody>();
                rigidbody.velocity = save.EmojiVelocityList[i];
                emittedEmoji.Add(emoji);
            }
        }

    }


    public void Quit()
    {
        SavetoFile();
        //Application.Quit();
    }


}
