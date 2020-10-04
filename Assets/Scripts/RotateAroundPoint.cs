using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Transform rotateAroundPoint;
    public int rotationSpeed = 60;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotateAroundPoint.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward, 5 * rotationSpeed * Time.deltaTime);
    }
}
