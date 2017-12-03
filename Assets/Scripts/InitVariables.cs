using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVariables : MonoBehaviour
{

    public IntegerValue enemiesCaptured;
    public FloatValue score;
    public BoolValue gameOver;

    // Use this for initialization
    void Start()
    {
        enemiesCaptured.Value = 0;
        score.Value = 0;
        gameOver.Value = false;
    }
}


