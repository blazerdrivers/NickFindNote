
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Answer : MonoBehaviour
{
    enum State{idle = 0, Start, Correct, Wrong};
    enum Note{g = 0,a,b,c1,
            d1,e1,f1,g1,
            a1,b1,c2,d2,
            e2,f2,g2,a2,
            b2};
    //enum height{g = 0,a,b,c1,d1,e1,f1,g1,a1,b1,c2,d2,e2,f2,g2,a2,b2}
    //enum Finger{}
    public string[] noteNameSet = new string[17]{
        "g", "a", "b", "c1",
        "d1", "e1", "f1", "g1",
        "a1", "b1", "c2", "d2",
        "e2", "f2", "g2", "a2",
        "b2"
    }; 
    
    private int g_positionY = -28;
    //bool isWrong = false;
    //bool isCorrect = true;

    string Answer_1;
    int Answer_2;

    int GameState = 1;

    int CurrentAnswer;
    public GameObject CurrentNoteObject; 
    public GameObject CorrectSignObject; 
    public GameObject WrongSignObject; 
    public GameObject Input_1;
    public GameObject Input_2;
    public GameObject NoteNameObject;

    public GameObject Line_plusone;
    public GameObject Line_minusone;
    public GameObject Line_minustwo;

    public GameObject Next_Button;

    public Canvas OptionPageObject;
    public bool G_On;
    public bool D_On;
    public bool A_On;
    public bool E_On;

    int currentNote;

    public List<int> RandomSet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("game state is " + (int)State.idle);

        CurrentNoteObject = GameObject.Find("Canvas_Bg/note_1");  
        NoteNameObject = GameObject.Find("Canvas_Bg/Note name");  
        CorrectSignObject = GameObject.Find("Canvas_Bg/correct sign");  
        WrongSignObject = GameObject.Find("Canvas_Bg/wrong sign");  

        Input_1 = GameObject.Find("Canvas_Front/String Input");
        Input_2 = GameObject.Find("Canvas_Front/Finger Input"); 

        Line_plusone = GameObject.Find("Canvas_Bg/line +1");
        Line_minusone = GameObject.Find("Canvas_Bg/line -1");
        Line_minustwo = GameObject.Find("Canvas_Bg/line -2");

        Next_Button = GameObject.Find("Canvas_Front/Next Button");
        OptionPageObject = GameObject.Find("Canvas_Option").GetComponent<Canvas>();

        initNodes();
        initGame();
    }

    void initGame(){
        Debug.Log("init game");

        CorrectSignObject.SetActive(false);
        WrongSignObject.SetActive(false);

        Line_plusone.SetActive(false);
        Line_minusone.SetActive(false);
        Line_minustwo.SetActive(false);
    
        OptionPageObject.enabled = false;  
          

        Next_Button.GetComponent<Button>().interactable = false;
    }

    void initNodes(){
        G_On = GameObject.Find("OptionController").GetComponent<Option>().Use_GString;
        D_On = GameObject.Find("OptionController").GetComponent<Option>().Use_DString;
        A_On = GameObject.Find("OptionController").GetComponent<Option>().Use_AString;
        E_On = GameObject.Find("OptionController").GetComponent<Option>().Use_EString;
    }

    void freshGame(){
        CorrectSignObject.SetActive(false);
        WrongSignObject.SetActive(false);
        Next_Button.GetComponent<Button>().interactable = false;

    }

    bool CalculateAnswer(int note, string str, int fing){

        Debug.Log("note is " + note);
        if(note/4 == 0){ // in G sting
            if(str == "g" && fing == note%4){
                return true;
            } else return false;
            
        } else if (note/4 == 1){
            if(str == "d" && fing == note%4){
                return true;
            } else if (str == "g" && fing == 4){
                return true;
            } else {
                return false;
            }
        } else if (note/4 == 2){ // in a string
            if(str == "a" && fing == note%4){
                return true;
            } else if (str == "d" && fing == 4){
                return true;
            } else {
                return false;
            }
        } else if (note/4 == 3){
            if(str == "e" && fing == note%4){
                return true;
            } else if (str == "a" && fing == 4){
                return true;
            }
            else return false;
            
        } else if (note/4 == 4){
            if(str == "e" && fing == 4){
                return true;
            } else if (str == "a" && fing == 4){
                return true;
            } else return false;
        } else {
            Debug.Log("Error: note is out of range");
            return false;
        }

    }
    

    void DisplayNote(int note){

        if(note >= 15) {
            
            Line_plusone.SetActive(true);
            Line_minusone.SetActive(false);
            Line_minustwo.SetActive(false); 

        } else if (note <= 3 && note > 1){
            Line_plusone.SetActive(false);
            Line_minusone.SetActive(true);
            Line_minustwo.SetActive(false);
        } else if (note <= 1){
            Line_plusone.SetActive(false);
            Line_minusone.SetActive(true);
            Line_minustwo.SetActive(true);
        } else{
            Line_plusone.SetActive(false);
            Line_minusone.SetActive(false);
            Line_minustwo.SetActive(false);
        }
        CurrentNoteObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, g_positionY + note*6);
        NoteNameObject.GetComponent<Text>().text = noteNameSet[note];
        currentNote = note;
        
    }

    public void PendingAnswer(){

        print("in pending");
        
        string StringAnswer = Input_1.GetComponent<InputField>().text;
        string FingerAnswer = Input_2.GetComponent<InputField>().text;
        
        int FingerAnswer_int;
        int.TryParse(FingerAnswer, out FingerAnswer_int);
        
        Debug.Log("Input Data: " + StringAnswer + " " + FingerAnswer);

        bool outcome = CalculateAnswer(currentNote, StringAnswer, FingerAnswer_int); 
        
        if(outcome){
            GameState = (int)State.Correct;
        } else {
            GameState = (int)State.Wrong;
        }
    }

    public void nextfunction(){
        quest();
    }

    void quest(){
        Debug.Log("in quest");
        initNodes();
        RandomSet.Clear();
        if(G_On){
            Debug.Log("G is on");
            for(int i=0; i<=4; i++){
                RandomSet.Add(i);
                
            }    
        } 
        if(D_On){
            for(int i=5; i<=8; i++){
                RandomSet.Add(i);
            }
            if(!G_On) {
                RandomSet.Add(4);
                //print("here0");
            }
        }
        if(A_On){
            for(int i=9; i<=12; i++){
                RandomSet.Add(i);
            } 
            if(!D_On) {
                RandomSet.Add(8);
                //print("here1");
            }   
        }
        if(E_On){
            for(int i=13; i<=16; i++){
                RandomSet.Add(i);
            }    
            if(!A_On) {
                RandomSet.Add(12);

            } 
        }
        
        CurrentNoteObject.SetActive(true);
        //Debug.Log("RandomSet: " + RandomSet.Count);

        int random_pick_note = RandomSet[(Random.Range(0, RandomSet.Count))];
        Debug.Log("pick note number: " + random_pick_note );
        //Debug.Log("actul note get: " + RandomSet)
        DisplayNote(random_pick_note);
        
        GameState = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q)){
            if(!OptionPageObject.enabled)
                OptionPageObject.enabled = true;
            else 
                OptionPageObject.enabled = false;
        }
        if(GameState == (int)State.idle){

            //Debug.Log("Waiting for answer...");
            freshGame();
            if(Input.GetKeyUp(KeyCode.X))
            {
                 //Debug.Log("Press x!");
                 GameState = (int)State.Start;
            }

        }
        else if(GameState == (int)State.Start){
            /*
            CurrentNoteObject.SetActive(true);
            int random_pick_note = Random.Range(0, 17); // Random.Range is [min, max) !!
            Debug.Log("pick note: " + random_pick_note );

            DisplayNote(random_pick_note);

            GameState = 0;
            */
            quest();
        }
        else if(GameState == (int)State.Wrong){
            WrongSignObject.SetActive(true);
            CorrectSignObject.SetActive(false);
           
        } 
        else if(GameState == (int)State.Correct){
            CorrectSignObject.SetActive(true);
            WrongSignObject.SetActive(false);
            Next_Button.GetComponent<Button>().interactable = true;
        } 
    }
}
