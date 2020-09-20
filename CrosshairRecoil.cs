using UnityEngine;

public class CrosshairRecoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddRecoil();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopRecoil();
        }
    }
    private void AddRecoil()
    {
        transform.position = transform.position + upRecoil;
    }
    private void StopRecoil()
    {
        transform.position = originalPosition;
    }
}
