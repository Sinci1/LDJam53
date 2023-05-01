using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Egg
    {
        public class FlyerColliderDetector : MonoBehaviour
        {
            [Header("Player Collider Settings")]
            public Vector2 size;

            [Header("Checks")]
            [SerializeField] private bool centerCheck;
            [SerializeField] private bool upRightCheck;
            [SerializeField] private bool upLeftCheck;
            [SerializeField] private bool downRightCheck;
            [SerializeField] private bool downLeftCheck;

            public bool fullCheck;
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

                Vector2 pos = transform.position;
                centerCheck = (Physics2D.OverlapAreaAll(pos + (size / 2), pos - (size / 2), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                upRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                upLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                downRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                downLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);

                fullCheck = centerCheck || upRightCheck || upLeftCheck || downRightCheck || downLeftCheck;
            }

            bool Check(out Vector3 teleportPosition) {
                teleportPosition = Vector3.zero;
                Vector2 pos = transform.position;

                //we preform the checks to see if there are colliders nearby
                centerCheck = (Physics2D.OverlapAreaAll(pos + (size / 2), pos - (size / 2), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                upRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                upLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                downRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);
                downLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player")).Length <= 0);

                
                if (upRightCheck && upLeftCheck) { teleportPosition = new Vector2(pos.x, pos.y + size.y); }
                if (downLeftCheck && downRightCheck) { teleportPosition = new Vector2(pos.x, pos.y - size.y); }

                if (centerCheck) { teleportPosition = pos; }


                return (centerCheck || upRightCheck || upLeftCheck || downRightCheck || downLeftCheck);
            }
        }
    }
}