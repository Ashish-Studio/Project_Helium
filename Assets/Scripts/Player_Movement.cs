using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Movement : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float XSpeed = 2f;
    [Tooltip("In m")] [SerializeField] float XRange = 0.3f;

   
    [Tooltip("In ms^-1")] [SerializeField] float YSpeed = 2f;
    [Tooltip("In m")] [SerializeField] float YRange = 0.11f;

    [SerializeField] GameObject[] Guns;

    [Header("Position Factor")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;

    [Header("Control Factor")]
    [SerializeField] float controlRollFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;

    float horizontalThrow;
    float verticalThrow;
    bool IsControlEnabled = true;
   
    // Update is called once per frame
    void Update()
    {
        if (IsControlEnabled)
        {
            ProcessingMovement();
            ProcessingRotation();
            ProcessingFiring();
        }
    }
  
    void OnPlayerDeath() // string ref
    {
       // print("frozen controls");
        IsControlEnabled = false;
    }

    private void ProcessingMovement()
    {
         horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //print(horizontalThrow);
         verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //print(verticalThrow);
        


        float Xoffset = horizontalThrow * XSpeed * Time.deltaTime;
        float Yoffset = verticalThrow * YSpeed * Time.deltaTime;
        //print(XoffsetThisFrame);


        float RawXpos = transform.localPosition.x + Xoffset;
        float clampedXpos = Mathf.Clamp(RawXpos, -XRange, XRange);
        //print(clampedXpos);

        float RawYpos = transform.localPosition.y + Yoffset;
        float clampedYpos = Mathf.Clamp(RawYpos, -YRange, YRange);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }

    private void ProcessingRotation()
    {


        float pitch = transform.localPosition.y*positionPitchFactor+verticalThrow*controlPitchFactor;
        float Yaw = transform.localPosition.x*positionYawFactor;
        float roll = horizontalThrow*controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, Yaw, roll);
    }

    void ProcessingFiring()
    {
        bool fireInput = CrossPlatformInputManager.GetButton("Fire1");
        //print(fireInput);

        if (fireInput)
        {
            ActivateTheGuns();
        }
        else
        {
            DeatcivateTheGuns();
        }
        
    }

    private void ActivateTheGuns()
    {
        foreach(GameObject gun in Guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeatcivateTheGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(false);
        }
    }

  
}
