using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private static int totalCount = 4;

    private bool flag;
    public GameObject[] boxes = new GameObject[totalCount];
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    GameObject[] items;
    bool youwon = false;

    // Use this for initialization
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckChildCount();
        timerIsRunning = true;
       // items = GameObject.FindGameObjectsWithTag("item");
        if (timerIsRunning)
        {

            if (flag)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                //youwon = true;
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else if (timeRemaining <= 0 && flag==false)
            {
                // Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                reloadGame();
            }
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void reloadGame()
    {
        Application.LoadLevel("splash");
    }

    void CheckChildCount()
    {
        int childrenCount = 0;

        for (int i = 0; i < totalCount; i++)
        {
            if (boxes[i].transform.childCount > 0)
            {
                childrenCount++;
            }
        }
        if (childrenCount == totalCount)
        {
            flag = true;
        }
    }

}
