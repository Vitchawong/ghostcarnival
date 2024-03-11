using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lantern : MonoBehaviour
{
    public Transform interactorTransform;
    float lastFrameAngle;
    public float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable interactble = GetComponent<XRGrabInteractable>();
        interactble.selectEntered.AddListener(Selected);
        interactble.selectExited.AddListener(Deselected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (interactorTransform != null)
        {
            float angle = Vector3.SignedAngle(interactorTransform.position - transform.position, interactorTransform.forward, Vector3.up);
            float delta = angle - lastFrameAngle;
            transform.Rotate(transform.up, delta * multiplier);
            lastFrameAngle = angle;
        }
    }

    public void Selected(SelectEnterEventArgs arguments)
    {
        interactorTransform = arguments.interactorObject.transform;
        lastFrameAngle = Vector3.SignedAngle(interactorTransform.position - transform.position, interactorTransform.forward, Vector3.up);
    }

    public void Deselected(SelectExitEventArgs arguments)
    {
        interactorTransform = null;
    }
}
