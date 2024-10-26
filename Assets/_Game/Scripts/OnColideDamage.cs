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
            StartCoroutine(resetScene());
            Time.timeScale = 0;
        }
    }

    IEnumerator resetScene()
    {
        // print("YouLose");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
