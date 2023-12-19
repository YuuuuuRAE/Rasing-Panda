using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlSky : MonoBehaviour
{
    [SerializeField]
    private float roteteSpeed;
    [SerializeField]
    private Material dayMat;
    [SerializeField]
    private Material nightMat;
    [SerializeField]
    private GameObject dayLight;
    [SerializeField]
    private GameObject nightLight;

    public Color dayFog;
    public Color nightFog;
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * roteteSpeed);
        SwitchDayandNight();
    }

    void SwitchDayandNight()
    {
        if (DateTime.Now.ToString("tt") == "AM")
        {
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            nightLight.SetActive(false);
        }
        else
        {
            RenderSettings.skybox = nightMat;
            RenderSettings.fogColor = nightFog;
            dayLight.SetActive(false);
            nightLight.SetActive(true);
        }
            
    }
}
