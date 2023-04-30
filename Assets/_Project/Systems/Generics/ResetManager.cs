using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    [Header("To Assign")]
    public Transition tr;
    public Player.Egg.BaseScript egg;
    private bool resetBegun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BeginReset();
        }
        if (egg.transform.position.y < -10f)
        {
            BeginReset();
        }
    }


    void BeginReset() {
        if (resetBegun) { return; }

        tr.InitiateCircleTransition(Transition.circleTransitionTypes.LargeToSmall);
        tr.finishedTransition += ActuallyReset;
        resetBegun = true;
    }

    void ActuallyReset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
