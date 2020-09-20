using UnityEngine;
using UnityStandardAssets.Effects;

public class AdvancedGunRecoil : MonoBehaviour
{
    [Header("Referencepoints:")]
    public Transform recoilPosition;
    public Transform rotationPoint;
    [Space(10)]

    [Header("Speed Settings:")]
    public float positionalRecoilSpeed = 8f;
    public float rotationalRecoilSpeed = 8f;
    [Space(10)]

    public float positionalReturnSpeed = 18f;
    public float rotationalReturnSpeed = 38f;
    [Space(10)]

    [Header("Amount Settings:")]
    public Vector3 RecoilRotation = new Vector3(10f, 5f, 7f);
    public Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);
    [Space(10)]

    public Vector3 RecoilRotationAim = new Vector3(10f, 4f, 6f);
    public Vector3 RecoilKickBackaim = new Vector3(0.015f, 0f, -0.2f);
    [Space(10)]

    Vector3 positionalRecoil;
    Vector3 rotationalRecoil;
    Vector3 Rot;

    [Header("State:")]
    public bool aiming;

    void FixedUpdate()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
        positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime);

        recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.fixedDeltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.fixedDeltaTime);
        rotationPoint.localRotation = Quaternion.Euler(Rot);
    }
    void Update()
    { 
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }
    }
    public void Fire()
    {
        if(aiming)
        {
            rotationalRecoil += new Vector3(-RecoilRotationAim.x, Random.Range(-RecoilRotationAim.y, RecoilRotationAim.y), Random.Range(-RecoilRotationAim.z, RecoilRotationAim.z));
            positionalRecoil += new Vector3(Random.Range(-RecoilKickBackaim.x, RecoilKickBackaim.x), Random.Range(-RecoilKickBackaim.y, RecoilKickBackaim.y), RecoilKickBackaim.z);
        }
        else
        {
            rotationalRecoil += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
            positionalRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z);
        }
    }

}
