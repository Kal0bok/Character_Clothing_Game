using System.Collections;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    public GameObject[] donutPrefab;
    public float spawnInterval = 1.0f;
    float minPoz, maxPoz;
    Transform ovenTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

   public void BakeDonut(bool state)
    {
        if (state)
            StartCoroutine(Bake());
        else
            StopAllCoroutines();
        
    }
    IEnumerator Bake()
    {
        while (true)
        {
            minPoz = ovenTransform.position.x - 40.0f;
            maxPoz = ovenTransform.position.x + 40.0f;
            float randPoz = Random.Range(minPoz, maxPoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            int donutIndex = Random.Range(0, donutPrefab.Length);
            Instantiate(donutPrefab[donutIndex], spawnPoz, Quaternion.identity, ovenTransform);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
