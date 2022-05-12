using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro scoreCounter;
    public static ScoreController instance;
    public int points = 0;
    void Start()
    {
        instance = this;
    }
    public void addOnePoint()
    {
        points++;
        scoreCounter.text = "Score: " + points;
    }
    public void reset()
    {
        points = 0;
        scoreCounter.text = "Score: 0";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
