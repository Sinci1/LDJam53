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
            public Vector2 size = new Vector2(3f, 1f);
            public Vector3 eggSize = new Vector3(0.25f, 0.4f, 0.25f); //Vector3 because it's not symmetrical on the Y axis, so X = normal, Y = distance from center to up, Z = distance from center to down

            [Header("Checks")]
            [SerializeField] private bool centerCheck;
            [SerializeField] private bool upCheck;
            [SerializeField] private bool downCheck;
            [SerializeField] private bool rightCheck;
            [SerializeField] private bool leftCheck;
            [SerializeField] private bool upRightCheck;
            [SerializeField] private bool upLeftCheck;
            [SerializeField] private bool downRightCheck;
            [SerializeField] private bool downLeftCheck;

            public bool Check(out Vector2 teleportPosition) {
                teleportPosition = Vector2.zero;
                Vector2 pos = transform.position;
                Vector2 dividedSize = size / 2;

                //we preform the checks to see if there are colliders nearby
                centerCheck = (Physics2D.OverlapAreaAll(pos + dividedSize, pos - dividedSize, ~LayerMask.GetMask("Egg", "Player")).Length <= 0);

                upCheck = (Physics2D.OverlapAreaAll(new Vector2(pos.x - dividedSize.x, pos.y), new Vector2(pos.x + dividedSize.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                downCheck = (Physics2D.OverlapAreaAll(new Vector2(pos.x - dividedSize.x, pos.y), new Vector2(pos.x + dividedSize.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                rightCheck = (Physics2D.OverlapAreaAll(new Vector2(pos.x, pos.y - dividedSize.y), new Vector2(pos.x + size.x, pos.y + dividedSize.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                leftCheck = (Physics2D.OverlapAreaAll(new Vector2(pos.x, pos.y - dividedSize.y), new Vector2(pos.x - size.x, pos.y + dividedSize.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);

                upRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                upLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y + size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                downRightCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x + size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);
                downLeftCheck = (Physics2D.OverlapAreaAll(pos, new Vector2(pos.x - size.x, pos.y - size.y), ~LayerMask.GetMask("Egg", "Player", "IgnoreGrabIgnoreCheck", "UnignoreGrabIgnoreCheck")).Length <= 0);

                //positions
                if (upRightCheck) { teleportPosition = new Vector2(pos.x + dividedSize.x - eggSize.x, pos.y + dividedSize.y - eggSize.z); }
                if (upLeftCheck) { teleportPosition = new Vector2(pos.x - dividedSize.x + eggSize.x, pos.y + dividedSize.y - eggSize.z); }
                if (downRightCheck) { teleportPosition = new Vector2(pos.x + dividedSize.x, pos.y - dividedSize.y); }
                if (downLeftCheck) { teleportPosition = new Vector2(pos.x - dividedSize.x, pos.y - dividedSize.y); }

                if (upCheck) { teleportPosition = new Vector2(pos.x, pos.y + dividedSize.y - eggSize.z); }
                if (downCheck) { teleportPosition = new Vector2(pos.x, pos.y - dividedSize.y); }
                if (rightCheck) { teleportPosition = new Vector2(pos.x + dividedSize.x - eggSize.x, pos.y); }
                if (leftCheck) { teleportPosition = new Vector2(pos.x - dividedSize.x + eggSize.x, pos.y); }

                if (centerCheck) { teleportPosition = pos; }

                //the end
                return (centerCheck || upCheck || downCheck || rightCheck || leftCheck || upRightCheck || upLeftCheck || downRightCheck || downLeftCheck);
            }
            private void OnDrawGizmos()
            {
                if (UnityEditor.EditorApplication.isPlaying)
                {
                    Vector3 pos = transform.position;
                    Vector3 dividedSize = size / 2;

                    Gizmos.color = Color.red;
                    if (upRightCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x + dividedSize.x, pos.y + dividedSize.y), size); Gizmos.color = Color.red;
                    if (upLeftCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x - dividedSize.x, pos.y + dividedSize.y), size); Gizmos.color = Color.red;
                    if (downRightCheck) { Gizmos.color = Color.green; }  Gizmos.DrawWireCube(new Vector2(pos.x + dividedSize.x, pos.y - dividedSize.y), size); Gizmos.color = Color.red;
                    if (downLeftCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x - dividedSize.x, pos.y - dividedSize.y), size); Gizmos.color = Color.red;

                    if (upCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x, pos.y + dividedSize.y), size); Gizmos.color = Color.red;
                    if (downCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x, pos.y - dividedSize.y), size); Gizmos.color = Color.red;
                    if (rightCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x + dividedSize.x, pos.y), size); Gizmos.color = Color.red;
                    if (leftCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(new Vector2(pos.x - dividedSize.x, pos.y), size); Gizmos.color = Color.red;

                    if (centerCheck) { Gizmos.color = Color.green; } Gizmos.DrawWireCube(pos, size); Gizmos.color = Color.red;

                }
            }
        }
    }
}