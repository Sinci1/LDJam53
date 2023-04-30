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

            private void Awake()
            {
                movement = gameObject.GetComponentInParent<Movement>();
                anim = gameObject.GetComponent<Animator>();

            }

            // Update is called once per frame
            void Update()
            {
                if (currentState == MoveAnimState.FlyingStill && movement.isMovingOnXAxis) {
                    Initiate_FStoFM();
                    currentState = MoveAnimState.FsToFmTransitioning;
                }

                if (currentState == MoveAnimState.FlyingMoving && !movement.isMovingOnXAxis){
                    Initiate_FMtoFS();
                    currentState = MoveAnimState.FmToFsTransitioning;
                }
            }




           //Actual Animations Set & Get

           //Flying (Still) to Flying (Moving)
            public void Initiate_FStoFM(){
                anim.CrossFade(FlyingStillToFlyingMoveTransitionAnimation, 0f);
            }
            public void FStoFM_Finished() {
                currentState = MoveAnimState.FlyingMoving;
            }

           //Flying (Moving) to Flying (Still)
            public void Initiate_FMtoFS(){
                anim.CrossFade(FlyingMovingToFlyingStillTransitionAnimation, 0f);
            }
            public void FMtoFS_Finished() {
                currentState = MoveAnimState.FlyingStill;
            }

        }
    }
}
