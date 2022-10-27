using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int Score;
    TMP_Text  score_text;

   void Start() {
       score_text = GetComponent<TMP_Text>();
       score_text.text = "START";
   }
    public void IncreaseScore(int AmountToIncrease){

        Score += AmountToIncrease;
        score_text.text= Score.ToString();
    }
        
    
}
