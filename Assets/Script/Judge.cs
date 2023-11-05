using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _messageObj;      //プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager _notesManager;            //スクリプト「NotesManager」を入れる変数

    // Update is called once per frame
    void Update()
    {
        if(GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //押されたボタンがレーンの番号と合っているか
                if (_notesManager.LaneNum[0] == 0)
                {
                    {
                        Judgement(GetABS(Time.time - (_notesManager.NotesTime[0] + GManager.instance.StartTime)));

                        /*
                         本来ノーツを叩く場所と実際に叩いた場所がどれくらいずれているかを求め、その絶対値をJudgement関数に送る
                        */
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (_notesManager.LaneNum[0] == 1)
                {
                    {
                        Judgement(GetABS(Time.time - (_notesManager.NotesTime[0] + GManager.instance.StartTime)));
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                if (_notesManager.LaneNum[0] == 2)
                {
                    {
                        Judgement(GetABS(Time.time - (_notesManager.NotesTime[0] + GManager.instance.StartTime)));
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                if (_notesManager.LaneNum[0] == 3)
                {
                    {
                        Judgement(GetABS(Time.time - (_notesManager.NotesTime[0] + GManager.instance.StartTime)));
                    }
                }
            }

            if (Time.time > _notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)
            {
                Debug.Log("Miss");
                message(3);
                deleteData();
                GManager.instance.miss++;
                GManager.instance.combo = 0;

            }
        }
    }

    void Judgement(float timeLag)
    {
        if (timeLag <= 0.10)
        {
            Debug.Log("Perfect");
            message(0);
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData();
        }
        else if (timeLag <= 0.15)
        {
            Debug.Log("Great");
            message(1);
            GManager.instance.great++;
            GManager.instance.combo++;
            deleteData();
        }
        else if (timeLag <= 0.20)
        {
            Debug.Log("Bad");
            message(2);
            GManager.instance.bad++;
            GManager.instance.combo = 0;
            deleteData();
        }
    }

    //引数の絶対値を返す関数
    float GetABS(float num)
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }

    void deleteData()
    {
        _notesManager.NotesTime.RemoveAt(0);
        _notesManager.LaneNum.RemoveAt(0);
        _notesManager.NoteType.RemoveAt(0);
    }

    void message(int judge)
    {
        Instantiate(_messageObj[judge], new Vector3(_notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}
