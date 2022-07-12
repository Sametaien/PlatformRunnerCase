#region

using UnityEngine;

#endregion

namespace PaintScripts
{
    public class Paintable : MonoBehaviour
    {
        public GameObject brush;
        public float brushSize = 0.1f;
        public bool isPaintable;
        public Camera paintCamera;
        public Camera mainCamera;

        private void Awake()
        {
            mainCamera.enabled = true;
            paintCamera.enabled = false;
        }


        private void Update()
        {
            if (isPaintable)
                mainCamera.enabled = false;
            paintCamera.enabled = true;
            if (Input.GetMouseButton(0))
            {
                var Ray = paintCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(Ray, out hit))
                    if (hit.collider.gameObject.tag == "Paintable")
                    {
                        var brushInstance = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity,
                            transform);
                        brushInstance.transform.localScale = new Vector3(brushSize, brushSize, brushSize);
                        brushInstance.transform.LookAt(paintCamera.transform);
                        brushInstance.transform.Rotate(0, 180, 0);
                        brushInstance.transform.parent = hit.collider.gameObject.transform;
                    }
            }
        }
    }
}