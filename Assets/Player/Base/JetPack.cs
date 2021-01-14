using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JetPack : MonoBehaviour
{

    CharacterController charaController;
    public Vector3 currentVector = Vector3.up;

    public float CurrentForce = 0;
    public float MaxForce = 5;

    [SerializeField]
    public float flySpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !charaController.isGrounded && MaxForce > 0)
        {
            MaxForce -= Time.deltaTime;

            if (CurrentForce < 1)
            {
                CurrentForce += Time.deltaTime;
            }
            else
            {
                CurrentForce = 1;
            }
        }
        if (MaxForce < 0 && CurrentForce > 0)
        {
            CurrentForce -= Time.deltaTime;
        }
        if (!Input.GetButtonDown("Jump"))
        {
            if (CurrentForce > 0)
            {
                CurrentForce -= Time.deltaTime;
            }
            else { CurrentForce = 0; }
            if (MaxForce < 5)
            {
                MaxForce += Time.deltaTime;
            }
            else { MaxForce = 5; }
        }

        if (CurrentForce > 0)
        {
            UseJetPack();
        }
    }

    public void UseJetPack()
    {

        currentVector = Vector3.up;
        currentVector += transform.right * Input.GetAxis("Horizontal");
        currentVector += transform.forward * Input.GetAxis("Vertical");

        charaController.Move((currentVector * flySpeed * Time.fixedDeltaTime - charaController.velocity * Time.fixedDeltaTime)* CurrentForce);
    }
}
