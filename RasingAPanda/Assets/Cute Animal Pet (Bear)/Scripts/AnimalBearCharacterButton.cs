using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimalBearCharacterButton : MonoBehaviour
{

    public GameObject Animal;
    public GameObject ShootPoint;
    public SkinnedMeshRenderer bodyMesh;

    public Texture[] bodyTextureArray = new Texture[4];
    public GameObject[] effPrefabArray = new GameObject[9];

    // Use this for initialization
    void Start()
    {

    }

    void EffectClear()
    {
        GameObject tFindObj = GameObject.FindGameObjectWithTag("Effect");
        if (tFindObj != null)
        {
            DestroyImmediate(tFindObj);
        }
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 70, 40), "Idle"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Idle");
        }
        if (GUI.Button(new Rect(90, 20, 70, 40), "Stand"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Stand");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[6]);
        }
        if (GUI.Button(new Rect(160, 20, 70, 40), "Walk"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Walk");
        }
        if (GUI.Button(new Rect(230, 20, 70, 40), "Run"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Run");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[5]);

        }
        if (GUI.Button(new Rect(300, 20, 70, 40), "Attack"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Animal.GetComponent<Animation>().CrossFade("Attack");

            Vector3 playerV = new Vector3(ShootPoint.transform.position.x, ShootPoint.transform.position.y, ShootPoint.transform.position.z);
            Instantiate(effPrefabArray[0], new Vector3(playerV.x, playerV.y, playerV.z), Animal.transform.rotation);
        }
        if (GUI.Button(new Rect(370, 20, 90, 40), "AttackStand"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("AttackStand");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[2]);
        }

        if (GUI.Button(new Rect(460, 20, 70, 40), "Damage"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Animal.GetComponent<Animation>().CrossFade("Damage");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[3]);
        }

        if (GUI.Button(new Rect(530, 20, 70, 40), "Eat"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Eat");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[7]);
        }
        if (GUI.Button(new Rect(600, 20, 70, 40), "Sleep"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Loop;
            Animal.GetComponent<Animation>().CrossFade("Sleep");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[1]);
        }
        if (GUI.Button(new Rect(670, 20, 70, 40), "Surprise"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Animal.GetComponent<Animation>().CrossFade("Surprise");
            //if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[8]);

            Vector3 playerV = new Vector3(ShootPoint.transform.position.x, ShootPoint.transform.position.y, ShootPoint.transform.position.z);
            Instantiate(effPrefabArray[8], new Vector3(playerV.x, playerV.y, playerV.z), Animal.transform.rotation);
            
        }
        if (GUI.Button(new Rect(740, 20, 70, 40), "Die"))
        {
            EffectClear();
            Animal.GetComponent<Animation>().wrapMode = WrapMode.Once;
            Animal.GetComponent<Animation>().CrossFade("Die");
            if (GameObject.FindGameObjectWithTag("Effect") == null) GameObject.Instantiate(effPrefabArray[4]);
        }
        /////////////////////////////////////////////////////////////////////

        
        if (GUI.Button(new Rect(20, 740, 120, 40), "RandomBody"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[Random.Range(0, bodyTextureArray.Length)]);
        }
        if (GUI.Button(new Rect(150, 740, 70, 40), "Body_01"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[0]);
        }
        if (GUI.Button(new Rect(220, 740, 70, 40), "Body_02"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[1]);
        }
        if (GUI.Button(new Rect(290, 740, 70, 40), "Body_03"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[2]);
        }
        if (GUI.Button(new Rect(360, 740, 70, 40), "Body_04"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[3]);
        }
        if (GUI.Button(new Rect(430, 740, 70, 40), "Body_05"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[4]);
        }
        if (GUI.Button(new Rect(500, 740, 70, 40), "Body_06"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[5]);
        }
        if (GUI.Button(new Rect(570, 740, 70, 40), "Body_07"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[6]);
        }
        if (GUI.Button(new Rect(640, 740, 70, 40), "Body_08"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[7]);
        }
        if (GUI.Button(new Rect(710, 740, 70, 40), "Body_09"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[8]);
        }
        if (GUI.Button(new Rect(780, 740, 70, 40), "Body_10"))
        {
            bodyMesh.materials[0].SetTexture("_MainTex", bodyTextureArray[9]);
        }
        ////////////////////////////////////////////////////////////////////
        if (GUI.Button(new Rect(720, 420, 120, 40), "Bear01"))
        {
            SceneManager.LoadScene("Bear_01");
        }

        if (GUI.Button(new Rect(720, 460, 120, 40), "Bear02"))
        {
            SceneManager.LoadScene("Bear_02");
        }

        if (GUI.Button(new Rect(720, 500, 120, 40), "Bear03"))
        {
            SceneManager.LoadScene("Bear_03");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

}
