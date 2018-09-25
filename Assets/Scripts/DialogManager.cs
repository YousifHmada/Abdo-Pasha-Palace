using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    static public TextAsset questionesFile;
    public Text questionText, answer1Text, answer2Text, answer3Text, answer4Text;
    int noRows = 6;
    string[,] questions;
    GameObject Dialog;
    private void Start()
    {
        Dialog = GameObject.Find("Dialog");
        Dialog.SetActive(false);
    }


    public string[,] GetQuestionData()
    {
        string[] x = questionesFile.text.Split('\n'); // split each question and it's answers
        string[,] y = new string[x.Length, noRows];
        for (int i = 0; i < x.Length; i++)
        {
            string[] temp = x[i].Split(','); //seperate question from answers and answers from answers
            for (int j = 0; j < temp.Length; j++)
            {
                y[i, j] = temp[j]; //2d array where i represents each question entry and j =0 is question and j>0 is answers till j = 4
            }
        }
        return y;
    }
    public void CloseButton()
    {
        Dialog.SetActive(false);
    }
}
