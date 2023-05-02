using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player.Egg.BaseScript>())
        {
            collision.GetComponent<Player.Egg.BaseScript>().WaterFalled();;

        }
    }
}
