using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject hitvfx;
    [SerializeField] GameObject deathvfx;
    [SerializeField] int ScorePerHit = 5;
    [SerializeField] int HitPoint= 15;

    ScoreBoard ScoreBoard;
    GameObject ParentGameObject;



     void Start()
    {
        ScoreBoard = FindObjectOfType<ScoreBoard>();
        ParentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        Scoring();
        gettinghit();
        HitPoint-=ScorePerHit;
        if(HitPoint<=0)
        Killing();
    }
     
     void gettinghit()
     {
        GameObject vfx1 = Instantiate(hitvfx,transform.position,Quaternion.identity);
        vfx1.transform.parent = ParentGameObject.transform;
     }
     void Killing()
    {   
        GameObject vfx = Instantiate(deathvfx, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform;
        Debug.Log("deatroy");
        Destroy(gameObject);
    }

    void Scoring()
    {
        ScoreBoard.IncreaseScore(ScorePerHit);
    }
}
