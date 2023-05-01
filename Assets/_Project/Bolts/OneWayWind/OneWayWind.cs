using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayWind : MonoBehaviour
{
    public Vector2 windVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<GeneralInfo>() && other.GetComponent<GeneralInfo>().CanWindPush){
            other.GetComponent<Rigidbody2D>().velocity += windVelocity;
        }
        if (other.GetComponent<Player.Flyer.Movement>()){
            other.GetComponent<Player.Flyer.Movement>().pushVelocity = windVelocity * 7f;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<GeneralInfo>() && other.GetComponent<GeneralInfo>().CanWindPush)
        {
            other.GetComponent<Rigidbody2D>().velocity += windVelocity * 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player.Flyer.Movement>()){
            other.GetComponent<Player.Flyer.Movement>().pushVelocity = Vector2.zero;
        }
    }


}
