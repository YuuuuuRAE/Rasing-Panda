using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;
    [SerializeField]
    private GameObject Panda;
    [SerializeField]
    public GameObject[] effPrefabArray = new GameObject[9];
    public GameObject ShootPoint;
    
    private bool isFirst;
    private bool isUpdate;

    System.DateTime ToForegroundTime;
    System.DateTime ToBackgroundTime;

    [Header("RP_200 버튼 관리"), SerializeField]
    private string[] minute_Texts;
    [SerializeField]
    private string[] second_Texts;
    [SerializeField]
    private TMP_Text[] Time_Texts;
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private float accel_ext; //가속 증가량



    void Start()
    {
        data = DataManager.Instance.data;
        isFirst = false;
    }

    void Update()
    {
        FeedButton();
        WaterButton();
        CleanButton();
        PlayButton();

        //ComputeTime();
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
            
            for (int i = 0; i < data.time.Length; i++)
            {
                data.time[i] += (float)sec;
            }

            isUpdate = false;
        }
    }


    public void EffectClear()
    {
        GameObject FindObj = GameObject.FindGameObjectWithTag("Effect");
        if(FindObj != null)
        {
            DestroyImmediate(FindObj);
            Panda.GetComponent<Animation>().CrossFade("Idle");
        }
    }

    public void CheckClickButton(int index)
    {
        data.click_Butt[index] = true;
        Time_Texts[index].gameObject.SetActive(true);
    }

    public void AccelInteraction()
    {
        for (int i = 0; i < data.time.Length; i++)
        {
            if (data.click_Butt[i])
            {
                data.time[i] += accel_ext;
            }
        }


    }

    private void FeedButton()
    {
        if (data.click_Butt[0])
        {

            data.time[0] += Time.deltaTime;
            
            buttons[0].interactable = false;

            minute_Texts[0] = ((3600 - (int)data.time[0]) / 60 % 60).ToString();
            second_Texts[0] = ((3600 - (int)data.time[0]) % 60).ToString();

            Time_Texts[0].text = minute_Texts[0] + " : " + second_Texts[0];

            if (data.time[0] >= 3600)
            {
                data.click_Butt[0] = false;
                data.time[0] = 0;
                Time_Texts[0].gameObject.SetActive(false);
                buttons[0].interactable = true;
            }
        }
    }

    private void WaterButton()
    {
        if (data.click_Butt[1])
        {

            data.time[1] += Time.deltaTime;

            buttons[1].interactable = false;

            minute_Texts[1] = ((3600 - (int)data.time[1]) / 60 % 60).ToString();
            second_Texts[1] = ((3600 - (int)data.time[1]) % 60).ToString();

            Time_Texts[1].text = minute_Texts[1] + " : " + second_Texts[1];

            if (data.time[1] >= 3600)
            {
                data.click_Butt[1] = false;
                data.time[1] = 0;
                Time_Texts[1].gameObject.SetActive(false);
                buttons[1].interactable = true;
            }
        }
    }

    private void CleanButton()
    {
        if (data.click_Butt[2])
        {

            data.time[2] += Time.deltaTime;

            buttons[2].interactable = false;

            minute_Texts[2] = ((3600 - (int)data.time[2]) / 60 % 60).ToString();
            second_Texts[2] = ((3600 - (int)data.time[2]) % 60).ToString();

            Time_Texts[2].text = minute_Texts[2] + " : " + second_Texts[2];

            if (data.time[2] >= 3600)
            {
                data.click_Butt[2] = false;
                data.time[2] = 0;
                Time_Texts[2].gameObject.SetActive(false);
                buttons[2].interactable = true;
            }
        }
    }

    private void PlayButton()
    {
        if (data.click_Butt[3])
        {

            data.time[3] += Time.deltaTime;

            buttons[3].interactable = false;

            minute_Texts[3] = ((3600 - (int)data.time[3]) / 60 % 60).ToString();
            second_Texts[3] = ((3600 - (int)data.time[3]) % 60).ToString();

            Time_Texts[3].text = minute_Texts[3] + " : " + second_Texts[3];

            if (data.time[3] >= 3600)
            {
                data.click_Butt[3] = false;
                data.time[3] = 0;
                Time_Texts[3].gameObject.SetActive(false);
                buttons[3].interactable = true;
            }
        }
    }



    /// <summary>
    ///  각각의 array 인덱스는 유동적으로 바꿀 수 있도록 수정할 것!
    /// </summary>

    public void Feed(int f_num)
    {
        if (data.feeds[f_num] > 0)
        {
            data.feeds[f_num]--;

            FeedAnimation();

            //각 음식에 맞게 애정도 증가
            switch (f_num)
            {
                case 0:
                    data.affection_curXP += 1;
                    break;
                case 1:
                    data.affection_curXP += 2;
                    break;
                case 2:
                    data.affection_curXP += 3;
                    break;
                default:
                    break;

            }
        }
        else Debug.Log("음식이 부족합니다!");
    }

    private void FeedAnimation()
    {
        EffectClear();
        Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        Panda.GetComponent<Animation>().CrossFade("Eat");
        if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[0]);
        Invoke("EffectClear", 3f);
    }

    public void Water()
    {
        if (data.water > 0)
        {
            FeedAnimation();
            data.water--;
            data.affection_curXP += 3;
        }
        else Debug.Log("물이 부족합니다!");
    }

    public void Clean(int c_num)
    {
        if (data.cleaning_Tools[c_num] > 0)
        {
            CleanAnimation();

            int durability = 0;

            data.ct_durability[c_num]--; //내구도 감소

            switch (c_num)
            {
                case 0:
                    durability = 1;
                    data.cleanliness += 1;
                    break;
                case 1:
                    durability = 3;
                    data.cleanliness += 2;
                    break;
                case 3:
                    durability = 5;
                    data.cleanliness += 3;
                    break;
            }

            if (data.ct_durability[c_num] <= 0)
            {
                data.cleaning_Tools[c_num]--;
                data.ct_durability[c_num] = durability;
            }

        }
        else Debug.Log(c_num + "번째 청소도구가 부족합니다!");
    }

    private void CleanAnimation()
    {
        EffectClear();
        Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        Panda.GetComponent<Animation>().CrossFade("Run");
        if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[1]);
        Invoke("EffectClear", 3f);
    }

    public void Play(int p_num)
    {
        if (data.playing_Tools[p_num] > 0)
        {
            PlayAnimation();

            int durability = 0;

            data.pt_durability[p_num]--; //내구도 감소

            switch (p_num)
            {
                case 0:
                    durability = 1;
                    data.stress -= 1;
                    break;
                case 1:
                    durability = 3;
                    data.stress -= 2;
                    break;
                case 3:
                    durability = 5;
                    data.stress -= 3;
                    break;
            }

            if (data.pt_durability[p_num] <= 0)
            {
                data.playing_Tools[p_num]--;
                data.pt_durability[p_num] = durability;
            }

        }
        else Debug.Log(p_num + "번째 놀이도구가 부족합니다!");
    }

    private void PlayAnimation()
    {
        EffectClear();
        Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        Panda.GetComponent<Animation>().CrossFade("Surprise");

        Vector3 playerV = new Vector3(ShootPoint.transform.position.x, ShootPoint.transform.position.y, ShootPoint.transform.position.z);
        Instantiate(effPrefabArray[2], new Vector3(playerV.x, playerV.y, playerV.z), Panda.transform.rotation);

        Invoke("EffectClear", 3f);
    }

    public void Call()
    {
        if(data.stress > 80)
        {
            EffectClear();
            Panda.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Panda.GetComponent<Animation>().CrossFade("Damage");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[3]);
        }
        else if(data.stress > 60)
        {
            EffectClear();
            Panda.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Panda.GetComponent<Animation>().CrossFade("Attack");

            Vector3 playerV = new Vector3(ShootPoint.transform.position.x, ShootPoint.transform.position.y, ShootPoint.transform.position.z);
            Instantiate(effPrefabArray[4], new Vector3(playerV.x, playerV.y, playerV.z), Panda.transform.rotation);
        }
        else if(data.stress > 40)
        {
            EffectClear();
            Panda.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Panda.GetComponent<Animation>().CrossFade("AttackStand");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[5]);
        }
        else if(data.stress > 20)
        {
            EffectClear();
            Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Panda.GetComponent<Animation>().CrossFade("Walk");
            Invoke("EffectClear", 3f);
        }
        else
        {
            EffectClear();
            Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Panda.GetComponent<Animation>().CrossFade("Stand");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[6]);
            Invoke("EffectClear", 3f);
        }
    }

}
