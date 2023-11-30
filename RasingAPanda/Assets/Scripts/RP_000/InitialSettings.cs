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
    private float ShowISdelayTime; //�ʱ� ���� �̸� �� ���� ������ �ð�
    [SerializeField]
    private float ConvertDelayTime;

    void Start()
    {
        //ù ������ ��� �̸��� ����
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
