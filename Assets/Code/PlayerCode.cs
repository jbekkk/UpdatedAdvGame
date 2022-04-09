using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{
    NavMeshAgent _navAgent;

    Camera mainCam;

    public GameObject bulletPrefab;

    public Transform spawnPoint;
    
    public TextMeshProUGUI scoreUI;


    int bulletForce = 900; 

    int health = 10;


    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;

    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit, 200))
                {
                    _navAgent.destination = hit.point;
                }
            }

        if(Input.GetMouseButtonDown(1)){

            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bulletForce);
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {    
        if(other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            PublicVars.keyCount++;
            
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Troll"))
        {
            health -= 3;
            scoreUI.text = "Health " + health;
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            scoreUI.text = "Health " + health;
        }
    }
}
