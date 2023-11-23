using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;
    [SerializeField, Header("���� ��ü")]
    private GameObject Panda;
    [SerializeField]
    private Interaction interaction;
    [Header("û�ᵵ ����"), SerializeField, Tooltip("û�ᵵ ���� �ð� ����")]
    private float clean_delay = 300f; //60 x 5
    [Header("��Ʈ���� ����"), SerializeField, Tooltip("��Ʈ���� ���� �ð� ����")]
    private float stress_delay = 300f; //60 x 5
    [Header("�ִϸ��̼� ����"), SerializeField, Tooltip("�ִϸ��̼� ���� �ð�")]
    private float animation_delay = 180f;




    static public GameManager instance;

    private void Awake()
    {
        if(instance == null) 
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        //DataManager.Instance.LoadGameData(); //������ ���۵Ǹ� ���� �ִ� �����͸� �ε�
        data = DataManager.Instance.data;
        StartCoroutine("cleanliness", clean_delay);
        StartCoroutine("stress", stress_delay);
        StartCoroutine(pandaanimation(animation_delay));
    }

    void Update()
    {
        //Computate LV
        updateAffectionLV();



    }

    private void updateAffectionLV()
    {
        //���߿� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.affection_curXP += 3;
        }

        if (data.affection_curXP >= data.affection_maxXP)
        {
            data.affection_curXP -= data.affection_maxXP; //���� ����ġ (�ʰ���) ���

            if (data.affection_LV != 1 && data.affection_LV % 5 == 0)
            {
                data.affection_extXP++; //�����з� ����
            }

            data.affection_maxXP += data.affection_extXP; //�ݿ��� �ִ� ����ġ ������ ��ŭ ����
            data.affection_LV++; //���� ����
        }
    }

    IEnumerator cleanliness(float delayTime)
    {
        data.cleanliness--;

        if(data.cleanliness < 0) data.cleanliness = 0;

        yield return new WaitForSeconds(delayTime);
        StartCoroutine("cleanliness", delayTime);
    }

    IEnumerator stress(float delayTime)
    {
        if (data.cleanliness > 40) data.stress++;
        else data.stress += 2;

        if (data.stress > 100) data.stress = 100;

        yield return new WaitForSeconds(delayTime);
        StartCoroutine("stress", delayTime);
    }

    IEnumerator pandaanimation(float delayTime)
    {
        int Rand = Random.Range(0, 2);

        switch (Rand)
        {
            case 0:
                interaction.EffectClear();
                Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                Panda.GetComponent<Animation>().CrossFade("Idle");
                break;
            case 1:
                interaction.EffectClear();
                Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                Panda.GetComponent<Animation>().CrossFade("Sleep");
                if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(interaction.effPrefabArray[7]);
                break;
        }

        yield return new WaitForSeconds(delayTime);

        StartCoroutine(pandaanimation(delayTime));
    }
}
