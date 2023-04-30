using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Flyer
    {
        public class MovementAnimationManager : MonoBehaviour
        {
            [Header("To Assign")]
            private Movement movement;
            private Animator anim;
            private static readonly int FlyingStillToFlyingMoveTransitionAnimation = Animator.StringToHash("BT_FS-FM");
            private static readonly int FlyingMovingToFlyingStillTransitionAnimation = Animator.StringToHash("BT_FM-FS");

            [Header("General")]
            public MoveAnimState currentState;
            public enum MoveAnimState {FlyingStill, FsToFmTransitioning, FlyingMoving, FmToFsTransitioning }
            private float secondsUntilPlayAnimation = 0.2f;
            private float fmWingIntensity;
            private float fmWingIntensitySpeed = 1.5f;

            private void Awake()
            {
                movement = gameObject.GetComponentInParent<Movement>();
                anim = gameObject.GetComponent<Animator>();

            }

            // Update is called once per frame
            void Update()
            {
                UP_ChangingFlyingAnimations();
                UP_WalkingAnimations();
            }

            void UP_ChangingFlyingAnimations() {
                //if the animation is Still, but the player is Moving, then begin the animation. However wait a bit, and if the player stops moving then don't call the animation
                if (currentState == MoveAnimState.FlyingStill && movement.shouldMovingAnimBeOn)
                {
                    Invoke("Initiate_FStoFM", secondsUntilPlayAnimation);
                }
                if (currentState == MoveAnimState.FlyingStill && !movement.shouldMovingAnimBeOn) { CancelInvoke("Initiate_FStoFM"); }

                //this is to control the wing intensinty
                if (currentState == MoveAnimState.FlyingMoving)
                {
                    if (!movement.isPlayerGoingDown) { fmWingIntensity += fmWingIntensitySpeed * Time.deltaTime; }
                    if (movement.isPlayerGoingDown) { fmWingIntensity -= fmWingIntensitySpeed * Time.deltaTime; }
                    fmWingIntensity = Mathf.Clamp(fmWingIntensity, 0f, 1f);
                    anim.SetFloat("FMWingIntensity", fmWingIntensity);
                }

                //same as above
                if (currentState == MoveAnimState.FlyingMoving && !movement.shouldMovingAnimBeOn)
                {
                    Invoke("Initiate_FMtoFS", secondsUntilPlayAnimation);
                }
                if (currentState == MoveAnimState.FlyingMoving && movement.shouldMovingAnimBeOn) { CancelInvoke("Initiate_FMtoFS"); }
            }

            void UP_WalkingAnimations() {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, (Vector2.one), 0f, Vector2.down, 0.5f, ~LayerMask.GetMask("Player", "Egg"));
                bool GroundBelow = (hit.collider != null);
                
            }




           //Actual Animations Set & Get

           //Flying (Still) to Flying (Moving)
            public void Initiate_FStoFM(){
                anim.CrossFade(FlyingStillToFlyingMoveTransitionAnimation, 0.25f);
                currentState = MoveAnimState.FsToFmTransitioning;
            }
            public void FStoFM_Finished() {
                currentState = MoveAnimState.FlyingMoving;
            }

           //Flying (Moving) to Flying (Still)
            public void Initiate_FMtoFS(){
                anim.CrossFade(FlyingMovingToFlyingStillTransitionAnimation, 0.25f);
                currentState = MoveAnimState.FmToFsTransitioning;
            }
            public void FMtoFS_Finished() {
                currentState = MoveAnimState.FlyingStill;
            }

        }
    }
}
