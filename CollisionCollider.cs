using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCollider : MonoBehaviour
{

   [SerializeField] ParticleSystem crashvfx;
    void OnCollisionEnter(Collision other) {
        crashvfx.Play();
        Debug.Log(this.name + "--collided with--" + other.gameObject.name);
        GetComponent<playercontrol>().enabled = false;
       
        Destroy(gameObject);
        Invoke("ReloadLevel", 1f);
    }

    void OnTriggerEnter(Collider other) {
      Debug.Log($"{this.name} **triggered with** {other.gameObject.name}");    
      GetComponent<playercontrol>().enabled = false;
      crashvfx.Play();
      GetComponent<BoxCollider>().enabled = false;
      Destroy(gameObject, 3f);
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }
}
