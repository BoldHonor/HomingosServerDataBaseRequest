using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiData : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class MemoData
    {
        public string type;
        public string url;
        public string caption;
    }
    [System.Serializable]
    public class Resources
    {
        public MemoData[] resources;
    }

    public TextAsset jsonFile;

    void Start()
    {

        string str = File.ReadAllText(Application.dataPath + "/data.txt");
        Debug.Log(str);
        Resources res = JsonUtility.FromJson<Resources>(jsonFile.text);
        Debug.Log(res.resources[1].type);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
