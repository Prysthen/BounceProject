using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTeleport : MonoBehaviour
{   
    public string nextLevel;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<CharacterController>() != null)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

}
