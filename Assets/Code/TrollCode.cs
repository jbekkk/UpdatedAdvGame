using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrollCode : MonoBehaviour
{
    NavMeshAgent _navAgent;
    GameObject player;
    GameObject troll;
    Rigidbody trollRb;
<<<<<<< HEAD
    int health = 75;
=======
    int health = 150;
>>>>>>> 6dd6702cca4f81ebdee82f31a77292abee9c8189
    // Start is called before the first frame update

    Animator _animator;
    
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        troll = GameObject.FindGameObjectWithTag("Troll");
        trollRb = troll.GetComponent<Rigidbody>();
        StartCoroutine(FindPlayer());
        
    }

    IEnumerator FindPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(.5f);
            if(health != 0 && (Mathf.Sqrt(Mathf.Pow(player.transform.position.x - troll.transform.position.x,2) + Mathf.Pow(player.transform.position.z - troll.transform.position.z,2)) < 50))
            {
                _navAgent.destination = player.transform.position - new Vector3((float) 3,0, (float) 3);
            }
<<<<<<< HEAD
            if(health <= 0)
            {
                yield return new WaitForSeconds(1f);
                Invoke("Death",1);
                Destroy(gameObject);
=======
            if(health == 0)
            {
                Invoke("Death",1);
>>>>>>> 6dd6702cca4f81ebdee82f31a77292abee9c8189
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
<<<<<<< HEAD
            print(health);
=======
            
>>>>>>> 6dd6702cca4f81ebdee82f31a77292abee9c8189
            Destroy(other.gameObject);
            trollRb.AddForce(-1 * other.impulse);
            _animator.SetInteger("health", health - 5);
            health -= 5;

        }
    }
    void Update() 
    {
        troll.transform.LookAt(player.transform);
        _animator.SetFloat("nearPlayer", (float) Mathf.Sqrt(Mathf.Pow(player.transform.position.x - troll.transform.position.x,2) + Mathf.Pow(player.transform.position.z - troll.transform.position.z,2)));
        _animator.SetFloat("aggroRange", (float) Mathf.Sqrt(Mathf.Pow(player.transform.position.x - troll.transform.position.x,2) + Mathf.Pow(player.transform.position.z - troll.transform.position.z,2)));
    }



}
