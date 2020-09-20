using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 50f;
    private float nextTimetoFire = 0f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject stoneImpact;
    public GameObject sandImpact;
    public GameObject woodImpact;
    public GameObject metalImpact;
    public GameObject fleshImpact;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire && gameObject.tag == "Automatic")
        {
            nextTimetoFire = Time.time + 1 / fireRate;
            Shoot();
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire && gameObject.tag == "SemiAutomatic")
        {
            nextTimetoFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    public void Shoot()
    {
        FindObjectOfType<AdvancedGunRecoil>().Fire();
        FindObjectOfType<AdvancedCameraRecoil>().Fire();
        muzzleFlash.Play();
        if (gameObject.name == "AK47" || gameObject.name == "AK47ALT")
        {
            FindObjectOfType<AudioManager>().Play("AK47");
        }
        if(gameObject.name == "M4")
        {
            FindObjectOfType<AudioManager>().Play("M4");
        }
        if(gameObject.name == "L96")
        {
            FindObjectOfType<AudioManager>().Play("L96");
        }
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            BarrelExplosives explode = hit.transform.GetComponent<BarrelExplosives>();

            if(target != null)
            {
                target.Takedamage(damage);
            }
            if(explode != null)
            {
                explode.Takedamage(damage); 
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.collider.tag == "Stone")
            {
                GameObject impactGo = Instantiate(stoneImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 5f);
            }
            if(hit.collider.tag == "Ground")
            {
                GameObject impactGO = Instantiate(sandImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 5f);
            }
            if(hit.collider.tag == "Wood")
            {
                GameObject impactGO = Instantiate(woodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 5f);
            }
            if (hit.collider.tag == "Metal")
            {
                GameObject impactGO = Instantiate(metalImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 5f);
            }
            if(hit.collider.tag == "Flesh")
            {
                GameObject impactGO = Instantiate(fleshImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 5f);
            }
            
        }
         
    }
}
