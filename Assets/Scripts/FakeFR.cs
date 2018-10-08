using System.Collections;
using exp = Experiment;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FakeFR : Experiment.Experiment
{
    public int listno = 0;
    public int wordno;
    public int words_per_list = 5;
    public Text text;
    public GameObject canvas;

    protected string GetText(){
        return string.Format("List {0} \n Word {1} goes here", listno, wordno);
    }

    public String Name() { return "FR"; }

    // Use this for initialization




    public override IEnumerator RunTrial()
    // Runs through a single list
    {

        for (wordno = 0; wordno < words_per_list; wordno++)
        {
            text.text = GetText();
            yield return new WaitForSeconds(1.0f);
        }
        listno++;
    }
}       
