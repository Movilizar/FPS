using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        animator.SetBool("Switching", false);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
        
    void SelectWeapon()
    {
        Invoke("SwitchAnim", 0.75f);
        Invoke("Switching", 0.375f);
        FindObjectOfType<gun>().enabled = false;
        FindObjectOfType<AudioManager>().Play("WeaponSwitch");
        animator.SetBool("Switching", true);
        
    }
    void SwitchAnim()
    {
        animator.SetBool("Switching", false);
        FindObjectOfType<gun>().enabled = true;
        
    }
    void Switching()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
