using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontrol : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("how fast the ship moves")]
    [SerializeField] float movesensi = 0.1f;
    [SerializeField] float xrange = 5f;
    [SerializeField] float yrange = 3.5f;
    [SerializeField] GameObject[]lasers; 
    [Header("Rotation sensitivities")]
    [SerializeField] float pitchfactor= -1.2f;
    [SerializeField] float yawfactor= 1.5f;
    [SerializeField] float rollfactor= 1.2f;
    [SerializeField] float controlpitchfactor = -10f;
   
    float xThrow , yThrow;
   
    // Update is called once per frame
    void Update()
    {
        translation();
        Rotation();
        playerfiring();
    }

    void Rotation()
    {

        float PitchDueToPosition = transform.localPosition.y * pitchfactor;

        float PitchDueToThrowFactor = yThrow * controlpitchfactor;
        float pitch = PitchDueToPosition + PitchDueToThrowFactor;
        float yaw = transform.localPosition.x * yawfactor;
        float roll = xThrow * rollfactor ;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void translation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * movesensi;
        float rawxpos = transform.localPosition.x + xOffset;
        float clampedxpos = Mathf.Clamp(rawxpos, -xrange, xrange);


        float yOffset = yThrow * Time.deltaTime * movesensi;
        float rawypos = transform.localPosition.y + yOffset;
        float clampedypos = Mathf.Clamp(rawypos, -yrange, yrange);

        transform.localPosition = new Vector3(clampedxpos, clampedypos, transform.localPosition.z);
    }
    void playerfiring()
    {
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("I'm shooting");
            SetActiveLasers(true);
        }
        else
        {
            Debug.Log("I'm not shooting");
            SetActiveLasers(false);
        }
    }

     void SetActiveLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = isActive;
        }
    }

  
}
