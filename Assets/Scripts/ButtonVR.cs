using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
public class ButtonVR : MonoBehaviour
{
    public Transform visualTarget;

    private Vector3 offset;
    private Transform pokeAttackTransform;


    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            visualTarget.position = pokeAttackTransform.position + offset;
        }
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor) 
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            pokeAttackTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttackTransform.position;
        }
    }

}
