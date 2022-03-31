using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string leveltoload = "Level1";

    private void OnCollisionEnter(Collision other)
    {
        if (PublicVars.keyCount > 0 && other.gameObject.CompareTag("Player"))
        {
            PublicVars.keyCount = 0;
            SceneManager.LoadScene(leveltoload);
        }
    }
}
