using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using exp = Experiment;
using UnityEngine.SceneManagement;

public class FakeCatFR : exp.Experiment {

    public int nLists;
    public readonly string[] Categories = { "Animal", "Vegetable", "Mineral" };
    public Text text;



    public override IEnumerator RunTrial()
    {
        foreach (string category in Categories)
        {

            text.text = category;
            yield return new WaitForSeconds(2);
        }
    }


}
