using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class StartCamera : MonoBehaviour
{
    [SerializeField] private float camersCoeff, speedChangeCamers, cameraDestroy;

    private CinemachineVirtualCamera civiCamera;

    private void Awake()
    {
        civiCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (civiCamera.m_Lens.OrthographicSize < camersCoeff)
            civiCamera.m_Lens.OrthographicSize += speedChangeCamers;
        else
            Destroy(gameObject, cameraDestroy);
    }
}
