using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightColour : MonoBehaviour
{

    public State state;
    public float timer = 0f;

    public enum State
    {
        yellow,
        red,
        green,
    }

    void Awake()
    {
        var ObjRenderer = GetComponent<Renderer>();

        int randomState = Random.Range(0, 3);
        switch (randomState)
        {
            case 0:
                ObjRenderer.material.SetColor("_Color", Color.yellow);
                state = State.yellow;
                timer = 4f;
                break;

            case 2:
                ObjRenderer.material.SetColor("_Color", Color.red);
                state = State.red;
                timer = Random.Range(5f, 10f);
                break;

            case 1:
                ObjRenderer.material.SetColor("_Color", Color.green);
                state = State.green;
                timer = Random.Range(5f, 10f);
                break;
        }
    }

    void Update()
    {
        ChangeState();
    }

    void ChangeState()
    {
        var ObjRenderer = GetComponent<Renderer>();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            switch (state)
            {
                case State.yellow:
                    state = State.red;
                    ObjRenderer.material.SetColor("_Color", Color.red);
                    timer = Random.Range(5f, 10f);
                    break;

                case State.red:
                    state = State.green;
                    ObjRenderer.material.SetColor("_Color", Color.green);
                    timer = Random.Range(5f, 10f);
                    break;

                case State.green:
                    state = State.yellow;
                    ObjRenderer.material.SetColor("_Color", Color.yellow);
                    timer = 4f;
                    break;
            }
        }
    }
}