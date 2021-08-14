using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI Time;
    public Transform MinHand, HrHand;
    int temp;
    public int Hr, Min;
    [SerializeField]
    Mode1 M1;
    [SerializeField]
    GameObject Mode1Canvas, Mode2Canvas, MainMenuCanvas;
    

    private void Start()
    {
        GetComponent<Mode1>().enabled = false;
        GetComponent<Mode2>().enabled = false;
    }


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Add();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
             Subtract();
        }
    }
    public void Add()
    {
        AddIndex();
        SetTime();
        CheckForResult();
    }

    public void Subtract()
    {
        SubIndex();
        SetTime();
        CheckForResult();
    }

    private void SetTime()
    {
        MinHand.transform.eulerAngles = new Vector3(0, 0, Min * -30);
        HrHand.transform.eulerAngles = new Vector3(0, 0, (Hr * -30)-((Min*2)+1));
        if (Min == 12)
        {
            Time.text = (Hr+1).ToString("00") + ":00";
        }
        else
        {
            Time.text = Hr.ToString("00") + ":" + (Min * 5).ToString("00");
        }
    }

    public void SetRandomTime()
    {
        Hr = Random.Range(1, 12);
        Min = Random.Range(1, 12);
        SetTime();
    }
    private void AddIndex()
    {
        int i = 0;
        i = Min;
        i++;
        if (i > 12)
        {
            i = 1;
            Hr++;
            if (Hr > 12)
                Hr = 1;
        }
        Min = i;
      
    }
    private void SubIndex()
    {
        int i = 0;
       
        i = Min;
        i--;
        if (i < 1)
        {
            i = 12;
            Hr--;
            if(Hr<1)
                Hr=12;
        }
         Min = i;
    }
    private void CheckForResult()
    {
        //if(M1.qHr==Hr && M1.qMin==Min)
        //{
        //    Debug.Log("Correct");
        //    StartCoroutine(M1.NextQuestion());
        //}
    }
    public void NextQuestion()
    {
         M1.GenerateQuestion();
      
    }

    public void Mode1()
    {
        MainMenuCanvas.SetActive(false);
        Mode1Canvas.SetActive(true);
        GetComponent<Mode1>().enabled = true;
    }
    public void Mode2()
    {
        MainMenuCanvas.SetActive(false);
        Mode2Canvas.SetActive(true);
        GetComponent<Mode2>().enabled = true;
    }
    public void Back()
    {
        MainMenuCanvas.SetActive(true);
        Mode1Canvas.SetActive(false);
        Mode2Canvas.SetActive(false);
        GetComponent<Mode1>().enabled = false;
        GetComponent<Mode2>().enabled = false;
    }
}
