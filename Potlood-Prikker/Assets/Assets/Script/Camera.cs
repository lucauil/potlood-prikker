
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera c_VirtualCamera;

    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    // Start is called before the first frame update
    void Start()
    {
        c_VirtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Blue.activeSelf)
        {
            c_VirtualCamera.Follow = Blue.transform;
        }
        if (Red.activeSelf)
        {
            c_VirtualCamera.Follow = Red.transform;
        }
        if (Green.activeSelf)
        {
            c_VirtualCamera.Follow = Green.transform;
        }
    }
}
