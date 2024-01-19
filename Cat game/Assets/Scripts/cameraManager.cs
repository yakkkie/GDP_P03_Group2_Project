using Cinemachine;
using UnityEngine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class LockCameraY : CinemachineExtension
{
    [Tooltip("Lock the camera's Y rotation to this value")]
    public float m_YRotation = 0;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var ori = state.RawOrientation;
            ori.y = m_YRotation;
            state.RawOrientation = ori;
        }
    }
}