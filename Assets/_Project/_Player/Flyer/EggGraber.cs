using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Flyer
    {
        public class EggGraber : MonoBehaviour
        {

            [Header("General")]
            public bool isSomethingInGrabbingRangeBelow;
            public bool isEggInGrabbingRangeBelow;

            public bool grabbedEgg;
            private Egg.BaseScript egg;
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, (Vector2.one), 0f, Vector2.down, 0.5f, ~LayerMask.GetMask("Player"));

                isSomethingInGrabbingRangeBelow = (hit.collider != null);
                isEggInGrabbingRangeBelow = (isSomethingInGrabbingRangeBelow && hit.transform.gameObject.GetComponent<Egg.BaseScript>());

                if (Input.GetKeyDown(KeyCode.Space) && isEggInGrabbingRangeBelow){
                    grabbedEgg = true;
                    egg = hit.transform.gameObject.GetComponent<Egg.BaseScript>();
                    egg.GetComponent<Rigidbody2D>().isKinematic = true;
                    egg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }

                if (grabbedEgg) {
                    egg.transform.position = transform.position + Vector3.down;
                }

                if (Input.GetKeyUp(KeyCode.Space) && grabbedEgg) {
                    grabbedEgg = false;
                    egg.GetComponent<Rigidbody2D>().isKinematic = false;
                    egg = null;
                }
            }
        }
    }
}