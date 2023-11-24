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
    [SerializeField,Header("�� ǥ��(û�ᵵ, ��Ʈ����")]
    private Sprite[] face;
    [SerializeField]
    private Image clean_face;
    [SerializeField]
    private Image stress_face;

    void Start()
    {
        data = DataManager.Instance.data;
    }

    void Update()
    {
        updateAffection();
        updateLV();
        updateCoin();

        updateStreeFace();
        updateCleanFace();

    }

    private void updateStreeFace()
    {
        if(data.stress > 80)
        {
            stress_face.sprite = face[4];
        }
        else if(data.stress > 60)
        {
            stress_face.sprite = face[3];
        }
        else if(data.stress > 40)
        {
            stress_face.sprite = face[2];
        }
        else if(data.stress > 20)
        {
            stress_face.sprite = face[1];
        }
        else
        {
            stress_face.sprite = face[0];
        }
    }

    private void updateCleanFace()
    {
        if(data.cleanliness > 80)
        {
            clean_face.sprite = face[0];
        }
        else if(data.cleanliness > 60)
        {
            clean_face.sprite = face[1];
        }
        else if(data.cleanliness > 40)
        {
            clean_face.sprite = face[2];
        }
        else if(data.cleanliness > 20)
        {
            clean_face.sprite = face[3];
        }
        else
        {
            clean_face.sprite = face[4];
        }
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
