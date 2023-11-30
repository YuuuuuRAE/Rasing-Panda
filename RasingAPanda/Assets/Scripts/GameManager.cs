using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;

    [Header("청결도 관련"), SerializeField, Tooltip("청결도 감소 시간 간격")]
    private float clean_delay = 300f; //60 x 5
    [Header("스트레스 관련"), SerializeField, Tooltip("스트레스 증가 시간 간격")]
    private float stress_delay = 300f; //60 x 5
    [Header("나이 관련"), SerializeField]
    private float age_delay = 86400f;



    private bool isFirst;
    private bool isUpdate;



    DateTime ToForegroundTime;
    DateTime ToBackgroundTime;



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
        StartCoroutine("age", age_delay);


        isFirst = false;
    }

    void Update()
    {
        updateAffectionLV();
        //ComputeTime();


        if (data.cleanliness < 0) data.cleanliness = 0;
        if (data.stress > 100) data.stress = 100;

        if (DateTime.Now.ToString("tt") == "AM")
        {
            Camera.main.GetComponent<Camera>().backgroundColor = Color.gray;
        }
        else Camera.main.GetComponent<Camera>().backgroundColor = Color.black;

    }


    private void OnApplicationPause(bool pause)
    {
        if (!isFirst)
        {
            if (pause)
            {
                ToForegroundTime = DateTime.Now;
            }
            else
            {
                ToBackgroundTime = DateTime.Now;
                isUpdate = true;
            }
        }
    }

    public void ComputeTime()
    {
        if (isUpdate)
        {
            var sec = ToBackgroundTime.Subtract(ToBackgroundTime).TotalSeconds;
            for (int i = 0; i < (int)sec / clean_delay; i++)
                data.cleanliness--;
            for (int j = 0; j < (int)sec / stress_delay; j++)
                data.stress++;
            for (int k = 0; k < (int)sec / age_delay; k++)
                data.Panda_age++;

            isUpdate = false;
        }
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
        yield return new WaitForSeconds(delayTime);
        StartCoroutine("cleanliness", delayTime);
    }

    IEnumerator stress(float delayTime)
    {
        if (data.cleanliness > 40) data.stress++;
        else data.stress += 2;
        yield return new WaitForSeconds(delayTime);
        StartCoroutine("stress", delayTime);
    }

    IEnumerator age(float delayTime)
    {
        data.Panda_age++;
        yield return new WaitForSeconds(age_delay);
        StartCoroutine(age(delayTime));
    }
    
}
