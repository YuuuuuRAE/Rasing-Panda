using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // 직렬화
public class Data
{
    //Common Data
    public int affection_LV = 1;                        //애정도 레벨
    public float affection_curXP = 0;                   //현재 애정도 경험치
    public float affection_maxXP = 5;                   //최대 애정도 경험치
    public float affection_extXP = 5;           

    public int cleanliness = 100;                       //청결도
    public float stress = 0;                            //스트레스 정도

    public int coin = 0;

    public string Panda_name = "푸바오";
    public int Panda_age = 1;

    //Sound
    public bool isBGM = true;
    public bool isSound = true;
    public float volumn = 1;

    //RP_000
    public bool isFirstStart;                           //처음 시작했는지 확인할 변수

    //RP_200
    public int[] feeds = new int[3];                    //먹이의 갯수 (0: 대나무, 1: 워토우, 2: ??)
    public int water;                                   //물의 갯수
    public int[] cleaning_Tools = new int[3];           //청소도구 갯수
    public int[] ct_durability = new int[3] {1, 3, 5};  //청소도구 내구도
    public int[] playing_Tools = new int[3];            //놀이도구 갯수
    public int[] pt_durability = new int[3] {1, 3, 5};  //놀이도구 내구도

    public int feed_num = 0;
    public int ct_num = 0;
    public int pt_num = 0;

    public bool[] click_Butt = new bool[4];
    public float[] time = new float[4];

    

    
}