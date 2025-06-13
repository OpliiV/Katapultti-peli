using UnityEngine;


public class Cub : MonoBehaviour
{
    private bool hasScored = false;
    

    void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Ground")){
            hasScored = true;
            Scormanager.instance.AddScore(10);
        }
    }
}
