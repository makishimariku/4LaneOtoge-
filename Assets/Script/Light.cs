using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private int _num = 0;
    private Renderer Rend;
    private float alfa = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(Rend.material.color.a <= 0))
        {
            Rend.material.color = new Color(Rend.material.color.r, Rend.material.color.g, Rend.material.color.b, alfa);
        }

        if(_num == 1)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                ColorChange();
            }
        }
        else if (_num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ColorChange();
            }
        }
        else if (_num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ColorChange();
            }
        }
        else if (_num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ColorChange();
            }
        }

        alfa -= _speed * Time.deltaTime;
    }

    void ColorChange()
    {
        alfa = 0.3f;
        Rend.material.color = new Color(Rend.material.color.r, Rend.material.color.g, Rend.material.color.b, alfa);
    }
}
