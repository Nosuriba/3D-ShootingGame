using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// 仮の移動処理
    private void Movement()
    {
        if (Input.GetAxis("Vertical2") < 0 &&
            camera.transform.localEulerAngles.x >= -10)
        {
            camera.transform.Rotate(new Vector3(-0.2f, 0, 0));
        }
        else if (Input.GetAxis("Vertical2") > 0 &&
                 camera.transform.localEulerAngles.x <= 10)
        {
            camera.transform.Rotate(new Vector3(0.2f, 0, 0));
        }
        else {}

        if (Input.GetAxis("Horizontal2") < 0)
        {
            camera.transform.Rotate(new Vector3(0, 0.2f, 0));
        }
        else if (Input.GetAxis("Horizontal2") > 0)
        {
            this.transform.position += new Vector3(0, 0.2f, 0);
        }
        else {}
    }
}
