using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLogic : MonoBehaviour
{

    [SerializeField]
    private float _descendSpeed;

    [SerializeField]
    private float _driftSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this._descendSpeed = 3.00f;
        this._driftSpeed = 4.25f;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Move power up toward bottom of screen

        // Move power up left and right as it descends
    }
}
