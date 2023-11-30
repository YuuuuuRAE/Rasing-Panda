using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject InitialTab;
    [SerializeField]
    private InputField nameInput;

    [SerializeField]
    private string SceneName;

    [SerializeField]
    private float ShowISdelayTime; //초기 설정 이름 탭 등장 딜레이 시간
    [SerializeField]
    private float ConvertDelayTime;

    void Start()
    {
        //첫 시작일 경우 이름을 설정
        if (DataManager.Instance.data.isFirstStart)
        {
            Invoke("ShowInitialSetting", ShowISdelayTime);
        }
    }

    private void Update()
    {
        DataManager.Instance.data.Panda_name = nameInput.text.ToString();
    }

    public void ShowInitialSetting()
    {
        InitialTab.SetActive(true);
    }

    public void GameStart()
    {
        if (DataManager.Instance.data.isFirstStart) {
            InitialTab.SetActive(false);
            DataManager.Instance.data.isFirstStart = false;
        }
        Invoke("ConvertScene", ConvertDelayTime);
    }
   
    public void ConvertScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
