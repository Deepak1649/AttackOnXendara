using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{
    [SerializeField] float timetilldestroy;
        void Update()
    {
        Destroy(gameObject,timetilldestroy);
    }
}
