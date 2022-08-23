using System;
using UnityEngine;

public class movement : MonoBehaviour
{   
    public bool playerHasShotgun = true;
    [SerializeField] private Transform spawnTarget;
    [SerializeField] private GameObject collectable;
    public CharacterController control;
    public float speed = 10f;
    private Vector3 moveDirection; 

    float zAxis;
    float xAxis;
        
    void Update()
    {
        
        GetAxis();
        MovePlayer();
        
    }

    private void MovePlayer()
    {
        moveDirection = transform.right * xAxis + transform.forward * zAxis;
        control.Move(moveDirection* speed * Time.deltaTime);
    }

    private void GetAxis()
    {
        zAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "shotgun")
        {
            if(playerHasShotgun) Debug.Log("OLDU");
            else 
            {
                var newCollectable = Instantiate(collectable, spawnTarget);
                
            }
        }

    }
    

}
