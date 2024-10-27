using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] float shootForce, upwardForce;

    [SerializeField] float timeBetweenShooting, reloadTime, spread;
    [SerializeField] int magazineSize;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    [SerializeField] Camera fpsCam;
    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject gun;

    [SerializeField] bool allowInvoke = true;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {

        shooting = Input.GetMouseButtonDown(0);
        
        if(Input.GetKeyDown(KeyCode.R)) Reload();

        if(shooting && bulletsLeft <= 0 && !reloading) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        readyToShoot = false;


        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;


        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;
        ammoText.text = bulletsLeft + "/" + magazineSize;
        readyToShoot = true;

    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        LeanTween.rotateAroundLocal(gun, Vector3.right, 360f, reloadTime);
    }
    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
