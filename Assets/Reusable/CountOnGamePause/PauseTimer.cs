using System.Collections;
using System;
using UnityEngine;
using TMPro;
public class PauseTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI conterText;
    int counter = 1;
    bool isStarted = false;
    DateTime pauseDateTime;
    void Start()
    {
        isStarted = true;
        StartCoroutine(Count());
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isStarted)
        {
            if (isPaused)
            {
                pauseDateTime = DateTime.Now;
            }
            else
            {
                counter = (int)(DateTime.Now - pauseDateTime).TotalSeconds;
            }

        }
    }

    IEnumerator Count()
    {
        while (true)
        {
            conterText.text = (counter++).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
