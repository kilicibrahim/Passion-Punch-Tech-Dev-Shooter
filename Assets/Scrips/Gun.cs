using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random; // because I use System I needed to choose which random I will use
public class Gun : MonoBehaviour
{
    private enum State {
    Shoot,
    Reload,
    NotEnoughBullets,
    } 
    public int N, howManyBullets;
    int Nbullets;
    public float spread, timeToReload;
    float x;
    float y;
    private int howManyBulletsLeft;
    float bulletsShot = 0;
    public TMP_Text scoreText;
    public TMP_Text bulletsLeftText;
    public TMP_Text reloadText;
    public Transform bulletSpawnPoint;
    public GameObject bulletPf;
    public GameObject bulletPfRed;
    public ParticleSystem muzzleFlash, bulletHoleGraphic, explosionEffect;
    GameObject gunFire;
    public float bulletSpeed = 10;
    public float shootForce;
    bool shooting = false;
    public bool reloading = false;
    
    public float destruckDelay = 0.6f;
 
    void Start()
    {
        howManyBulletsLeft = howManyBullets;
        gunFire = GameObject.Find("GunFire");
        reloadText.text = "";
    }
    void Update()
    {
        RandomXandY();

        if(howManyBulletsLeft == 0 && !reloading) reloadText.text = "Please Reload";
        if (Input.GetKeyDown(KeyCode.R) && howManyBulletsLeft < howManyBullets && !reloading){
            reloadText.text = "Reloading";
            Reload();
        } 
        
        if (!reloading && howManyBulletsLeft > 0) Shoot();
        bulletsLeftText.text = howManyBulletsLeft + " / " + howManyBullets;
    }

    private void RandomXandY()
    {
        x = Random.Range(-spread, spread);
        y = Random.Range(-spread, spread);
    }

    void Reload()
    {
        reloading = true;
        
        Invoke("AfterReload", timeToReload);
        
    }
    void AfterReload()
    {
        howManyBulletsLeft = howManyBullets;
        reloading = false;
        reloadText.text = "";
    }
    void Shoot()
    {
        

        // we are only getting the down movement, not allowing button hold
        // because we are only getting keydown, I did't set a time between two shots but it can be done
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            for(Nbullets = N; Nbullets > 0; Nbullets--)
        {

            muzzleFlash.Play();
            Shooting();
        }
            

        }
    }

    private void Shooting()
    {
        shooting = true;
        bulletsShot += 1;
        howManyBulletsLeft --;
        scoreText.text = "Bullets Shot: " + bulletsShot;
        if (!MainMenu.explosiveBulletBool) BulletCreate();
        else ExplosiveBulletCreate();
    }

    private void ExplosiveBulletCreate()
    {
        if (!MainMenu.redBulletBool)
        {
            ExplosiveNormalBulletCreate();
        }
        else
        {
            ExplosiveRedBulletCreate();
        }
        
    }
    private void BulletCreate()
    {
        if (!MainMenu.redBulletBool)
        {
            NormalBulletCreate();
        }
        else
        {
            RedBulletCreate();
        }
    }

    private void RedBulletCreate()
    {
        var bullet = Instantiate(bulletPfRed, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        if (MainMenu.bigBulletBool) bullet.transform.localScale = transform.localScale * 1f;
    }

    private void NormalBulletCreate()
    {
        Vector3 direction = bulletSpawnPoint.forward + new Vector3(x,y,0);
        var bullet = Instantiate(bulletPf, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity =direction * bulletSpeed;
        if (MainMenu.bigBulletBool) bullet.transform.localScale = transform.localScale * 1f;
    }
        private void ExplosiveRedBulletCreate()
    {
        var bullet = Instantiate(bulletPfRed, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        if (MainMenu.bigBulletBool) bullet.transform.localScale = transform.localScale * 1f;
        Destroy(bullet, destruckDelay);
        ExplodeBullet(bullet);
    }

    private void ExplosiveNormalBulletCreate()
    {
        var bullet = Instantiate(bulletPf, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        if (MainMenu.bigBulletBool) bullet.transform.localScale = transform.localScale * 1f;
        ExplodeBullet(bullet);
        Destroy(bullet, destruckDelay);       
    }

    private void ExplodeBullet(GameObject bullet)
    {
        new WaitForSeconds(1);
        Instantiate(explosionEffect, bullet.transform);
    }
}


