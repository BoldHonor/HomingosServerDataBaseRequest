using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
    string retiriveData = "https://run.mocky.io/v3/6027ded7-2411-4fb0-8433-efc50814abd7" ;


    void Start()
    {
        UnityWebRequest retrivedRequestData = UnityWebRequest.Get(retiriveData);
        if(retrivedRequestData.isNetworkError)
        {
            Debug.Log("cant retrive Data"); 
        }

        string str = File.ReadAllText(Application.dataPath + "/data.txt");
        Debug.Log(retrivedRequestData.downloadHandler.text);
        retrivedRequestData.Send();
        Resources res = JsonUtility.FromJson<Resources>(retrivedRequestData.downloadHandler.text);
        Debug.Log(res.resources[1].type);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
