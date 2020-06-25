using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    /// 仮の移動処理
    private void Movement()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.position += new Vector3(0, 0, -1);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.position += new Vector3(0, 0, 1);
        }
        else { }

        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
        else { }
    }

    private void Jumping()
    {

    }
}
