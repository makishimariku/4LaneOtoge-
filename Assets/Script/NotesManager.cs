using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public float BPM;
    public float offset;
    public Note[] notes;
}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesManager : MonoBehaviour



{
    public int noteNum;         //���m�[�c��
    private string songName;    //�Ȗ�������ϐ�

    public List<int> LaneNum = new List<int>();                     //���Ԃ̃��[���Ƀm�[�c�������Ă��邩
    public List<int> NoteType = new List<int>();                    //���m�[�c���i�m�[�c�̎�ށj
    public List<float> NotesTime = new List<float>();               //�m�[�c��������Əd�Ȃ鎞��
    public List<GameObject> NotesObj = new List<GameObject>();      //GameObject

    [SerializeField] private float _notesSpeed;                     //�m�[�c�X�s�[�h
    [SerializeField] GameObject _noteObj;                           //�m�[�c�̃v���n�u������

    void OnEnable()
    {
        noteNum = 0;                    //���m�[�c����0��
        songName = "���@�̋i���X";      //�v���C����Ȗ����擾(��)
        Load(songName);                 //Load()���Ăяo��
    }

    private void Load(string SongName)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);                   //json�t�@�C����ǂݍ���

        noteNum = inputJson.notes.Length;           //���m�[�c����ݒ�


        //���C������
        for(int i = 0; i < inputJson.notes.Length; i++)
        {
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset + 0.01f;

            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float z = NotesTime[i] * _notesSpeed;
            NotesObj.Add(Instantiate(_noteObj, new Vector3(inputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));
        }
    }
}
