using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI1 : MonoBehaviour
{
    public float pushingPower = 10f;

    private Rigidbody rb;
    NavMeshAgent agent;

    private GameObject collidedPlayer;
    private GameObject closestBooster;
    private GameObject closestPlayer;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get NavMeshAgent and Rigidbody
        agent = GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find the closest player and boost object
        closestPlayer = FindClosestPlayer();
        closestBooster = FindClosestBooster();

        //Calculate the distance between closest player and boost object
        float distancePlayer = Vector3.Distance(closestPlayer.transform.position, transform.position);
        float distanceBooster = Vector3.Distance(closestBooster.transform.position, transform.position);

        //Move to the player
        if (distancePlayer < distanceBooster)
        {

            agent.SetDestination(closestPlayer.transform.position);
            
        }
        
        //Move to the booster
        else
        {

            agent.SetDestination(closestBooster.transform.position);
            
        }
        
    }

    public GameObject FindClosestBooster()
    {
        GameObject[] boosters;
        boosters = GameObject.FindGameObjectsWithTag("Booster");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject booster in boosters)
        {
            Vector3 diff = booster.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = booster;
                distance = curDistance;
            }
        }
        return closest;
    }


    public GameObject FindClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest1 = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            if (player.Equals(this.gameObject))
                continue;
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest1 = player;
                distance = curDistance;
            }
        }
        return closest1;
    }
  
    //Collision calculations
    private void OnCollisionEnter(Collision collision)
    {
        //Size and drag increase on the collision with booster + get points
        if (collision.gameObject.tag == "Booster")
        {
            transform.localScale += new Vector3(1, 1, 1);
            Destroy(collision.gameObject);
            pushingPower += 100;
            scoreScript.scoreValue1 += 100;

        }

        //Push the collided player on the collision with player
        if (collision.gameObject.tag == "Player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir.y = 0;
            collision.rigidbody.AddForce(dir * (pushingPower + 500));
            rb.drag += 0.6f;

            //To find if the collided player is dead
            StartCoroutine(IsDead(2f));
        }

        //Destroy the game object when it goes out of fight area
        if (collision.gameObject.tag == "Water")
        {
            
            Destroy(gameObject);
            
        }
    }

    IEnumerator IsDead(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (collidedPlayer == null)
        {
            scoreScript.scoreValue1 += 1000;
        }

    }
}
