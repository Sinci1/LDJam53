using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPlatform : MonoBehaviour
{
    [Header("General")]
    public Vector3 defaultPos;
    public Vector3 movedPos;
    public Door door;

    [Header("Settings")]
    public float speedOfFall;
    public float currentDelta;
    private bool isColliderPresent;
    private Transform egg;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliderPresent) { currentDelta += speedOfFall * Time.deltaTime; }
        if (!isColliderPresent) { currentDelta -= speedOfFall * Time.deltaTime; }

        currentDelta = Mathf.Clamp(currentDelta, 0f, 1f);
        if (door != null) { door.doorDelta = currentDelta; }

        Vector3 neededToMove = movedPos - defaultPos;
        transform.position = defaultPos + (neededToMove * currentDelta);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player.Egg.BaseScript>()){isColliderPresent = true; egg = collision.transform; CancelInvoke("StopMoving"); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player.Egg.BaseScript>()){ Invoke("StopMoving", 0.3f); }
    }

    void StopMoving() {
        isColliderPresent = false; egg = null;
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player.Egg.BaseScript>())
        {
            isColliderPresent = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player.Egg.BaseScript>())
        {
            isColliderPresent = false;
        }
    }*/
}
