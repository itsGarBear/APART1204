﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Kinematic
{
    Seek myMoveType;
    LookWhereGoing mySeekRotateType;
    LookWhereGoing myFleeRotateType;

    public bool flee = false;

    public float closeEnoughRange;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindObjectOfType<PlayerController>().transform.GetChild(0).gameObject;

        myMoveType = new Seek();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.closeEnoughRange = closeEnoughRange;
        myMoveType.flee = flee;

        mySeekRotateType = new LookWhereGoing();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        base.Update();
    }
}