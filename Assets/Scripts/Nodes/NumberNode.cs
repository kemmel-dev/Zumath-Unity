﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Following;
using States.Node;
using Controllers;
using MathLists;
using References;
using Motors;
using Assets.Scripts;
using States.Game;

namespace Nodes
{
    [RequireComponent(typeof(PathFollower))]
    [RequireComponent(typeof(NodeMotor))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class NumberNode : MonoBehaviour
    {
        public PathFollower pathFollower;
        private CircleCollider2D circleCollider;
        public NodeMotor nodeMotor;
        private TextMeshPro textMeshPro;
        public NodeState state;

        public int value;
        public const float DIAMETER = 1f;
        public bool alive;

        void Awake()
        {
            Init();
        }

        public void Init()
        {
            alive = true;
            value = Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH);
            SetValue(value);
            pathFollower = GetComponent<PathFollower>();
            circleCollider = GetComponent<CircleCollider2D>();
            nodeMotor = GetComponent<NodeMotor>();
            textMeshPro = GetComponentInChildren<TextMeshPro>();
            this.gameObject.layer = LayerMask.NameToLayer(LayerNames.NODE_LAYER);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            NumberNode otherNode = collision.GetComponent<NumberNode>();

            if (otherNode != null)
            {
                if (otherNode.state == NodeState.PREVIEW || this.state == NodeState.PREVIEW)
                {
                    return;
                }
                if (NodeManager.Contains(otherNode))
                {
                    return;
                }
                otherNode.nodeMotor.enabled = false;
                NodeManager.InsertAtPlaceOf(NodeManager.GetNodes().Find(this), otherNode);
                GameStateManager.SwitchToDispersing();
            }
        }

        public void Kill()
        {
            alive = false;
        }

        public bool IsTouching(NumberNode otherNode)
        {
            if (otherNode != null)
            {
                if (circleCollider.IsTouching(otherNode.circleCollider))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetValue(int value)
        {
            this.value = value;
            if (textMeshPro != null)
            {
                textMeshPro.SetText(value.ToString());
            }
        }
        public void SetState(NodeState state)
        {
            this.state = state;
        }
    }
}

