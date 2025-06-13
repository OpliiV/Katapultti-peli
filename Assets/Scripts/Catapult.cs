using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Catapult : MonoBehaviour
{
    public Transform launchPosition;
    public Rigidbody characterRb;
    public Fatbunny fatbunny;
    public Animator armAnimator;
    public Transform turret;
    public float launchForce = 15f;
    public float verticalLift = 0.5f; //RIP Vector 3 8.6.2025-11.6.2025 
    public float rotationSpeed = 25f;
    public int buni = 12;
    public Slider Fork;
    public TextMeshProUGUI ForkText;
    public Slider Lift;
    public TextMeshProUGUI LiftText;
    public TextMeshProUGUI puni;
    private Quaternion initialBunnyRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialBunnyRotation = characterRb.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Muumi");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Game");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Lunch();
        }
         if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCatapulto();
        }
        HandleRotation();
    }

    void UpdateUI()
    {
        launchForce = Fork.value;
        verticalLift = Lift.value;
        ForkText.text = "Force: " + Mathf.RoundToInt(launchForce);
        LiftText.text = "Lift: " + verticalLift.ToString("n2");
        puni.text = "Bunnies left: " + buni;
    }    
    void Lunch() 
    {
        characterRb.isKinematic = false;
        characterRb.transform.parent = null;
        Vector3 launchDirection = turret.forward + Vector3.up * verticalLift;
        characterRb.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        armAnimator.SetTrigger("lunch");
    }

    void ResetCatapulto()
    {
        if (buni == 0) return;
        buni -= 1;
        characterRb.isKinematic = true;
        characterRb.transform.parent = launchPosition;
        characterRb.transform.position = launchPosition.position;
        characterRb.transform.rotation = initialBunnyRotation;
        fatbunny.Explotano = false;
        fatbunny.UpdateButton();
        
        
    }

    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        if (characterRb.isKinematic)
        {
            characterRb.transform.position = launchPosition.position;
            characterRb.transform.rotation = launchPosition.rotation * initialBunnyRotation;
        }

    }
    
}
