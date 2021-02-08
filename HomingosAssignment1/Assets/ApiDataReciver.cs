using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiDataReciver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        memoryData mem = new memoryData();
        mem.type = "video";
        mem.url = "http//htrp";
        mem.caption = "let it be ";
        string data = JsonUtility.ToJson(mem);
        Debug.Log(data);
        File.WriteAllText(Application.dataPath + "/memores.json", data);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public class memoryData
    {
        public string type;
        public string url;
        public string caption;
    }
}
