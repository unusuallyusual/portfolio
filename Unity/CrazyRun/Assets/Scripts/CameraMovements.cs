using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
  [SerializeField] private GameObject target;
  [SerializeField] private float xOffset, yOffset, zOffset;
  private int lr = 0;

  private void Update()
  {    
    if (lr == 0)
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        xOffset -= zOffset;
        zOffset += xOffset;
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
        xOffset = zOffset;
        zOffset -= xOffset;
      }
    }

    if (lr == 2 || lr == -2)
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        xOffset -= zOffset;
        zOffset += xOffset;
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
        xOffset += zOffset;
        zOffset -= xOffset;
      }
    }

    if (lr == -1 || lr == 3)
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        zOffset += xOffset;
        xOffset = 0;
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
        zOffset -= xOffset;
        xOffset += zOffset;
      }
    }

    if (lr == 1 || lr == -3)
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        zOffset += xOffset;
        xOffset = 0;
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
        zOffset -= xOffset;
        xOffset = 0;
      }
    }
  }

  private void LateUpdate()
  {
    if (Input.GetKeyDown(KeyCode.Z))
      lr++;
    if (Input.GetKeyDown(KeyCode.C))
      lr--;
    if (lr > 3 || lr < -3)
      lr = 0;
    transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
    transform.LookAt(target.transform.position);
  }
}
