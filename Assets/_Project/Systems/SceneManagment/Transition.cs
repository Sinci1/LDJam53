using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transition : MonoBehaviour
{

    [Header("Circle Transition")]
    public Transform circle;
    public Transform circleTransition;
    public event Action finishedTransition;

    public float circleSpeed;
    public circleTransitionTypes circleType;
    public enum circleTransitionTypes { LargeToSmall, SmallToLarge };
    private bool completedTransition;
    private float circleDelta;
    private float maxCircleSize = 25f;
    // Start is called before the first frame update
    void Start()
    {
        InitiateCircleTransition(circleType);
    }

    // Update is called once per frame
    void Update()
    {
        if (!completedTransition)
        {
            if (circleType == circleTransitionTypes.LargeToSmall) { circleDelta -= circleSpeed * Time.deltaTime; }
            if (circleType == circleTransitionTypes.SmallToLarge) { circleDelta += circleSpeed * Time.deltaTime; }

            circleDelta = Mathf.Clamp(circleDelta, 0f, 1f);
            circle.transform.localScale = new Vector3(circleDelta * maxCircleSize, circleDelta * maxCircleSize, 1f);

            if (circleType == circleTransitionTypes.SmallToLarge & circleDelta == 1f || circleType == circleTransitionTypes.LargeToSmall & circleDelta == 0f){
                if (circleType == circleTransitionTypes.SmallToLarge) { circleTransition.gameObject.SetActive(false); }
                completedTransition = true;
                finishedTransition?.Invoke();
            }
        }
    }

    public void InitiateCircleTransition(circleTransitionTypes circle) {
        circleType = circle;
        if (circle == circleTransitionTypes.LargeToSmall) { circleDelta = 1f; }
        if (circle == circleTransitionTypes.SmallToLarge) { circleDelta = 0f; }
        completedTransition = false;
        circleTransition.gameObject.SetActive(true);
        
    }
}
