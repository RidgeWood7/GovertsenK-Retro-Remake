using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TestPM : MonoBehaviour
{
    public int wins;                       // Whole #s
    public float speed;                    // Decimal #s
    public string characterName, secondaryCharacterName;           // Words/Phrases/Text
    public bool isPlayerDead, isGnrounded; // True/False
    public Vector2 playerLocation, size;   // 2-Dimentional Decimals

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Dity Kong HATES " + characterName);

        if (isGnrounded)
        {
            Debug.Log("On the floor crying");
        }
        else
        {
            Debug.Log("Just kidding, it's actually " + secondaryCharacterName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
