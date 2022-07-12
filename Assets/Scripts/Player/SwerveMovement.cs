#region

using UnityEngine;

#endregion

namespace Player
{
    public class SwerveMovement : MonoBehaviour
    {
        public float swerveSpeed = 0.5f;
        public float swerveTurnSpeed = 0.1f;
        private SwerveInput swerveInput;

        private void Awake()
        {
            swerveInput = GetComponent<SwerveInput>();
        }

        private void Update()
        {
            var swerve = Time.deltaTime * swerveSpeed * swerveInput.MoveFactorX;
            swerve = Mathf.Clamp(swerve, -swerveTurnSpeed, swerveTurnSpeed);
            transform.Translate(swerve, 0, 0.3f * Time.deltaTime);
        }
    }
}