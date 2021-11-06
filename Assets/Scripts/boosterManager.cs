using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterManager : MonoBehaviour
{
    private float xPosition;
    private float zPosition;
    public GameObject prefab;
    public float timer;
    private GameObject instantiatedBooster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        InstantiateBooster();
        
    }

    void InstantiateBooster()
    {
        xPosition = Random.Range(-47, 47);
        zPosition = Random.Range(-47, 47);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            instantiatedBooster = Instantiate(prefab, new Vector3(xPosition, 30, zPosition), Quaternion.identity) as GameObject;
            prefab.name = "booster";
            timer = 1f;
        }
        
    }
}
