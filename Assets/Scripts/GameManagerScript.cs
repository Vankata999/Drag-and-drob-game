using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public Text question1;
    public Text question2;
    public Text question3;
    public Text question4;
    private static int totalCount = 4;

    private bool flag;

    private Vector2[] positions = new Vector2[totalCount];

    [HideInInspector]
    public static int score;

    public GameObject[] logos = new GameObject[totalCount];
    public GameObject[] boxes = new GameObject[totalCount];
    public GameObject[] statements = new GameObject[totalCount];
            
    void Start()
    {
        SetPositions();
        AssignStatements();
    }

    void Update()
    {
        CheckChildCount();
        if(flag)
        {
            CheckScore();
        }
    }

    public List<int> GenerateRandomList()
    {
        List<int> list = new List<int>();
        int rand;
        for (int i = 0; i < totalCount; i++)
        {
            rand = Random.Range(0, totalCount);

            while (list.Contains(rand))
            {
                rand = Random.Range(0, totalCount);
            }

            list.Add(rand);
        }

        return list;
    }

    void SetPositions()
    {
        List<int> randomList = GenerateRandomList();
        for (int i = 0; i < totalCount; i++)
        {
            positions[i] = statements[i].GetComponent<RectTransform>().transform.position;
        }
        for (int i = 0; i < totalCount; i++)
        {
            statements[i].GetComponent<RectTransform>().transform.position = positions[randomList[i]];
        }
        for (int i = 0; i < totalCount; i++)
        {
            positions[i] = boxes[i].GetComponent<RectTransform>().transform.position;
        }
        for (int i = 0; i < totalCount; i++)
        {
            boxes[i].GetComponent<RectTransform>().transform.position = positions[randomList[i]];
        }
    }

    void AssignStatements()
    {
        for (int i = 0; i < totalCount; i++)
        {
            string statementText = "";
            
            switch(i)
            {
                case 0:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = question1.text;
                            break;
                        case 1:
                            statementText = question1.text; ;
                            break;
                        case 2:
                            statementText = question1.text; ;
                            break;
                    }
                    break;

                case 1:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = question2.text; ;
                            break;
                        case 1:
                            statementText = question2.text; ;
                            break;
                        case 2:
                            statementText = question2.text; ;
                            break;
                    }
                    break;

                case 2:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = question3.text; ;
                            break;
                        case 1:
                            statementText = question3.text; ;
                            break;
                        case 2:
                            statementText = question3.text; ;
                            break;
                    }
                    break;

                case 3:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = question4.text; ;
                            break;
                        case 1:
                            statementText = question4.text; ;
                            break;
                        case 2:
                            statementText = question4.text; ;
                            break;
                    }
                    break;
            }
            statements[i].GetComponent<Text>().text = statementText;
        }
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

    void CheckScore()
    {
        score = 0;
        for (int i = 0; i < totalCount; i++)
        {
            if (logos[i].transform.parent == boxes[i].transform)
            {
                score++;
            }
        }
        StartCoroutine(Wait());        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<ChangeScene>().SwitchScene("finish");
    }
}
