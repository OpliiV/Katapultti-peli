using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (cam1.activeSelf) {
                cam2.SetActive(true);
                cam1.SetActive(false);
            } else {
               cam1.SetActive(true); 
               cam2.SetActive(false);
            }
        }
    }
}
