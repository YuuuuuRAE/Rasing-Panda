using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // ����ȭ
public class Data
{
    //Common Data
    public int affection_LV = 1;                        //������ ����
    public float affection_curXP = 0;                   //���� ������ ����ġ
    public float affection_maxXP = 5;                   //�ִ� ������ ����ġ
    public float affection_extXP = 5;           

    public int cleanliness = 100;                       //û�ᵵ
    public float stress = 0;                            //��Ʈ���� ����

    public int coin = 0;

    public string Panda_name = "Ǫ�ٿ�";
    public int Panda_age = 1;

    //Sound
    public bool isBGM = true;
    public bool isSound = true;
    public float volumn = 1;

    //RP_000
    public bool isFirstStart;                           //ó�� �����ߴ��� Ȯ���� ����

    //RP_200
    public int[] feeds = new int[3];                    //������ ���� (0: �볪��, 1: �����, 2: ??)
    public int water;                                   //���� ����
    public int[] cleaning_Tools = new int[3];           //û�ҵ��� ����
    public int[] ct_durability = new int[3] {1, 3, 5};  //û�ҵ��� ������
    public int[] playing_Tools = new int[3];            //���̵��� ����
    public int[] pt_durability = new int[3] {1, 3, 5};  //���̵��� ������

    public int feed_num = 0;
    public int ct_num = 0;
    public int pt_num = 0;

    public bool[] click_Butt = new bool[4];
    public float[] time = new float[4];

    

    
}