using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GracesGames.SimpleFileBrowser.Scripts;

namespace Config
{
    public class ConfigManager : MonoBehaviour
    {


        // Initialized in visual editor
        public Dropdown TaskDropdown;
        public Text NListsText;
        public Button LaunchButton;
        public Button ConfigButton;
        public GameObject FileBrowserPrefab;
        public Text ConfigText;

        public ExperimentPipeline pipeline;

        // Use this for initialization
        void Start()
        {
            var MainScene = SceneManager.GetSceneByName("MainScene");


            // Scene dropdown code from https://answers.unity.com/questions/1128694/how-can-i-get-a-list-of-all-scenes-in-the-build.html
            var optionDataList = new List<Dropdown.OptionData>();

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; ++i)
            {
                string _name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                if (_name != MainScene.name)
                {
                    optionDataList.Add(new Dropdown.OptionData(_name));
                }
            }

            TaskDropdown.ClearOptions();
            TaskDropdown.AddOptions(optionDataList);

            LaunchButton.onClick.AddListener(AddExperiment);


            // Config loader 

            ConfigButton.onClick.AddListener(LaunchFileBrowserAndGetConfigName);
            var RunConfigButton = GameObject.Find("RunConfigButton");
            RunConfigButton.GetComponent<Button>().onClick.AddListener(LaunchPipeline);
        
        }

        private void Update()
        {
            ConfigText.text = pipeline.ToString();
        }


        void LoadConfig(string configName)
        {
            pipeline.FromFile(configName);

            Debug.unityLogger.Log(pipeline.ToString());
        }

        private void LaunchFileBrowserAndGetConfigName()
        {
            GameObject FileBrowserObject = Instantiate(FileBrowserPrefab, ConfigButton.gameObject.transform);
            // On instantiating the prefab, gain a reference to 
            FileBrowser browser = FileBrowserObject.GetComponent<FileBrowser>();
            browser.SetupFileBrowser(ViewMode.Landscape); // TODO: MAKE THIS MORE DYNAMIC?
            browser.OpenFilePanel(new string[] { });
            browser.OnFileSelect += LoadConfig;
        }


        public void AddExperiment()
        {
            string experiment_name = TaskDropdown.captionText.text;
            string nlists_string = NListsText.text;
            int nlists;
            if (int.TryParse(nlists_string, out nlists)){
                pipeline.AddExperiment(experiment_name, nlists);
            }
        }

        // May or may not use external config files
        void LaunchPipeline()
        {
            pipeline.RunNextExperiment();
        }


    }

}



