using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameOverWindow : GenericWindow
{
    public TextMeshProUGUI leftStatLabel;
    public TextMeshProUGUI leftStatValue;
    public TextMeshProUGUI rightStatLabel;
    public TextMeshProUGUI rightStatValue;
    public TextMeshProUGUI scoreValue;

    public Button nextButton;

    private Coroutine routine;

    public float statsDelay = 1f;
    public float scoreDuration = 2f;

    private const int totalState = 6;
    private const int statsperColum = 3;

    public int[] statsRolls = new int[totalState];
    private int finalScore;

    private TextMeshProUGUI[] statsLabels;
    private TextMeshProUGUI[] statsValue;

    private void Awake()
    {
        statsLabels = new TextMeshProUGUI[] { leftStatLabel, rightStatLabel };
        statsValue = new TextMeshProUGUI[] { leftStatValue, rightStatValue };

        nextButton.onClick.AddListener(OnNext);

    }

    public override void Open()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }

        base.Open(); 
        ResetStat();
        routine = StartCoroutine(CoPlayGameOverRoutine());


        
    }

    public override void Close()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        base.Close();
        ResetStat();
    }

    private void OnNext()
    {
        windowManager.Open(0);
    }


    private void ResetStat()
    {

        for (int i = 0; i < totalState; i++)
        {
            statsRolls[i] = Random.Range(0, 1000);
        }
        finalScore = Random.Range(10, 10000000);

        for (int i = 0; i < statsLabels.Length; i++)
        {
            statsLabels[i].text = string.Empty;
            statsValue[i].text = string.Empty;
        }

        scoreValue.text = $"{0:D9}";
    }

    private IEnumerator CoPlayGameOverRoutine()
    {
        for (int i = 0; i < totalState; i++)
        {
            yield return new WaitForSeconds(statsDelay);

            int colum = i / statsperColum;
            var labelText = statsLabels[colum];
            var valueText = statsValue[colum];

            string newline = (i % statsperColum == 0) ? string.Empty : "\n";
            labelText.text = $"{labelText.text}{newline}Stat{i}";
            valueText.text = $"{valueText.text}{newline}{statsRolls[i]:D4}";
        }

        int current = 0;
        float t = 0f;
        while(t < scoreDuration)
        {
            t += Time.deltaTime / scoreDuration;
            current = Mathf.FloorToInt(Mathf.Lerp(0, finalScore, t));
            scoreValue.text = $"{current:D9}";
            yield return null;
        }

        scoreValue.text = $"{finalScore:D9}";
        routine = null;
    }
}