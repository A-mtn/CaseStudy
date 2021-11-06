using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI2 : MonoBehaviour
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
        agent = GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        closestPlayer = FindClosestPlayer();
        closestBooster = FindClosestBooster();

        float distancePlayer = Vector3.Distance(closestPlayer.transform.position, transform.position);
        float distanceBooster = Vector3.Distance(closestBooster.transform.position, transform.position);

        if (distancePlayer < distanceBooster)
        {

            agent.SetDestination(closestPlayer.transform.position);
            
        }
        
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
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            transform.localScale += new Vector3(1, 1, 1);
            Destroy(collision.gameObject);
            pushingPower += 100;
            scoreScript.scoreValue2 += 100;

        }

        if (collision.gameObject.tag == "Player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir.y = 0;
            collision.rigidbody.AddForce(dir * (pushingPower + 500));
            rb.drag += 0.6f;
            
            StartCoroutine(IsDead(2f));
        }

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
            scoreScript.scoreValue2 += 1000;
        }

    }
}
