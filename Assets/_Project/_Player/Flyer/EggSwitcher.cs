using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Flyer
    {
        public class EggSwitcher : MonoBehaviour
        {
            [Header("General")]
            private Egg.BaseScript egg;
            private EggGraber grab;
            // Start is called before the first frame update
            void Start()
            {
                egg = GameObject.FindObjectOfType<Egg.BaseScript>();
                grab = gameObject.GetComponent<EggGraber>();
            }

            // Update is called once per frame
            void Update()
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, (Vector2.one), 0f, Vector2.down, 0.5f, ~LayerMask.GetMask("Player", "IgnoreGrabIgnoreCheck", "IgnoreGrabUni0gnoreCheck"));
                Vector2 teleportPos = egg.transform.position;
                bool isPlatformBelow = (hit.collider != null && hit.transform.GetComponent<PlatformGeneralInfo>());
                bool isPlatformNestable = (isPlatformBelow && hit.transform.GetComponent<PlatformGeneralInfo>().CanBeNestedOn);
                bool isEggCheck = egg.GetComponent<Egg.FlyerColliderDetector>().Check(out teleportPos);

                if (Input.GetKeyDown(KeyCode.F) && isPlatformNestable && isEggCheck && egg.canTeleport) {
                    Vector3 playerPos = transform.position;
                    Vector3 eggPos = egg.transform.position;

                    egg.transform.position = playerPos;
                    egg.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    transform.position = teleportPos;
                }

            }
            
        }


    }
}
