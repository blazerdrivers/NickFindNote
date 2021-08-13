using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Option : MonoBehaviour
{
    public bool Use_GString;
    public bool Use_DString;
    public bool Use_AString;
    public bool Use_EString;

    // Start is called before the first frame update
    void Start()
    {
        Use_GString = true;
        Use_DString = true;
        Use_AString = true;
        Use_EString = true;
    }

    public void EffectsOnG(bool value){
      
        if (value == true) {
            print("G-string On");
            Use_GString = true;
        } else {
            print("G-string Off");
            Use_GString = false;
        }
    }
    public void EffectsOnD(bool value){
      
        if (value == true) {
            print("D-string On");
            Use_DString = true;
        } else {
            print("D-string Off");
            Use_DString = false;
        }
    }
    public void EffectsOnA(bool value){
      
        if (value == true) {
            print("A-string On");
            Use_AString = true;
        } else {
            print("A-string Off");
            Use_AString = false;
        }
    }
    public void EffectsOnE(bool value){
      
        if (value == true) {
            print("E-string On");
            Use_EString = true;
        } else {
            print("E-string Off");
            Use_EString = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
