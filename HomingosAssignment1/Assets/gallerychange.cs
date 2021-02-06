using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class gallerychange : MonoBehaviour
{
    // Start is called before the first frame update
    static int totalMemories = 5;
    [SerializeField] GameObject[] memories = new GameObject[totalMemories];
    int currentMemory =0;
    
    void Start()
    {
        Debug.Log("safd");
        Debug.Log(memories.Length);
        foreach(GameObject memo in memories)
        {
            memo.GetComponent<MeshRenderer>().enabled = false;
            
        }
        memories[currentMemory].GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void next()
    {
        if (currentMemory == totalMemories - 1) return;
        memories[currentMemory].GetComponent<MeshRenderer>().enabled = false;
        currentMemory++;
        memories[currentMemory].transform.position = new Vector3(0,0.4f,0);
        Debug.Log("safd");
        Debug.Log(memories.Length);
        return;
        


    }
}
