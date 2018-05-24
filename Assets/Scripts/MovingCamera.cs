﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MovingCamera : MonoBehaviour
{

    public Transform playerTr;
    public Hand interactableHand = null;
    public Hand interactableHand2 = null;
    public Vector3 direction;
    public float speed = 1.0f;

    private bool isMoving = false;


    private void Start()
    {
        direction = direction.normalized;
    }

    private void HandHoverUpdate(Hand hand)
    {

        //print(hand.GetStandardInteractionButton());
        //Trigger got pressed
        if (interactableHand == null && hand.controller.GetHairTriggerDown())
        {
            hand.AttachObject(gameObject, Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachOthers | Hand.AttachmentFlags.DetachFromOtherHand);
            interactableHand = hand;

        }
    }

    void Update()
    {
        if ((interactableHand != null && interactableHand.controller != null && interactableHand.controller.GetHairTriggerDown() )|| Input.GetKey(KeyCode.Space))
        {
            isMoving = !isMoving;
            print("Is moving ? " + isMoving);
        }
        else if ((interactableHand2 != null && interactableHand2.controller != null && interactableHand2.controller.GetHairTriggerDown()) || Input.GetKey(KeyCode.Space))
        {
            isMoving = !isMoving;
            print("Is moving ? " + isMoving);
        }

        if (isMoving)
        {
            Vector3 newPosition = playerTr.transform.position;
            newPosition += direction * speed * Time.deltaTime;
            playerTr.transform.position = newPosition;
        }
    }

}