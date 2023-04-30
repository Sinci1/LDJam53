using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Flyer
    {
        public class Movement : MonoBehaviour
        {
            [Header("To Assign")]
            public GameObject birdModel;

            [Header("Internal Settings")]
            public float speed = 5f;

            // Start is called before the first frame update
            void Start()
            {
                
            }

            // Update is called once per frame
            void Update()
            {
                Vector2 moveDelta = Vector3.zero;

                if (Input.GetKey(KeyCode.W)) { moveDelta += Vector2.up; }
                if (Input.GetKey(KeyCode.A)) { moveDelta -= Vector2.right; }
                if (Input.GetKey(KeyCode.S)) { moveDelta -= Vector2.up; }
                if (Input.GetKey(KeyCode.D)) { moveDelta += Vector2.right; }

                if (Mathf.Abs(moveDelta.x) + Mathf.Abs(moveDelta.y) > 1) {moveDelta = new Vector2(Mathf.Sign(moveDelta.x) * Mathf.Sqrt(Mathf.Abs(moveDelta.x) / 2f), Mathf.Sign(moveDelta.y) * Mathf.Sqrt(Mathf.Abs(moveDelta.y) / 2f)); }

                if (moveDelta.x > 0) { birdModel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f); }
                if (moveDelta.x < 0) { birdModel.transform.localScale = new Vector3(0.3f, 0.3f, -0.3f); }

                transform.position += new Vector3(moveDelta.x, moveDelta.y) * speed * Time.deltaTime;

                Debug.Log(transform.forward);

            }
        }
    }
}