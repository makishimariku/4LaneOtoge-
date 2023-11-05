using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField] float _notesSpeed;
    bool start;


    private void Start()
    {
        _notesSpeed = GManager.instance.noteSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if(start)
        {
            transform.position -= transform.forward * Time.deltaTime * _notesSpeed;
        }
    }
}
