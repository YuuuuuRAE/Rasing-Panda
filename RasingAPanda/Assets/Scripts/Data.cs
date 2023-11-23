using System;
using System.Collections.Generic;

[Serializable] // ����ȭ
public class Data
{
    //Common Data
    public int affection_LV = 1;                        //������ ����
    public float affection_curXP = 0;                   //���� ������ ����ġ
    public float affection_maxXP = 5;                   //�ִ� ������ ����ġ
    public float affection_extXP = 5;           

    public int cleanliness = 100;                       //û�ᵵ
    public float stress = 0;                                //��Ʈ���� ����

    //RP_000
    public bool isFirstStart;                           //ó�� �����ߴ��� Ȯ���� ����

    //RP_100
    public int[] feeds = new int[3];                    //������ ���� (0: �볪��, 1: �����, 2: ??)
    public int water;                                   //���� ����
    public int[] cleaning_Tools = new int[3];           //û�ҵ��� ����
    public int[] ct_durability = new int[3] {1, 3, 5};  //û�ҵ��� ������
    public int[] playing_Tools = new int[3];            //���̵��� ����
    public int[] pt_durability = new int[3] {1, 3, 5};  //���̵��� ������

    
}