using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    internal IEnumerator Fading(GameObject plane)
    {
        Color color;
        color.a = 0.1f;
        float factor = 1f;
        color = plane.GetComponent<Renderer>().material.color;
        while (true)
        {
            color.a += (Time.deltaTime * factor);
            plane.GetComponent<Renderer>().material.color = color;
            yield return new WaitForEndOfFrame();
            if (color.a <= 0)
            {
                factor = 1f;
            }
            if (color.a >= 1)
            {
                factor = -1f;
            }
        }

    }
    internal IEnumerator Scaling(GameObject plane)
    {
        Vector3 scale = plane.transform.localScale;
        Vector3 maxScaleAllowed = scale;
        float factor = 1f;
        while (true)
        {
            scale = new Vector3(scale.x += Time.deltaTime * factor * 0.2f, scale.y, scale.z += Time.deltaTime * factor * 0.2f);
            plane.transform.localScale = scale;
            yield return new WaitForEndOfFrame();
            if (scale.x <= maxScaleAllowed.x / 2)
            {
                factor = 1f;
            }
            if (scale.x >= maxScaleAllowed.x)
            {
                factor = -1f;
            }
        }
    }
    internal IEnumerator Rotating(GameObject plane)
    {
        Vector3 angle = plane.transform.localEulerAngles;
        Vector3 maxRotationAllowed = angle;
        float factor = 1f;
        while (true)
        {
            angle = new Vector3(0f, angle.y += Time.deltaTime * factor * 0.2f, angle.z);
            plane.transform.Rotate(angle);
            yield return new WaitForEndOfFrame();
            if (angle.y <= maxRotationAllowed.y - 0.2)
            {
                factor = 1f;
            }
            if (angle.y >= maxRotationAllowed.y + 0.2)
            {
                factor = -1f;
            }
        }
    }
}
