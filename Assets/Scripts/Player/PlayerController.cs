using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float x = 0.0f;
    public float y = -3.85f;
    public float z = 0.0f;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.name + " Initialized...");
        transform.position = new Vector3(this.x, this.y, this.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(this.x, this.y, this.z);
    }
}
