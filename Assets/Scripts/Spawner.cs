using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bars;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBars", 2f, 4f);
    }

    public void SpawnBars()
    {
        if (!Gamemanager.gameover)
        {
            int rand = Random.Range(0, bars.Length);
            Instantiate(bars[rand], new Vector3(1.48f, transform.position.y, -0.3612049f), transform.rotation);
        }
    }
}
