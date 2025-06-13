using UnityEngine;
using UnityEngine.UI;

public class Fatbunny : MonoBehaviour
{
  public float  AREA = 20f;
  public float MT = 5f;
  public ParticleSystem particleSystem;
  public Button Hiroshimo;
  public bool Explotano = false;
  public void Hiroshima()
  {
    if (Explotano) return;
    Collider[] colliders = Physics.OverlapSphere(transform.position, AREA);
    foreach(Collider collider in colliders)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if(rb == null || rb.isKinematic) continue;
        if(rb.gameObject == gameObject) continue;
        Vector3 direction = rb.transform.position - transform.position;
        rb.AddForce(direction.normalized * MT/direction.magnitude, ForceMode.Impulse);
    }
    particleSystem.Play();
    Explotano = true;
    UpdateButton();
  }
  public void UpdateButton()
  {
    Hiroshimo.interactable = !Explotano;
  }
}
// POV Hiroshima:
//      _____ 
//     /     \
//    |       | 
//     \     /
//      |   |
//      |   |
//     /     \
