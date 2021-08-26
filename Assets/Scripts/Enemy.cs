using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject DeathFx;
    [SerializeField] Transform Parent;
    ScoreBoard scoreBoard;
    [SerializeField] int ScorePerHit = 10;
    [SerializeField] int EnemyHealthHit = 10;

    // Use this for initialization
    void Start () {
        AddnontriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddnontriggerCollider()
    {
        Collider boxcollider= gameObject.AddComponent<BoxCollider>();
        boxcollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(ScorePerHit);
        EnemyHealthHit = EnemyHealthHit - 1;
        if (EnemyHealthHit <= 0)
        {
            KillEnemy();
        }
        
    }

    private void KillEnemy()
    {
        GameObject FX = Instantiate(DeathFx, transform.position, Quaternion.identity);
        FX.transform.parent = Parent;
        // print("bullet hit anemy" + gameObject.name);
        Destroy(gameObject);
    }
}

