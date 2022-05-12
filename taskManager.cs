using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buttons;
   // public Button startButton;
    public int currentIndex = 0;
    public int buttonCount;

    public bool testGoing = false;

    void Start()
    {
        buttonCount = buttons.Length;
    }

    void reshuffle<T>(T[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            T tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }

    public void startTest()
    {
        //startButton.interactable = false;
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

        currentIndex = 0;
       // startButton.interactable = true;

    }

    public void buttonHit()
    {
        StopAllCoroutines();
        setActive();
        ScoreController.instance.addOnePoint();
        StartCoroutine(updateButton());
    }

    public void setActive()
    {
        if (currentIndex != 0)
        {
            buttons[currentIndex - 1].transform.Find("LightPlate").gameObject.SetActive(false);
        }

        if (currentIndex == buttonCount)
        {

            endTest();
            return;
        }

        buttons[currentIndex].transform.Find("LightPlate").gameObject.SetActive(true);

        currentIndex++;

    }


}
