#region

using UnityEngine;

#endregion

namespace Player
{
    public class SwerveInput : MonoBehaviour
    {
        public float speed;
        public float rotationSpeed;
        private Animator animator;
        private float lastHorizontal;
        private float lastVertical;
        
        public float MoveFactorX { get; private set; }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animator.Play("Idle");
        }

        private void Update()
        {
#if UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            {
                lastHorizontal = Input.mousePosition.x;
                lastVertical = Input.mousePosition.y;
            }
            else if (Input.GetMouseButton(0))
            {
                animator.Play("Run");
                var horizontalInput = Input.mousePosition.x - lastHorizontal;
                var verticalInput = Input.mousePosition.y - lastVertical;

                var movement = new Vector3(horizontalInput, 0, verticalInput);
                movement.Normalize();
                transform.Translate(movement * (speed * Time.deltaTime), Space.World);

                if (movement != Vector3.zero)
                {
                    var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                        rotationSpeed * Time.deltaTime);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                animator.Play("Idle");
            }
#endif
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                lastHorizontal = Input.mousePosition.x;
                lastVertical = Input.mousePosition.y;
            }
            else if (Input.GetMouseButton(0))
            {
                animator.Play("Run");
                var horizontalInput = Input.mousePosition.x - lastHorizontal;
                var verticalInput = Input.mousePosition.y - lastVertical;

                var movement = new Vector3(horizontalInput, 0, verticalInput);
                movement.Normalize();
                transform.Translate(movement * (speed * Time.deltaTime), Space.World);

                if (movement != Vector3.zero)
                {
                    var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                        rotationSpeed * Time.deltaTime);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                animator.Play("Idle");
            }
#endif
#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    lastHorizontal = Input.GetTouch(0).position.x;
                    lastVertical = Input.GetTouch(0).position.y;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    animator.Play("Run");
                    var horizontalInput = Input.GetTouch(0).position.x - lastHorizontal;
                    var verticalInput = Input.GetTouch(0).position.y - lastVertical;

                    var movement = new Vector3(horizontalInput, 0, verticalInput);
                    movement.Normalize();
                    transform.Translate(movement * (speed * Time.deltaTime), Space.World);

                    if (movement != Vector3.zero)
                    {
                        var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                            rotationSpeed * Time.deltaTime);
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    animator.Play("Idle");
                }
            }
#endif
            
        }
    }
}