using System;
using System.Collections;
using UnityEngine;
namespace Experiment
{
    public abstract class Experiment : MonoBehaviour
    {
        public abstract IEnumerator RunTrial();
        public ExperimentPipeline pipeline;

        public IEnumerator Start()
        {

            var nLists = pipeline.current_num_trials;

            for (int i = 0; i < nLists; i++)
            {
                yield return RunTrial();

            }
            pipeline.RunNextExperiment();
        }

    }

    /// <summary>
    /// This struct contains all the settings required to run an FR experiment.
    /// 
    /// The behavior of the experiment will automatically adjust according to these settings.
    /// </summary>
    public class ExperimentSettings
    {
        public WordListGenerator wordListGenerator; //how the words for this experiment will be created and organized.  for a full list of parameters and what they do, see the comments for WordListGenerator in WordListGenerator.cs
        public string experimentName; //the name of the experiment.  this will be displayed to the user and sent to ramulator.
        public string version; //the version of the experiment.  for logging purposes.
        public int numberOfLists; //how many lists to display to the participant.
        public int wordsPerList; //how many words in each list.
        public int microphoneTestLength; //how long to record for in the microphone test
        public float wordPresentationLength; //how long each word will be on the screen.  normally 1.6 seconds.
        public float minISI; //the minimum length to wait in between words.
        public float maxISI; //the maximum length to wait in between words.  a random value between min and max will be chosen with uniform distribution.
        public float distractionLength; //how many seconds minimum should the distractor period be.  when this time expires, the distractor period will end after the current problem is submitted.
        public float answerConfirmationTime; //how long to display feedback to the participant for after they submit a distractor answer.  normally 0, as current experiments do not display visual feedback at all.
        public float recallLength; //how many second to record vocal recall responses for after the distraction period.
        public float minOrientationStimulusLength; //minimum amount of time the "+" appears for before words.
        public float maxOrientationStimulusLength; //maximum amount of time the "+" appears for before words. a random value between min and max will be chosen with uniform distribution.
        public float minPauseBeforeRecall; //minimum amount of time to wait after the last distractor is entered before recall begins.
        public float maxPauseBeforeRecall; //maximum amount of time to wait after the last distractor is entered before recall begins. a random value between min and max will be chosen with uniform distribution.
        public float recallTextDisplayLength; //how long to display "****" for at the beginning of the recall period.
        public bool useRamulator; //whether or not the task should try to connect to and send messages to ramulator.
        public bool isTwoParter; //whether or not the experiment should divide the word pool in two and alternative halves between sessions.
        public bool isCategoryPool; //whether or not the catFR wordpool is used.
        public bool useSessionListSelection; //whether or not the list to begin from can be chosen in the start screen.


        public static ExperimentSettings FRExperimentSettings = new ExperimentSettings
        {
            experimentName = "FR1",
            version = "1.0",
            wordListGenerator = new FRListGenerator(0, 13, 0, 0, 0, 0, 0),
            isCategoryPool = false,
            numberOfLists = 13,
            wordsPerList = 12,
            wordPresentationLength = 1.6f,
            minISI = 0.75f,
            maxISI = 1f,
            distractionLength = 20f,
            answerConfirmationTime = 0f,
            recallLength = 30f,
            microphoneTestLength = 5,
            minOrientationStimulusLength = 1f,
            maxOrientationStimulusLength = 1.4f,
            minPauseBeforeRecall = 1f,
            maxPauseBeforeRecall = 1.4f,
            recallTextDisplayLength = 1f,
            isTwoParter = true,
            useSessionListSelection = true
        };

    };
}
