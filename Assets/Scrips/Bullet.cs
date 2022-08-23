using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3;
    //public MainMenu mainMenu;
    private bool deneme=true;
    public ParticleSystem explosionEffect, bulletHoleGraphic;
    public Transform explosionPrefab;
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void start()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(bulletHoleGraphic, pos, rot);
        if(MainMenu.explosiveBulletBool) Instantiate(explosionEffect, pos, rot);
        Destroy(gameObject);
    }


}
