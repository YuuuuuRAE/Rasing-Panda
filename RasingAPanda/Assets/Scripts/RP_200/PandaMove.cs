using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaMove : MonoBehaviour
{
    public GameObject Panda;

    [SerializeField]
    private float PandaSpeed;
    [SerializeField]
    private Transform PandaTransform;
    [SerializeField]
    string[] Movedir;
    // Start is called before the first frame update
    void Start()
    {
        PandaTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        GameObject FindObj = GameObject.FindGameObjectWithTag("Effect");
        if (FindObj != null)
        {
            DestroyImmediate(FindObj);
            Panda.GetComponent<Animation>().CrossFade("Idle");
        }

        PandaTransform.Translate(Vector3.forward * PandaSpeed * Time.deltaTime);

        Panda.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        Panda.GetComponent<Animation>().CrossFade("Walk");
    }
}
