using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnots : MonoBehaviour
{
    public float respawnTime,
                 size,
                 moveSpeed,
                 moveUpSpeed;

    public GameObject parent;

    public GameObject[] knots;

    private int randomKnot;

    private bool addKnots;

    void Start()
    {
        addKnots = true;
        StartCoroutine(KnotsWave());
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * moveUpSpeed * Time.deltaTime);

        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void SpawnKnot()
    {
        //selects random position within circle of 1 unit, then adds the position to the spawn area's position
        Vector2 pos = Random.insideUnitCircle * size;
        Vector3 position = transform.position + new Vector3(pos.x, pos.y, 0.0f);

        //select random knot
        randomKnot = Random.Range(0, knots.Length);
        GameObject newKnot = Instantiate(knots[randomKnot], position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        newKnot.transform.parent = parent.transform;
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
