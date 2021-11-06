using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int scoreValue1 = 0;
    public static int scoreValue2 = 0;
    public static int scoreValue3 = 0;
    public static int scoreValue4 = 0;
    public static int scoreValue5 = 0;
    public static int scoreValue6 = 0;
    public static int scoreValue7 = 0;
    public Text scoreP;
    public Text scoreE1;
    public Text scoreE2;
    public Text scoreE3;
    public Text scoreE4;
    public Text scoreE5;
    public Text scoreE6;
    public Text scoreE7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreP.text = "Player: " + scoreValue;
        scoreE1.text = "Enemy 1: " + scoreValue1;
        scoreE2.text = "Enemy 2:" + scoreValue2;
        scoreE3.text = "Enemy 3: " + scoreValue3;
        scoreE4.text = "Enemy 4: " + scoreValue4;
        scoreE5.text = "Enemy 5: " + scoreValue5;
        scoreE6.text = "Enemy 6: " + scoreValue6;
        scoreE7.text = "Enemy 7: " + scoreValue7;


    }
}
