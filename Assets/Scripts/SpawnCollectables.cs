using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{
    public float respawnTime,
                 size,
                 moveSpeed;

    public GameObject collectable;

    private bool addCollectables;

    void Start()
    {
        addCollectables = true;
        StartCoroutine(CollectablesWave());
    }

    void FixedUpdate()
    {
        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void SpawnCollectable()
    {
        //selects random position within circle of 1 unit, then adds the position to the spawn area's position
        Vector2 pos = Random.insideUnitCircle * (size);
        Vector3 position = transform.position + new Vector3(pos.x, pos.y, 0.0f);

        //instantiate collectable
        Instantiate(collectable, position, Quaternion.identity);
    }

    IEnumerator CollectablesWave()
    {
        while (addCollectables)
        {
            yield return new WaitForSeconds(respawnTime);

            SpawnCollectable();
        }
    }
}
