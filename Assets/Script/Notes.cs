using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField] float _notesSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * _notesSpeed;
    }
}
