using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class taskManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buttons;
    // public Button startButton;
    public int currentIndex = 0;
    public int buttonCount;
    public Interactable startButton;
    public bool testGoing = false;


    void Start()
    {
        buttonCount = buttons.Length;
    }

    void reshuffle(GameObject[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            GameObject tmp = array[t];

            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;

        }
    }


    public void startTest()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Interactable>().IsEnabled = true;
        }

        //startButton.interactable = false;
        startButton.IsEnabled = false;
        reshuffle(buttons);
        TimerController.instance.BeginTimer();
        ScoreController.instance.reset();
        testGoing = true;
        StartCoroutine(updateButton());
    }
    private IEnumerator updateButton()
    {
        while (testGoing)
        {
            yield return new WaitForSeconds(2);
            setActive();

        }

    }
    private void endTest()
    {
        StopAllCoroutines();
        testGoing = false;
        TimerController.instance.EndTimer();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Interactable>().IsEnabled = false;
        }

        currentIndex = 0;
        // startButton.interactable = true;
        startButton.IsToggled = false;
        startButton.IsEnabled = true;
    }

    public void buttonHit(GameObject hitter)
    {
        if (hitter.name == buttons[currentIndex - 1].name)
        {
            ScoreController.instance.addOnePoint();
        }
        else
        {
            ScoreController.instance.addOneMistake();
        }
        StopAllCoroutines();
        setActive();

        StartCoroutine(updateButton());
    }

    public void setActive()
    {
        if (currentIndex != 0)
        {
            //buttons[currentIndex - 1].transform.Find("LightPlate").gameObject.SetActive(false);
            toggleLight(buttons[currentIndex - 1], false);
        }

        if (currentIndex == buttonCount)
        {
            endTest();
            return;
        }

        // buttons[currentIndex].transform.Find("LightPlate").gameObject.SetActive(true);
        toggleLight(buttons[currentIndex], true);

        currentIndex++;

    }
    private void toggleLight(GameObject button, bool isOn)
    {
        if (isOn)
        {
            button.transform.Find("LightPlate").gameObject.SetActive(true);
            button.transform.Find("DarkPlate").gameObject.SetActive(false);

        }
        else
        {
            button.transform.Find("LightPlate").gameObject.SetActive(false);
            button.transform.Find("DarkPlate").gameObject.SetActive(true);

        }


    }


}
