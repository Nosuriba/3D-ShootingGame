using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;      // カメラの情報

    [SerializeField]
    private GameObject   target;     // カメラのターゲット

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        Movement();
    }

    /// 仮の移動処理
    private void Movement()
    {
        if (Input.GetAxis("Vertical2") < 0 )
        {
            camera.transform.RotateAround(target.transform.position, this.transform.right, 100 * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical2") > 0)
        {
            camera.transform.RotateAround(target.transform.position, this.transform.right, -100 * Time.deltaTime);
        }
        else {}

        if (Input.GetAxis("Horizontal2") < 0)
        {
            camera.transform.RotateAround(target.transform.position, Vector3.up, 100 * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal2") > 0)
        {
            camera.transform.RotateAround(target.transform.position, Vector3.up, -100 * Time.deltaTime);
        }
        else {}
    }
}
