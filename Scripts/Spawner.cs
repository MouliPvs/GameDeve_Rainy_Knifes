using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //For creating knifes we need a GameObject
    //Drag & Drop the knifes Prefab in this field
    public GameObject knifes;

    //This is the span where the knifes will be spawned
    //Always declare these variables in start function so that if we restart game the values will be reset

    //mix_X & max_X are the left & right boundaries of our game
    //We spwan knifes randomly between min_X & max_X
    private float min_X = -2.7f;
    private float max_X = 2.7f;
    // Start is called before the first frame update
    void Start()
    {
    StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        //This will wait for o.5 seconds to 1 second
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        //Instantiate will create to duplcate knife object & we stored it in "k" of type "GameObject"
        GameObject k = Instantiate(knifes);
        float x = Random.Range(min_X, max_X);

        //here y postion is the position of spawner object in y coordinate
        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(StartSpawning());
    }

}
