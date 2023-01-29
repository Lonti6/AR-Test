using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    float accelx, accely, accelz = 0;

    // Update is called once per frame
    void Update()
    {
        accelx = Input.acceleration.x;
        accely = Input.acceleration.y;
        accelz = Input.acceleration.z;
        transform.Rotate(accelx * Time.deltaTime, accely * Time.deltaTime, accelz * Time.deltaTime);
    }
}
