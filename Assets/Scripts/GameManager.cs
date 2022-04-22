using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject note1Prefab;
    public GameObject note2Prefab;
    public GameObject note3Prefab;
    public GameObject note4Prefab;
    public GameObject noteWrongPrefab;

    public GameObject lifesPrefab;

    public Transform[] spawnPoints;

    public float minDelay = 0.1f;
    public float MaxDelay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, MaxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject note = note1Prefab;
            switch (Random.Range(0,500))
            {
                case var n when (n <= 100f):
                    note = note1Prefab;
                    note.GetComponent<NoteScript>().noteNumber = 1;
                    break;
                case var n when (n <= 200f && n > 100f):
                    note = note2Prefab;
                    note.GetComponent<NoteScript>().noteNumber = 2;
                    break;
                case var n when (n <= 300f && n > 200f):
                    note = note3Prefab;
                    note.GetComponent<NoteScript>().noteNumber = 3;
                    break;
                case var n when (n <= 400f && n > 300f):
                    note = note4Prefab;
                    note.GetComponent<NoteScript>().noteNumber = 4;
                    break;
                case var n when (n <= 500f && n > 400f):
                    note = noteWrongPrefab;
                    note.GetComponent<NoteScript>().noteNumber = 5;
                    note.GetComponent<NoteScript>()._isWrong = true;
                    break;
            }
            GameObject spawnedFruit = Instantiate(note, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 2f);

        }
    }

    
    
}
