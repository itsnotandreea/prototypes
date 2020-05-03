using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{
    public float respawnTime,
                 size,
                 moveSpeed,
                 moveUpSpeed,
                 collectablesCount = 0;

    public GameObject[] collectables;

    private int randomCollectable;

    private bool addCollectables;

    void Start()
    {
        addCollectables = true;
        StartCoroutine(CollectablesWave());
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * moveUpSpeed * Time.deltaTime);

        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void SpawnCollectable()
    {
        //selects random position within circle of 1 unit, then adds the position to the spawn area's position
        Vector2 pos = Random.insideUnitCircle * (size);
        Vector3 position = transform.position + new Vector3(pos.x, pos.y, 0.0f);

        //instantiate collectable
        randomCollectable = Random.Range(0, collectables.Length);
        Instantiate(collectables[randomCollectable], position, Quaternion.identity);
    }

    IEnumerator CollectablesWave()
    {
        while (addCollectables)
        {
            yield return new WaitForSeconds(respawnTime);

            collectablesCount += 1;
            SpawnCollectable();
        }
    }
}
