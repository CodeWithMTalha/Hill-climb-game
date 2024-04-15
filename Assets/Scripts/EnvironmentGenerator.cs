using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;

    [Range(3f, 500f)] public int levelLength = 300;
    [Range(1f, 50f)] public float xMultiplier = 2f;
    [Range(1f, 50f)] public float yMultiplier = 2f;
    [Range(0f, 1f)] public float curveSmoothness = 0.5f;

    public float noiseStep = 0.5f;
    public float bottom = 10f;

    private Vector3 lastPos;

    private void OnValidate()
    {
        spriteShapeController.spline.Clear();

        for(int i = 0; i < levelLength; i++)
        {
            lastPos = transform.position + new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
            spriteShapeController.spline.InsertPointAt(i, lastPos);

            if (i != 0 && i != levelLength - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
        }

        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength+1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
