using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Egg
    {
        public class BaseScript : MonoBehaviour
        {
            public bool canTeleport = true;
            public MeshRenderer dummyEggRenderer;

            public Material fireMat;
            public Material cooledMat;

            public void WaterFalled() {
                canTeleport = false;
                gameObject.GetComponentInChildren<MeshRenderer>().material = cooledMat;
                dummyEggRenderer.material = cooledMat;
            }
        }
    }
}