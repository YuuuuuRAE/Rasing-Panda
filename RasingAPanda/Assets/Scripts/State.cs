using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class State : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;

    [Header("������"),SerializeField]
    private Slider affection_slider;                //������ �����̴�
    [SerializeField]
    private TMP_Text affection_XP;                  //���� ����ġ �ؽ�Ʈ
    [SerializeField]
    private TMP_Text affection_LV;                  //���� ���� �ؽ�Ʈ
    [SerializeField]
    private TMP_Text coin;


    void Start()
    {
        data = DataManager.Instance.data;
    }

    void Update()
    {
        updateAffection();
        updateLV();
    }

    private void updateAffection()
    {
        affection_XP.text = data.affection_curXP.ToString() + " / " + data.affection_maxXP.ToString();
        affection_slider.value = data.affection_curXP / data.affection_maxXP;
    }

    private void updateLV()
    {
        affection_LV.text = data.affection_LV.ToString();
    }

    private void updateCoin()
    {
        coin.text = data.coin.ToString();
    }
}
