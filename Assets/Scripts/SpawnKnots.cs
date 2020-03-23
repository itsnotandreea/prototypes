using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnots : MonoBehaviour
{
    public float respawnTime,
                 size;

    public GameObject[] knots;

    private int randomKnot;

    private bool addKnots;

    void Start()
    {
        addKnots = true;
        StartCoroutine(KnotsWave());
    }

    private void SpawnKnot()
    {
        //selects random position within circle of 1 unit, then adds the position to the spawn area's position
        Vector2 pos = Random.insideUnitCircle * size;
        Vector3 position = transform.position + new Vector3(pos.x, pos.y, 0.0f);

        //select random knot
        randomKnot = Random.Range(0, knots.Length);
        Instantiate(knots[randomKnot], position, Quaternion.identity);
    }

    IEnumerator KnotsWave()
    {
        while(addKnots)
        {
            yield return new WaitForSeconds(respawnTime);

            SpawnKnot();
        }
    }
}
