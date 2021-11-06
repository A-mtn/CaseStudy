using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float pushingPower = 10f;

    public DeathMenu deathmenu;
    private GameObject collidedPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Same as the Enemy1 script
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            transform.localScale += new Vector3(1, 1, 1);
            Destroy(collision.gameObject);
            pushingPower += 2;
            scoreScript.scoreValue += 10;

        }

        if (collision.gameObject.tag == "Player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            collision.rigidbody.AddForce(dir * (pushingPower + 300));

            StartCoroutine(IsDead(2f));

        }

        if (collision.gameObject.tag == "Water")
        {

            deathmenu.isDead = true;

            Destroy(gameObject);

            GetComponent<DeathMenu>().ToggleEndMenu();
            




        }
    }

    IEnumerator IsDead(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (collidedPlayer == null)
        {
            scoreScript.scoreValue7 += 1000;
        }

    }
}