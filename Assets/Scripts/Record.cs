using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    // Start is called before the first frame update

    int MaxNumOfQuestion = 10;
    public int CurrentQuestionID;
    public GameObject QuestionIDObject;

    
    
    void Start()
    {
        QuestionIDObject = GameObject.Find("Canvas_Bg/Question number");
        
        CurrentQuestionID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        QuestionIDObject.GetComponent<Text>().text = CurrentQuestionID.ToString() + "/" + MaxNumOfQuestion.ToString();
    }
}
