using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public IntegerValue enemiesCaptured;
    public FloatValue score;
    public BoolValue gameover;
    public GameObject scoreText;
    private TextMeshProUGUI textMesh;

    // Use this for initialization
    void Start()
    {
        textMesh = scoreText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover.Value)
            score.Value += Time.deltaTime * (enemiesCaptured.Value + 1);

        textMesh.text = "Score: " + Mathf.Round(score.Value);
    }
}
