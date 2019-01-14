using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Controller Initialized...");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(frameCount);

        if (frameCount >= 1000) {
            frameCount = 0;
            Debug.Log("Frame Counter Reset");
        } else {
            frameCount += 1;
        }
    }
}
