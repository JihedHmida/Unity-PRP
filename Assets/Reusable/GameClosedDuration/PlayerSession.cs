using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSession : MonoBehaviour
{

    [SerializeField] GameObject welcomePopup;
    [SerializeField] TextMeshProUGUI welcomePopupDuration;
    public static PlayerSession I { get; private set; }

    void Awake()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        //welcomePopupShow();
        Debug.Log("app Started");
        string dateQuitString = PlayerPrefs.GetString("dateQuit", "");
        if (!dateQuitString.Equals(""))
        {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit)
            {
                TimeSpan timeSpan = dateNow - dateQuit;

                //TODO Change to Preferred Duration 
                int seconds = (int)timeSpan.TotalSeconds;
                Debug.Log("qui for :" + seconds + "seconds");
                welcomePopupDuration.text = seconds + " SECONDS";

            }
            PlayerPrefs.SetString("dateQuit", "");

        }

    }

    private void OnApplicationQuit()
    {
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
        Debug.Log("quit at :" + dateQuit.ToString());
    }

    private void welcomePopupShow()
    {
        welcomePopup.SetActive(true);
    }
    public void welcomePopupHide()
    {
        welcomePopup.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
