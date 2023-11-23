using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private Data data;
    [SerializeField]
    private GameObject Panda;
    [SerializeField]
    public GameObject[] effPrefabArray = new GameObject[9];
    [SerializeField]
    private GameObject ShootPoint;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.Instance.data;

    }

    // Update is called once per frame
    void Update()
    {

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
