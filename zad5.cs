using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float planeWidth = 10.0f;
    public float planeLength = 10.0f;

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            float randomX = Random.Range(-planeWidth / 2, planeWidth / 2);
            float randomZ = Random.Range(-planeLength / 2, planeLength / 2);

            Vector3 randomPosition = new Vector3(randomX, 0.5f, randomZ);

            Collider[] hitColliders = Physics.OverlapSphere(randomPosition, 0.5f);
            if (hitColliders.Length == 0)
            {
                Instantiate(cubePrefab, randomPosition, Quaternion.identity);
            }
            else
            {
                i--; // Decrement i to generate one more cube.
            }
        }
    }
}