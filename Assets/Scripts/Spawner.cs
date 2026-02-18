using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float spawnRate = 2f;
    public float xRange = 8f;

    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnDonut();
        }
    }

    void SpawnDonut()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        // Выбираем случайный пончик из списка
        int randomIndex = Random.Range(0, donutPrefabs.Length);
        
        Instantiate(donutPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}