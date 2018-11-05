using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour {

    public float radius;

    public static Pen Instance;

    void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Make sure the input position stays inside the pen
    /// </summary>
    /// <param name="position">Target position</param>
    /// <returns>Closest position from the target position inside the pen</returns>
    public Vector3 ClampPositionToPen(Vector3 position)
    {
        Vector3 fromCenter = position - transform.position;
        if (fromCenter.magnitude > radius)
            fromCenter = Vector3.ClampMagnitude(fromCenter, radius);
        return transform.position + fromCenter;
    }

    /// <summary>
    /// The herding rule making sure sheeps stay inside the pen
    /// </summary>
    /// <param name="sheepPosition">Current position of the sheep</param>
    /// <returns>Enclosed vector</returns>
    public Vector3 RuleEnclosed(Vector3 sheepPosition)
    {
        Vector3 toCenterOfPen = transform.position - sheepPosition;
        float distanceToCenter = toCenterOfPen.magnitude;
        toCenterOfPen.Normalize();
        toCenterOfPen *= Inv(Mathf.Clamp01(1 - distanceToCenter / radius) * 100, 10);

        return toCenterOfPen;
    }

    float Inv(float x, float s)
    {
        //Avoid dividing by zero using espilon
        float value = x / s + Mathf.Epsilon;

        //Do not use the pow function since it can be quite expensive
        return 1 / (value * value);
    }
}
