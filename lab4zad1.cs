using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab4zad1 : MonoBehaviour
{
    public int numberOfObjects = 10;
    public float delay = 3.0f;
    public GameObject block;
    public Material[] materials;

    void Start()
    {
        GenerateObjects();
        StartCoroutine(GenerateObjectCoroutine());
    }

    void GenerateObjects()
    {
        List<Vector3> positions = new List<Vector3>();

        Bounds platformBounds = GetComponent<Renderer>().bounds;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(platformBounds.min.x, platformBounds.max.x);
            float randomZ = UnityEngine.Random.Range(platformBounds.min.z, platformBounds.max.z);

            positions.Add(new Vector3(randomX, 5, randomZ));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
    }

    IEnumerator GenerateObjectCoroutine()
    {
        Debug.Log("Coroutine started");

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                UnityEngine.Random.Range(transform.position.x - 5, transform.position.x + 5),
                5,
                UnityEngine.Random.Range(transform.position.z - 5, transform.position.z + 5)
            );

            GameObject newObject = Instantiate(block, randomPosition, Quaternion.identity);
            newObject.GetComponent<Renderer>().material = GetRandomMaterial();

            yield return new WaitForSeconds(delay);
        }

        Debug.Log("Coroutine finished");
    }

    Material GetRandomMaterial()
    {
        int randomIndex = UnityEngine.Random.Range(0, materials.Length);
        return materials[randomIndex];
    }
}
