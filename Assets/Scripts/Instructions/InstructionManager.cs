using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_Clip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip objectiveClearClip;

    [SerializeField] private List<InstructionStep> instructionSteps = new List<InstructionStep>();
    [SerializeField] private Text instructionText;
    [SerializeField] private Text currentAbjadText;
    [SerializeField] private Level currentLevel;

    [SerializeField] private int wordGoal = 0;
    [SerializeField] private int stepIndex = 0;
    [SerializeField] private int wordCount = 0;
    [SerializeField] private string instructionCommand;

    private string currentAlphabet;

    public int StepIndex => stepIndex;
    public Level CurrentLevel => currentLevel;
    public List<InstructionStep> InstructionSteps => instructionSteps;


    public delegate void SubmitInstruction();
    public static event SubmitInstruction OnWrongSubmit;
    public static event SubmitInstruction OnCorrectSubmit;

    public enum Level
    {
        LevelDasar1,
        LevelDasar2,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    private void OnEnable()
    {
        switch (currentLevel)
        {
            case Level.LevelDasar1:
                Debug.Log("Sekarang level dasar 1");
                break;
            case Level.LevelDasar2:
                Debug.Log("Sekarang level dasar 2");
                break;
            case Level.Level1:
                Debug.Log("Sekarang level 1");
                wordGoal = 2;
                break;
            case Level.Level2:
                Debug.Log("Sekarang level 2");
                wordGoal = 2;
                break;
            case Level.Level3:
                Debug.Log("Sekarang level 3");
                wordGoal = 2;
                break;
            case Level.Level4:
                Debug.Log("Sekarang level 4");
                wordGoal = 3;
                break;
            case Level.Level5:
                Debug.Log("Sekarang level 5");
                wordGoal = 3;
                break;
            default:
                Debug.Log("No level found");
                break;
        }
    }

    private void OnDisable()
    {
        switch (currentLevel)
        {
            case Level.LevelDasar1:
                break;
            case Level.LevelDasar2:
                break;
            case Level.Level1:
                break;
            case Level.Level2:
                break;
            case Level.Level3:
                break;
            case Level.Level4:
                break;
            case Level.Level5:
                break;
            default:
                Debug.Log("No level found");
                break;
        }
    }

    private void SetAlphabet(string alphabet)
    {
        currentAlphabet = alphabet;

        if (currentAlphabet == instructionSteps[stepIndex].ObjectiveGoal)
        {
            m_AudioSource.PlayOneShot(correctClip);
            OnCorrectSubmit?.Invoke();
            instructionSteps[stepIndex].SetBool();
            if (currentLevel != Level.LevelDasar1)
            {
                StartCoroutine(WaitStep());
                return;
            }
            NextStep();
        }
    }

    [ContextMenu("Next Step")]
    private void NextStep()
    {
        if (stepIndex < instructionSteps.Count)
        {
            instructionSteps[stepIndex].gameObject.SetActive(false);
            stepIndex++;

            if (stepIndex >= instructionSteps.Count)
            {
                Debug.Log("Objective clear!");
                instructionText.text = "Objektif tercapai! SIlahkan menuju pintu keluar!!";
                m_AudioSource.PlayOneShot(objectiveClearClip);
                return;
            }
            else
            {
                instructionText.text = "''" + instructionSteps[stepIndex].ObjectiveGoal + "''";
                instructionSteps[stepIndex].gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator WaitStep()
    {
        yield return new WaitForSecondsRealtime(3f);
        NextStep();
    }

    private IEnumerator ResetWord()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        wordCount = 0;
        currentAlphabet = "";
        currentAbjadText.text = "";
    }

    public void ReplayInstruction()
    {
        instructionSteps[stepIndex].RepeatInstruction();
    }
}
