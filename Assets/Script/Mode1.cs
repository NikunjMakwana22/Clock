using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mode1 : MonoBehaviour
{
    public int qHr, qMin;
    [SerializeField]
    TextMeshProUGUI QuestionText;
    [SerializeField]
    ButtonManager Bm;
    [SerializeField]
    TextMeshProUGUI InfoText;
    [SerializeField]
    Button b1, b2;

    //private void Start()
    //{
    //    Bm.SetRandomTime();
    //    GenerateQuestion();
    //}
    private void OnEnable()
    {
        Bm.SetRandomTime();
        GenerateQuestion();
    }
    //private void Awake()
    //{
    //    Bm.SetRandomTime();
    //    GenerateQuestion();
    //}
    public void GenerateQuestion()
    {
        b1.interactable = true;
        b2.interactable = true;
        GetRandomTime();
        if (qMin == 12)
        {
            QuestionText.text = "Set the Clock Time to " + qHr.ToString("00") + ":00";
        }
        else
        {
            QuestionText.text = "Set the Clock Time to " + qHr.ToString("00") + ":" + (qMin * 5).ToString("00");
        }
    }
    private void GetRandomTime()
    {
        qHr = Random.Range(1, 12);
        qMin = Random.Range(1, 12);
    }

    public  IEnumerator NextQuestion()
    {
        b1.interactable = false;
        b2.interactable = false;
        InfoText.text = "Next Question In 5";
        yield return new WaitForSeconds(1);
        InfoText.text = "Next Question In 4";
        yield return new WaitForSeconds(1);
        InfoText.text = "Next Question In 3";
        yield return new WaitForSeconds(1);
        InfoText.text = "Next Question In 2";
        yield return new WaitForSeconds(1);
        InfoText.text = "Next Question In 1";
        yield return new WaitForSeconds(1);
        InfoText.text = "";
        GenerateQuestion();
    }
}
