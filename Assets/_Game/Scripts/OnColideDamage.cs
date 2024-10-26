using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnColideDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // print($"I got {other.gameObject.name}");

        if (other.gameObject.layer == 7)
        {
            // print("mmm its a player!");
            //Do something to reset

            PlayerManager.instance.gameObject.GetComponent<PlayerMovementAdvanced>().enabled = false;
            PlayerManager.instance.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            PlayerManager.instance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerManager.instance.gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.AngleAxis(30, Vector3.forward));
            
            StartCoroutine(resetScene());
            // Time.timeScale = 0;
        }
    }

    IEnumerator resetScene()
    {
        // print("YouLose");
        yield return new WaitForSecondsRealtime(1);

        PlayerManager.instance.gameObject.GetComponent<PlayerMovementAdvanced>().enabled = true;
        PlayerManager.instance.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        PlayerManager.instance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // Replace with original speed if needed
        PlayerManager.instance.gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.identity); // or use the stored original rotation



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
    
}
