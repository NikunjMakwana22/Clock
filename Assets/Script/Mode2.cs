using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mode2 : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Question;
    [SerializeField]
    TextMeshProUGUI InfoText;
    [SerializeField]
    GameObject[] Choice;
    public int qHr, qMin;
    [SerializeField]
    private int CorrectChoice;
    public ButtonManager Bm;
    //private void Start()
    //{
    //    SetClock();
    //}
    private void OnEnable()
    {
        SetClock();
    }
    //private void Awake()
    //{
    //    SetClock();
    //}
    private void SetClock()
    {
        Choice[0].GetComponent<Image>().color = Color.white;
        Choice[1].GetComponent<Image>().color = Color.white;
        Choice[2].GetComponent<Image>().color = Color.white;
        Choice[0].GetComponent<Button>().interactable = true;
        Choice[1].GetComponent<Button>().interactable = true;
        Choice[2].GetComponent<Button>().interactable = true;
        Bm.SetRandomTime();
        qHr = Bm.Hr;
        qMin = Bm.Min;
        SetChoices();
    }
    private void SetChoices()
    {
        CorrectChoice = Random.Range(0, 2);
        for(int i=0;i<3;i++)
        {
            if(i==CorrectChoice)
            {
                Choice[i].GetComponentInChildren<TextMeshProUGUI>().text = qHr.ToString("00") + ":" + (qMin * 5).ToString("00");
            }
            else
            {
                int Rhr=Random.Range(1,12);
                int Rmin=Random.Range(1,12);
                if (Rmin == 12)
                {
                    Choice[i].GetComponentInChildren<TextMeshProUGUI>().text = Rhr.ToString("00") + ":00";
                }
                else
                {
                    Choice[i].GetComponentInChildren<TextMeshProUGUI>().text = Rhr.ToString("00") + ":" + (Rmin * 5).ToString("00");
                }
            }
        }
    }
    public void CheckAns(int index)
    {
        if (index == CorrectChoice)
        {
            Debug.Log("CorrectAns");
        }
        else
        {
            Debug.Log("WrongAns");
        }
        for(int i=0;i<3;i++)
        {
            if(i==CorrectChoice)
            {
                Choice[i].GetComponent<Image>().color = Color.green;
                Choice[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                Choice[i].GetComponent<Image>().color = Color.red;
                Choice[i].GetComponent<Button>().interactable = false;
            }
        }
        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion()
    {
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
        SetClock();
    }


}
