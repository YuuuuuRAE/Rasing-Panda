using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panda : MonoBehaviour
{
    [SerializeField, Header("게임 객체")]
    private GameObject panda;
    [SerializeField]
    private Interaction interaction;
    [Header("애니메이션 관련"), SerializeField, Tooltip("애니메이션 변경 시간")]
    private float animation_delay = 180f;
    [Header("팬더 정보"), SerializeField]
    private TMP_Text Panda_name;
    [SerializeField]
    private TMP_Text Panda_age;

    private Data data;

    void Start()
    {
        StartCoroutine(pandaanimation(animation_delay));
        data = DataManager.Instance.data;
    }

    // Update is called once per frame
    void Update()
    {
        updatePandaInfo();
    }

    IEnumerator pandaanimation(float delayTime)
    {
        int Rand = UnityEngine.Random.Range(0, 2);

        switch (Rand)
        {
            case 0:
                interaction.EffectClear();
                panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                panda.GetComponent<Animation>().CrossFade("Idle");
                break;
            case 1:
                interaction.EffectClear();
                panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                panda.GetComponent<Animation>().CrossFade("Sleep");
                if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(interaction.effPrefabArray[7]);
                break;
        }

        yield return new WaitForSeconds(delayTime);

        StartCoroutine(pandaanimation(delayTime));
    }

    private void updatePandaInfo()
    {
        Panda_name.text = data.Panda_name.ToString();
        Panda_age.text = data.Panda_age.ToString() + " 살";
    }
}
