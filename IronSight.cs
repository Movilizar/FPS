using UnityEngine;

public class IronSight : MonoBehaviour
{
    public Animator ironSight;
    public GameObject crossHair;
    
    void Start()
    {
        ironSight.SetBool("Aiming", false);
    }

    
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            ironSight.SetBool("Aiming", true);
            crossHair.SetActive(false);
        }
        else
        {
            ironSight.SetBool("Aiming", false);
            crossHair.SetActive(true);
        }
    }
}

