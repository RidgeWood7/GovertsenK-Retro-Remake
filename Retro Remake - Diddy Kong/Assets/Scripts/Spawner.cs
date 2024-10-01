using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject prefab;
    public float minTime = 2f;
    public float maxTime = 4f;
    public Animator diddy;
    public float delay = .5f;

    private void spawnbarrel()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    public void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
        Invoke(nameof(spawnbarrel), delay);

        diddy.SetTrigger("throw");
    }
}
