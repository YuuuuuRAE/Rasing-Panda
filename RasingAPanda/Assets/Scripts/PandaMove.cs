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
    private bool isMove; //�����̰� �ִ��� üũ�� ����
    [SerializeField]
    private bool isArrive;


    [Header("0: ������, 1: �Ѿ�����, 2: �޸���, 3: �ɱ�, 4: �ȱ�")]
    [Range(0, 4), SerializeField]
    private int Mode;

    [Header("������ ����"), SerializeField]
    private float WalkDelay;
    [SerializeField]
    private float Min_Delay;
    [SerializeField]
    private float Max_Delay;



    private int RandDes; //���� ������


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
                    Debug.Log("��ġ");

            }
        }

        if (!isMove)
        {
            isMove = true;
            Mode = Random.Range(0, 5);
            Debug.Log(Mode + "��� ����");

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
