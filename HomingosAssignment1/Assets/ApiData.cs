using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
public class ApiData : MonoBehaviour
{


    //classes-----------------------------------------------------------------------------
    [System.Serializable]
    public class MemoData
    {
        public string type;
        public string url;
        public string caption;
    }
    [System.Serializable]
    public class Res
    {
        public MemoData[] resources;
    }

    //variables-----------------------------------------------------------
    public TextAsset jsonFile;
    
    static public Res res;
    public GameObject GalleryCanvas;
    [SerializeField] GameObject caption;
    MeshRenderer GalleryRender;
    VideoPlayer GalleryPlayer;
    int currentMedia = 0;
    int previousMedia = 2;
    bool stateChange = false;
    bool previousState =false;
    public Texture2D loading;
    
    //methods--------------------------------------------------------------
    void Start()
    {
        GalleryRender = GalleryCanvas.GetComponent<MeshRenderer>();
        GalleryPlayer = GalleryCanvas.GetComponent<VideoPlayer>();
        GalleryPlayer.enabled = false;
        StartCoroutine(RetriveApiData());
        Debug.Log(res.resources.Length);
        
        Display();
    }
    void Update()
    {
        if(GalleryRender.enabled !=previousState)               // minimize load by checking change in state
        {
            previousState = GalleryRender.enabled;
            if(GalleryRender.enabled && previousMedia != currentMedia)                           // proceed if visible
            {
                previousMedia = currentMedia;
                
                Display();

               
            }

            if (!GalleryRender.enabled)                                                                //stops the video When not displayed 
            {
                clear();
            }


        }

    }

    void Display()                                                                      //Displays Current Gallery Element 
    {
        caption.GetComponent<UnityEngine.UI.Text>().text = res.resources[currentMedia].caption;

        if (res.resources[currentMedia].type == "image")
        { StartCoroutine(MediaRetrive()); }

        if (res.resources[currentMedia].type == "video")
        {
            GalleryPlayer.enabled = true;
            videoMedia();
            GalleryPlayer.Play();
        }
    }

    public void next()                                                          //next button
    {
        if (currentMedia == res.resources.Length - 1) return;
        clear();
        currentMedia++;
        Debug.Log(res.resources.Length);
        StopCoroutine(MediaRetrive());
        Display();

    }

    public void back()                                                          //prevous button
    {
        if (currentMedia == 0) return;
        clear();
        currentMedia--;
        StopCoroutine(MediaRetrive());
        Display();

    }

    void videoMedia()                                                       //loads video in player
    {
        GalleryPlayer.url = res.resources[currentMedia].url;
        
    }

    void clear()                                                                //clears screen 
    {
        GalleryPlayer.Stop();
        GalleryPlayer.enabled = false;
        GalleryRender.material.mainTexture = loading;
    }


    //corutines------------------------------------------------------------
    IEnumerator RetriveApiData()
    {
        UnityWebRequest retrivedRequestData = UnityWebRequest.Get(MainMenu.retiriveData);
         yield return retrivedRequestData.Send();

        if (retrivedRequestData.isNetworkError) { caption.GetComponent<UnityEngine.UI.Text>().text = "Loading..."; }
        else
        {
            if (retrivedRequestData.isDone)
            {


                Debug.Log("retrived ");
                Debug.Log(retrivedRequestData.downloadHandler.text);
                res = JsonUtility.FromJson<Res>(retrivedRequestData.downloadHandler.text);
                Debug.Log(res.resources[1].type);
                Debug.Log(res.resources.Length);
                Display();

            }
        }
    }


    IEnumerator MediaRetrive()
    {
        WWW media = new WWW(res.resources[currentMedia].url);
        yield return media;
        GalleryRender.material.mainTexture = media.texture;


    }


}
