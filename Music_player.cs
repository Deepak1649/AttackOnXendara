using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_player : MonoBehaviour
{
     void Awake() {
        int numofplayers=FindObjectsOfType<Music_player>().Length;
        if(numofplayers>1)
        Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
