using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "ExperimentPipeline", menuName = "ExperimentPipeline")]
public class ExperimentPipeline: ScriptableObject
{
    public readonly List<KeyValuePair<string, int>> pipeline = new List<KeyValuePair<string, int>>();

    public string current_experiment = "None";
    public int current_num_trials = 0;

    public void FromFile(string filename)
    {
        pipeline.Clear();
        var stream = new FileStream(filename, FileMode.Open,
                            FileAccess.Read);
        var reader = new StreamReader(stream);
        string config_line;
        while (!reader.EndOfStream)
        {
            config_line = reader.ReadLine().Trim();
            string[] parts = config_line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                var experiment_name = parts[0];
                var nLists = int.Parse(parts[1]);
                pipeline.Add(new KeyValuePair<string, int>(experiment_name, nLists));

            }
        }
    }

    public void AddExperiment(string name, int n_lists){
        pipeline.Add(new KeyValuePair<string, int>(name, n_lists));
    }

    public void Reset()
    { pipeline.RemoveAll(x => true); }

    public void RunNextExperiment()
    {
        if (pipeline.Count > 0)
        {
            current_experiment = pipeline[0].Key;
            current_num_trials = pipeline[0].Value;
            SceneManager.LoadSceneAsync(current_experiment);
            pipeline.RemoveAt(0);
        }
        else { SceneManager.LoadSceneAsync("MainScene"); } // TODO: replace this with a "finished" scene
    }


    public override string ToString()
    {

        var repr = from p in pipeline
                   select String.Format("{0} {1}", p.Key, p.Value);
        return String.Join("\n", repr.ToArray());
    }


}
