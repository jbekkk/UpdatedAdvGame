using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeCode : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
    
         if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    

}
