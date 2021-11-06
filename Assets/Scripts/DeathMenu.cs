using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class DeathMenu : MonoBehaviour
{
    public bool isDead = false;

    public static int Alive = 8;

    public Text score;
    
    public float playerScore, enemy1Score, enemy2Score, enemy3Score, enemy4Score, enemy5Score, enemy6Score, enemy7Score, maxScore;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame  
    void Update()
    {

        if(isDead == true)
        {
            ToggleEndMenu();
        }

            
    }

    public void ToggleEndMenu()
    {
        
        gameObject.SetActive(true);




       
        if (maxScore == playerScore)
        {
            score.text = "You Win!";
        }
        else
        {
            score.text = "You Lost!";
        }
        


    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public float GetMaxScore()
    {
        playerScore = scoreScript.scoreValue;
        enemy1Score = scoreScript.scoreValue1;
        enemy2Score = scoreScript.scoreValue2;
        enemy3Score = scoreScript.scoreValue3;
        enemy4Score = scoreScript.scoreValue4;
        enemy5Score = scoreScript.scoreValue5;
        enemy6Score = scoreScript.scoreValue6;
        enemy7Score = scoreScript.scoreValue7;
        float[] scores = { playerScore, enemy1Score, enemy2Score, enemy3Score, enemy4Score, enemy5Score, enemy6Score, enemy7Score };
        Debug.Log(scores.Max());
        return scores.Max();
    }
}
