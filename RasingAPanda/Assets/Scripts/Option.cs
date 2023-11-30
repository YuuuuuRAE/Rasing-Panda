using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private GameObject[] BGMon_Button;
    [SerializeField]
    private GameObject[] BGMoff_Button;
    [SerializeField]
    private GameObject[] Soundon_Button;
    [SerializeField]
    private GameObject[] Soundoff_Button;
    [SerializeField]
    private Slider volumn_slider;

    private Data data;

    private void Start()
    {
        data = DataManager.Instance.data;
    }

    private void Update()
    {
        data.volumn = volumn_slider.value;

    }

    public void BGMON()
    {
        if (data.isBGM) return;

        data.isBGM = true;
        for(int i = 0; i < BGMon_Button.Length; i++)
        {
            BGMon_Button[i].SetActive(true);
            BGMoff_Button[i].SetActive(false);
        }
       
    }

    public void BGMOFF()
    {
        if (!data.isBGM) return;

        data.isBGM = false;
        for(int i = 0; i < BGMoff_Button.Length; i++)
        {
            BGMon_Button[i].SetActive(false);
            BGMoff_Button[i].SetActive(true);
        }
    }

    public void SOUNDON()
    {
        if (data.isSound) return;

        data.isSound = true;
        for (int i = 0; i < Soundon_Button.Length; i++)
        {
            Soundon_Button[i].SetActive(true);
            Soundoff_Button[i].SetActive(false);
        }
    }

    public void SOUNDOFF()
    {
        if (!data.isSound) return;

        data.isSound = false;
        for(int i = 0; i < Soundoff_Button.Length; i++)
        {
            Soundon_Button[i].SetActive(false);
            Soundoff_Button[i].SetActive(true);
        }
    }

    
}
