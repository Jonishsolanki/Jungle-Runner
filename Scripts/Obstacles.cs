using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
 //   private platforminstantiate _playerSpawn;
    private void Start()
    {
       // _playerSpawn = GameObject.Find("platforminstantiate").GetComponent<platforminstantiate>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {  
            Destroy(other.gameObject);
          //  _playerSpawn.playerDeath();
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
