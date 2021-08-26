using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour {

    [SerializeField] float LoadlevelDealy=1f;
    [SerializeField] GameObject deathfx;

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision occur");
    }

    private void OnTriggerEnter(Collider other)
    {
        DeathSequence();
        Invoke("ReloadLevel", LoadlevelDealy);
    }

    private void DeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathfx.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(2);
    }
}
