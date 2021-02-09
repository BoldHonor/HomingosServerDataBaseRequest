using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Variables -----------------------------------------------------------------------
    static public string retiriveData;
    [SerializeField]public GameObject UrlText;

    //methods -------------------------------------------------------------------------
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAppStart()
    {
        if(UrlText.GetComponent <UnityEngine.UI.Text>().text == "")
        {
            retiriveData = "https://run.mocky.io/v3/6027ded7-2411-4fb0-8433-efc50814abd7";

        }
        else
        {
            retiriveData = UrlText.GetComponent<UnityEngine.UI.Text>().text;
        }

        SceneManager.LoadScene("PrakharHomingos Assignment");
    }
}
