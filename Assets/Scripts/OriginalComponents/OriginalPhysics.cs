using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OriginalPhysics
{
    #region Fields
    private static float _gravity = 9.80665f;
    private static Vector3 _scaleGravity = new Vector3(0, -_gravity, 0);
    private static bool _usePhysics = true;
    #endregion

    #region Properties
    public static float Gravity { get => _gravity; set => _gravity = value; }
    public static Vector3 ScaleGravity { get => _scaleGravity; set => _scaleGravity = value; }
    public static bool UsePhysics { get => _usePhysics; set => _usePhysics = value; }
    #endregion
}
