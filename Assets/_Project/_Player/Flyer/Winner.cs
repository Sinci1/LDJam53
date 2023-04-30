using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    namespace Flyer
    {
        public class Winner : MonoBehaviour
        {
            [Header("To Assign")]
            public int currentLevel;
            private EggGraber eggGrab;
            private Transition tr;

            public bool beginWinAnimation;
            public bool theEndOfLevel;
            private void Awake()
            {
                eggGrab = gameObject.GetComponent<EggGraber>();
                tr = GameObject.FindObjectOfType<Transition>();
            }

            // Update is called once per frame
            void Update()
            {
                if (beginWinAnimation)
                {
                    transform.position += Vector3.right * 3f * Time.deltaTime;
                    if (transform.position.x > 13.25f && !theEndOfLevel)
                    {
                        tr.InitiateCircleTransition(Transition.circleTransitionTypes.LargeToSmall);
                        tr.finishedTransition += ConcludeLevel;
                        theEndOfLevel = true;
                    }
                }
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.gameObject.tag == "Winning" && eggGrab.grabbedEgg)
                {
                    gameObject.GetComponent<Movement>().enabled = false;
                    gameObject.GetComponent<EggGraber>().enabled = false;
                    gameObject.GetComponent<EggSwitcher>().enabled = false;
                    gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    beginWinAnimation = true;
                }
            }

            void ConcludeLevel() {
                SceneManager.LoadScene("Level" + (currentLevel+1));
            }
        }
    }
}