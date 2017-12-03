using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public IntegerValue numEnemiesCaptured;
    public BoolValue gameover;
    private float speed = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameover.Value && speed > 0)
        {
            speed -= Time.deltaTime;            
        }

        this.transform.Translate(new Vector2(-speed * Time.deltaTime * (numEnemiesCaptured.Value + 1), 0));
    }
}
