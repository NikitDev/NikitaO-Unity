using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed = 10.0f; // Publiczne pole do ustawienia pr�dko�ci ruchu
    public float rotationSpeed = 90.0f; // Publiczne pole do ustawienia pr�dko�ci obrotu

    private Vector3 initialPosition;
    private float moveDistance = 10.0f; // Odleg�o��, po kt�rej obiekt si� przemieszcza
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
            // Przesu� obiekt wzd�u� osi X
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Sprawd�, czy obiekt przekroczy� okre�lon� odleg�o��
            if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
            {
                isTurning = true;
            }
        }
        else
        {
            // Obracaj obiekt o 90 stopni w kierunku kolejnego ruchu
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);

            // Sprawd�, czy obiekt obr�ci� si� o 90 stopni
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)) < 1.0f)
            {
                isTurning = false;
                initialPosition = transform.position;
                targetRotation = transform.eulerAngles + Vector3.up * 90.0f;
            }
        }
    }
}
