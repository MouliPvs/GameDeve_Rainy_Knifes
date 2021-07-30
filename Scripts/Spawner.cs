using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //For creating knifes we need a GameObject
    //Drag & Drop the knifes Prefab in this field
    public GameObject knifes;

    //This is the spawner where the knifes will be spawned
    //Always declare these variables in start function so that if we restart game the values will be reset
    //mix_X & max_X are the left & right boundaries of our game
    //We spwan knifes randomly between min_X & max_X
    // 1f = 1000 milli seconds, 0.1f = 100 ms /  10% in a second
    private float min_X = -2.7f;
    private float max_X = 2.7f;
    // Start is called before the first frame update

    /// <summary>
    /// Minimum Spawn Time & Maximum Spawn Time For Spawning Knifes
    /// </summary>
    private float min_spawn_time_kinfes = 1.0f;
    private float max_spawn_time_knifes = 3.0f;

    private int knifes_count = 0;

    public Text knifes_count_text;
    void Start()
    {
    StartCoroutine(StartSpawning());
    StartCoroutine("WaveIncrease");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator StartSpawning()
    {
        //This will wait for "min_spawn_time" seconds to "max_spawn_time" second
        yield return new WaitForSeconds(Random.Range(min_spawn_time_kinfes, max_spawn_time_knifes));
        CountKnifes_UpdateText();
        //Instantiate will create to duplcate knife object & we stored it in "k" of type "GameObject"
        GameObject k = Instantiate(knifes);
        float x = Random.Range(min_X, max_X);

        //here y postion is the position of spawner object in y coordinate
        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(StartSpawning());
    }

    /// <summary>
    /// For Every 5 seconds Decrease The "min_spawn_time" & "max_spawn_time"
    /// Methods Called : DecreaseSpawnTime()
    /// </summary>
    /// <returns></returns>
    IEnumerator WaveIncrease()
    {
        yield return new WaitForSeconds(5.0f);
        DecreaseSpawnTime();
        StartCoroutine(WaveIncrease());
    }

    /// <summary>
    /// For Every 5 seconds Decrease The "min_spawn_time" & "max_spawn_time"
    /// After reaching certain time values are round up
    /// </summary>
    private void DecreaseSpawnTime()
    {
        min_spawn_time_kinfes -= 0.1f;
        max_spawn_time_knifes -= 0.1f;
        if (min_spawn_time_kinfes <= 0.1f || max_spawn_time_knifes <= 1f)
        {
            min_spawn_time_kinfes = 0.1f;
            max_spawn_time_knifes = 1f;
            StopCoroutine("WaveIncrease");
        }

    }


    private void CountKnifes_UpdateText()
    {
        knifes_count++;
        knifes_count_text.text = "Knifes :" + knifes_count;
    }
}
