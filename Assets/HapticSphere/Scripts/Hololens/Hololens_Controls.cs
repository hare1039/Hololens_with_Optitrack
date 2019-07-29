using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Hololens_Controls : MonoBehaviour {

    public GameObject hand;

    [SerializeField]
    private Vector3 handOffset;

    // Use this for initialization
    void OnEnable()
    {
        InteractionManager.InteractionSourceDetected += InteractionManager_SourceDetected;
        InteractionManager.InteractionSourceUpdated += InteractionManager_SourceUpdated;
        InteractionManager.InteractionSourceLost += InteractionManager_SourceLost;
        InteractionManager.InteractionSourcePressed += InteractionManager_SourcePressed;
        InteractionManager.InteractionSourceReleased += InteractionManager_SourceReleased;
    }

    void OnDestroy()
    {
        InteractionManager.InteractionSourceDetected -= InteractionManager_SourceDetected;
        InteractionManager.InteractionSourceUpdated -= InteractionManager_SourceUpdated;
        InteractionManager.InteractionSourceLost -= InteractionManager_SourceLost;
        InteractionManager.InteractionSourcePressed -= InteractionManager_SourcePressed;
        InteractionManager.InteractionSourceReleased -= InteractionManager_SourceReleased;
    }

    void InteractionManager_SourcePressed(InteractionSourcePressedEventArgs args)
    {
        Debug.Log("Source pressed");
    }
    void InteractionManager_SourceDetected(InteractionSourceDetectedEventArgs args)
    {
        Debug.Log("Source detected");
    }
    void InteractionManager_SourceUpdated(InteractionSourceUpdatedEventArgs args)
    {
        Vector3 p;

        args.state.sourcePose.TryGetPosition(out p);
        // string acc = args.state.sourcePose.positionAccuracy.ToString();

        //Debug.Log("Hand " + args.state.source.handedness.ToString());

        /* if (args.state.source.handedness.ToString() == "Left")
            leftHand.transform.position = p;
        else if (args.state.source.handedness.ToString() == "Right")
            rightHand.transform.position = p;*/
        
        hand.transform.position = p+handOffset;
        Debug.Log("Source updated " + p);
    }
    void InteractionManager_SourceLost(InteractionSourceLostEventArgs args)
    {
        Debug.Log("Source lost");
    }
    void InteractionManager_SourceReleased(InteractionSourceReleasedEventArgs args)
    {
        Debug.Log("Source released");
    }
}


