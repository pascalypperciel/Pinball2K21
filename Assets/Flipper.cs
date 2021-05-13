using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Flipper : MonoBehaviour
{
    [SerializeField] float startPosition = 0;
    [SerializeField] float endPosition = 45;
    [SerializeField] float power = 10;
    [SerializeField] float damper = 1;

    HingeJoint joint;
    JointSpring spring;
    JointLimits limits;

    public enum Sides
    {
        GAUCHE,
        DROIT
    }
    public Sides side;

    public int direction;

    void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useSpring = true;
        spring = new JointSpring();
        spring.spring = power;
        spring.damper = damper;

        joint.useLimits = true;
        limits = new JointLimits();
        limits.min = startPosition;
        limits.max = endPosition * direction;
        joint.limits = limits;
    }

    void Update()
    {
        if(side == Sides.GAUCHE)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spring.targetPosition = endPosition * direction;
            }
            else
            {
                spring.targetPosition = startPosition;
            }
        }

        if (side == Sides.DROIT)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                spring.targetPosition = endPosition * direction;
            }
            else
            {
                spring.targetPosition = startPosition;
            }
        }

        joint.spring = spring;
    }
}
