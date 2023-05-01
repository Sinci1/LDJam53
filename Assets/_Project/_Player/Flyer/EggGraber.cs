using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Flyer
    {
        public class EggGraber : MonoBehaviour
        {
            [Header("To Assign")]
            public Egg.BaseScript trueEgg;
            public Transform dummyEgg;

            [Header("General")]
            public bool isSomethingInGrabbingRangeBelow;
            public bool isEggInGrabbingRangeBelow;

            public bool grabbedEgg;
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, (Vector2.one), 0f, Vector2.down, 0.5f, ~LayerMask.GetMask("Player", "IgnoreGrab"));

                isSomethingInGrabbingRangeBelow = (hit.collider != null);
                isEggInGrabbingRangeBelow = (isSomethingInGrabbingRangeBelow && hit.transform.gameObject.GetComponent<Egg.BaseScript>());

                if (Input.GetKeyDown(KeyCode.Space) && isEggInGrabbingRangeBelow){
                    dummyEgg.gameObject.SetActive(true);
                    trueEgg.gameObject.SetActive(false);
                    grabbedEgg = true;
                }

                if (Input.GetKeyUp(KeyCode.Space) && grabbedEgg) {
                    dummyEgg.gameObject.SetActive(false);
                    trueEgg.gameObject.SetActive(true);

                    trueEgg.transform.position = dummyEgg.transform.position;
                    trueEgg.transform.localEulerAngles = Vector3.zero;
                        
                    grabbedEgg = false;
                }
            }
        }
    }
}