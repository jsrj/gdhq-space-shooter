using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LaserBoltController : MonoBehaviour
{
    [SerializeField]
    private float _laserBoltSpeed;


    void Start()
    {

        this._laserBoltSpeed = 20.00f;
    }


    void Update()
    {
        
        // Accelerates each laserBolt instance forward along Y axis
        transform.Translate(Vector2.up * Time.deltaTime * this._laserBoltSpeed);

        // Destroy a laser bolt once it has moved a certain range out of camera frustrum
        if (transform.position.y > 10.00f) {
            GameObject.Destroy(this.gameObject);
        }
    }
}
