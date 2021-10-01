using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float rotationSpeed;
    public float hoverZoneScreenDivisor;
    public Transform gameBoardTransform;

    float hoverZoneLength;
    float leftLowerBound, leftUpperBound;
    float rightLowerBound, rightUpperBound;

    float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        hoverZoneLength = Screen.width / hoverZoneScreenDivisor;

        leftLowerBound = 0;
        leftUpperBound = leftLowerBound + hoverZoneLength;

        rightUpperBound = Screen.width;
        rightLowerBound = rightUpperBound - hoverZoneLength;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;

        if (mouseX > leftLowerBound && mouseX < leftUpperBound) {
            transform.RotateAround(gameBoardTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (mouseX > rightLowerBound && mouseX < rightUpperBound) {
            transform.RotateAround(gameBoardTransform.position, Vector3.up, rotationSpeed * Time.deltaTime * -1f);
        }
    }
}
