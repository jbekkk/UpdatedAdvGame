using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class PlayerCode : MonoBehaviour
{
    NavMeshAgent _navAgent;

    Camera mainCam;

    public GameObject bulletPrefab;

    public Transform spawnPoint;
    

    public TextMeshProUGUI scoreUI;


    int bulletForce = 900; 


    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        scoreUI.text = "Score: " + PublicVars.score;
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

        if(Input.GetMouseButtonDown(1) && !_navAgent.hasPath){

            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bulletForce);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {    
        if(other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            PublicVars.keyCount++;
            
        }
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            PublicVars.score++;
            scoreUI.text = "Gold: " + PublicVars.score;
        }

        
    }
}
