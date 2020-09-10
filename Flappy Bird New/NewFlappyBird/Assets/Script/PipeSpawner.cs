using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize = 1f;
    [SerializeField] private float maxMinOffset = 1;

    [SerializeField] private Point point;

    //variable penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;
    
    private void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        // menduplikasi pipeUp dan pipeDown
        // Euler = puter 180 derajat, identity = sama dengan asli nya
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        newPipeUp.gameObject.SetActive(true);
        newPipeDown.gameObject.SetActive(true);

        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        float y = maxMinOffset * Mathf.Cos(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;

    }

    IEnumerator IeSpawn()
    {
        while(true)
        {
            if(bird.IsDead())
            {
                StopSpawn();
            }

            SpawnPipe();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
