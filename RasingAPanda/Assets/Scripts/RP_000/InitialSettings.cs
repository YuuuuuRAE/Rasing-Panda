using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject InitialTab;
    [SerializeField]
    private InputField nameInput;

    void Start()
    {
        //첫 시작일 경우 이름을 설정
        if (DataManager.Instance.data.isFirstStart)
        {
            InitialTab.SetActive(true);
        }
    }

    private void Update()
    {
        DataManager.Instance.data.Panda_name = nameInput.text.ToString();
    }

   

}
