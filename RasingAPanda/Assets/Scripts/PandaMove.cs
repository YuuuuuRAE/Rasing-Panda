using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PandaMove : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform Panda;
    [SerializeField]
    private Transform[] Destination;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private bool isMove; //움직이고 있는지 체크할 변수
    [SerializeField]
    private bool isArrive;


    [Header("0: 숨쉬기, 1: 넘어지기, 2: 달리기, 3: 앉기, 4: 걷기")]
    [Range(0, 4), SerializeField]
    private int Mode;

    [Header("딜레이 관련"), SerializeField]
    private float WalkDelay;
    [SerializeField]
    private float Min_Delay;
    [SerializeField]
    private float Max_Delay;



    private int RandDes; //랜덤 목적지


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Panda = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        isMove = false;
        isArrive = false;

        Min_Delay = 3f;
        Max_Delay = 5f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == "Panda")
                    Debug.Log("터치");

            }
        }

        if (!isMove)
        {
            isMove = true;
            Mode = Random.Range(0, 5);
            Debug.Log(Mode + "모드 실행");

            switch (Mode)
            {
                case 0:
                    StartCoroutine(BaseDelayCoroutine(Mode));
                    break;
                case 1:
                    animator.SetBool("isFallOver", true);
                    StartCoroutine(BaseDelayCoroutine(Mode));
                    break;
                case 2:
                    StartCoroutine(WalkCoroutine());
                    break;
                case 3:
                    animator.SetBool("isSit", true);
                    StartCoroutine(BaseDelayCoroutine(Mode));
                    break;
                case 4:
                    StartCoroutine(WalkCoroutine());
                    break;
                default:
                    break;
            }
        }

        //Walk
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            if(Mode == 2)
            {
                animator.SetBool("isRun", false);
                agent.velocity /= 2;
            }
            else if(Mode == 4)
            {
                animator.SetBool("isWalk", false);
            }

            if(!isArrive) StartCoroutine(WalkDelayCoroutine());
        }

    }

    IEnumerator BaseDelayCoroutine(int mode)
    {
        float RandDelay = Random.Range(Min_Delay, Max_Delay);
        yield return new WaitForSeconds(RandDelay);

        switch (mode)
        {
            case 1:
                animator.SetBool("isFallOver", false);
                break;
            case 2:
                animator.SetBool("isRun", false);
                break;
            case 3:
                animator.SetBool("isSit", false);
                break;
            default:
                break;
        }

        isMove = false;
    }

    IEnumerator WalkDelayCoroutine()
    {
        isArrive = true;
        yield return new WaitForSeconds(WalkDelay);
        isArrive = false;
        isMove = false;
    }

    IEnumerator WalkCoroutine()
    {
        RandDes = Random.Range(0, Destination.Length);
        if(Mode == 4)
        {
            animator.SetBool("isWalk", true);
        }
        else if (Mode == 2)
        {
            animator.SetBool("isRun", true);
            agent.velocity *= 2;
        }  
        agent.SetDestination(Destination[RandDes].position);

       yield return null;


    }


}
