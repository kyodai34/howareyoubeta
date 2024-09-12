using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    [SerializeField] private GameObject position; 
    

    public Transform Shake;
    public CinemachineBasicMultiChannelPerlin noise;
    public CinemachineVirtualCamera cinemaComponent;

    public void Start()
    {
        cinemaComponent = Shake.GetComponent<CinemachineVirtualCamera>();
        noise = cinemaComponent.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void teleport()
    {
        if (TextContainer.howFood == 0)
        {
            this.transform.position = position.transform.position;
            this.transform.rotation = position.transform.rotation;
        }
        noise.m_FrequencyGain = 0.1f;
        noise.m_AmplitudeGain = 0.2f;

    }
    public void CloseButton()
    {
        noise.m_FrequencyGain = 0.55f;
        noise.m_AmplitudeGain = 0.4f;
    }
    
}
