using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public int[] weightTable = {
                                30, // Yellow
                                25, // Green
                                20, // Brown
                                19, // Lightbulb
                                15, // CoolShark
                                10, // Whale
                                8, // MantaRay
                                5 // Shark
                            };
    
    public GameObject[] Fishies;

    public float timeout = 2;

    public int randomNumber;

    public int randnumisee;

    public int total;

    private void Start()
    {
        foreach(int weight in weightTable)
        {
            total += weight;
        }
    }


    private void Update() {
        
        if(timeout > 0) {
            timeout -= Time.deltaTime;
            return;
        }
        else
        {

            timeout = Random.Range(1, 4);

            randomNumber = Random.Range(0, total);

            randnumisee = randomNumber;

            for (int i = 0; i < weightTable.Length; i++)
            {
                if (randomNumber <= weightTable[i])
                {
                    Instantiate(Fishies[i], new Vector3(transform.position.x, Random.Range(-4.5f, -0.25f), -5), Quaternion.identity);
                    return;
                }
                else
                {
                    randomNumber -= weightTable[i];
                }
            }

        }

    }
}

