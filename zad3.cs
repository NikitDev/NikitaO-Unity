using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 90.0f;

    private Vector3 initialPosition;
    private float moveDistance = 10.0f;
    private bool isTurning = false;
    private Vector3 targetRotation;

    void Start()
    {
        initialPosition = transform.position;
        targetRotation = transform.eulerAngles + Vector3.up * 90.0f;
    }

    void Update()
    {
        if (!isTurning)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
            {
                isTurning = true;
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)) < 1.0f)
            {
                isTurning = false;
                initialPosition = transform.position;
                targetRotation = transform.eulerAngles + Vector3.up * 90.0f;
            }
        }
    }
}
