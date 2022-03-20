using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopter : MonoBehaviour
{
    public GameObject Flate1, Flate2;
    int MaxFlateSpeed;
    public float UpperSpeedOffset;
    public float rotSpeed;

    private Rigidbody rg;
    private Rigidbody rg_f1, rg_f2;

    void Start()
    {
        MaxFlateSpeed = 10;
        UpperSpeedOffset = .5f;
        rotSpeed = 100;

        rg = this.GetComponent<Rigidbody>();
        rg_f1 = Flate1.GetComponent<Rigidbody>();
        rg_f1.maxAngularVelocity = 15f;
        rg_f2 = Flate2.GetComponent<Rigidbody>();
        rg_f2.maxAngularVelocity = 15f;

    }

    void Update()
    {
        if(Input.GetKey("space"))
        {
            Fly_Physics();
            Fly_Effects();
        }

        if(Input.GetKey(KeyCode.V))
        {
            Fly_Physics(false);
            Fly_Effects(false);
        }
    }


    void Fly_Physics(bool bUp = true)
    {
        if (bUp)
        {
            if(rg_f1.angularVelocity.y > 10)
            {
                rg.AddForce(this.transform.up * UpperSpeedOffset);
            }        
        }

        else
        {
            ;
        }
        
    }

    void Fly_Effects(bool bUp = true)
    {
        Debug.Log(rg_f1.angularVelocity);
        float Offset = bUp ? 1 : -1;
        if (bUp)
        {
            rg_f1.AddTorque(new Vector3( 0,rotSpeed * Time.deltaTime * Offset, 0));
            rg_f2.AddTorque(new Vector3( 0,rotSpeed * Time.deltaTime * Offset, 0));
        }

        else
        {
            rg_f1.AddTorque(new Vector3( 0,rotSpeed * Time.deltaTime * Offset, 0));
            rg_f2.AddTorque(new Vector3( 0,rotSpeed * Time.deltaTime * Offset, 0));
        }
        
    }

}
