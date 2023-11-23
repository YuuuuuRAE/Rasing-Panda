using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;
    [SerializeField, Header("게임 객체")]
    private GameObject Panda;
    [SerializeField]
    private Interaction interaction;
    [Header("청결도 관련"), SerializeField, Tooltip("청결도 감소 시간 간격")]
    private float clean_delay = 300f; //60 x 5
    [Header("스트레스 관련"), SerializeField, Tooltip("스트레스 증가 시간 간격")]
    private float stress_delay = 300f; //60 x 5
    [Header("애니메이션 관련"), SerializeField, Tooltip("애니메이션 변경 시간")]
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
        //DataManager.Instance.LoadGameData(); //게임이 시작되면 갖고 있는 데이터를 로드
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
        //나중에 제거
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.affection_curXP += 3;
        }

        if (data.affection_curXP >= data.affection_maxXP)
        {
            data.affection_curXP -= data.affection_maxXP; //현재 경험치 (초과분) 계산

            if (data.affection_LV != 1 && data.affection_LV % 5 == 0)
            {
                data.affection_extXP++; //증가분량 증가
            }

            data.affection_maxXP += data.affection_extXP; //반영된 최대 경험치 증가분 만큼 증가
            data.affection_LV++; //레벨 증가
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
