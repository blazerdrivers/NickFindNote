using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    // Start is called before the first frame update

    public int MaxNumOfQuestion;
    public int CurrentQuestionID;
    public GameObject QuestionIDObject;
    
    void Start()
    {
        QuestionIDObject = GameObject.Find("Canvas_Bg/Question number");
        
        CurrentQuestionID = 1;
        MaxNumOfQuestion = 3;
    }

    // Update is called once per frame
    void Update()
    {
        QuestionIDObject.GetComponent<Text>().text = CurrentQuestionID.ToString() + "/" + MaxNumOfQuestion.ToString();
    }
}
