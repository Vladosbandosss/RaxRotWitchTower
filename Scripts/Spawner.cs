using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bgPrefab;

    public GameObject[] platformPrefab;

    public GameObject goast;
    public float goastSpawnInterval = 3f;

    private Camera mainCam;

    private float platformDistance = 2f;
    private float bgDistanse = 10f;

    private float currentPlatformY;
    private float currentBGy;

    public float minX = -2.25f;
    public float maxX = 2.25f;

    public int BgSpawnCount=5;
    public int platformSpawnCount = 28;

    private float spawnerDistanse = 30f;

    void Start()
    {
        mainCam = Camera.main;
        SpawnBgAndPlatform();

        StartCoroutine(nameof(SpawnGoast));
    }

    private void SpawnBgAndPlatform()
    {
        for (int i = 0; i < BgSpawnCount; i++)
        {
            currentBGy += bgDistanse;
            Vector3 temp1 = Vector3.zero;
            temp1.y = currentBGy;
            Instantiate(bgPrefab, temp1, Quaternion.identity);

        }

        for (int i = 0; i < platformSpawnCount;i++)
        {
            Vector3 temp2 = Vector3.zero;
            temp2.y = currentPlatformY;
            temp2.x = UnityEngine.Random.Range(minX, maxX);

            Instantiate(platformPrefab[UnityEngine.Random.Range(0, platformPrefab.Length)], temp2, Quaternion.identity);
            currentPlatformY += platformDistance;
        }

        Vector3 temp = transform.position;
        temp.y += spawnerDistanse;
        transform.position = temp;
    }

    IEnumerator SpawnGoast()
    {
        yield return new WaitForSeconds(goastSpawnInterval);

        Vector3 temp = mainCam.transform.position;
        temp.x = UnityEngine.Random.Range(minX, maxX);
        temp.y += 8f;
        temp.z = 0;
        Instantiate(goast, temp, Quaternion.identity);

        StartCoroutine(nameof(SpawnGoast));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SpawnBgAndPlatform();
        }
    }




}
