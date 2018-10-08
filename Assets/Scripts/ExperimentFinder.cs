using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExperimentFinder : MonoBehaviour {

    private Scene newScene;
    public string sceneName;

    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindExperiments(){
        var n_experiments = 0;
        for (var i = 1; i < SceneManager.sceneCountInBuildSettings; i++ ){
            SceneManager.LoadScene(i, LoadSceneMode.Additive);
            newScene = SceneManager.GetSceneByBuildIndex(i);

            Debug.Log(newScene.name);

            //SceneManager.SetActiveScene(newScene);
            var exp = GameObject.Find(newScene.name);
            if (exp != null) n_experiments += 1;

        }
        text.text = n_experiments.ToString() + " experiments found";
        for (var i = 1; i < SceneManager.sceneCount; i++)
        { SceneManager.UnloadSceneAsync(i); }
    }
}
