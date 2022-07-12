#region

using UnityEngine;
using UnityEngine.Serialization;

#endregion

namespace PaintScripts
{
    public class DrawingSystem : MonoBehaviour
    {
        [FormerlySerializedAs("Brush")] public GameObject brush;
        [FormerlySerializedAs("BrushSize")] public float brushSize = 0.1f;
        [FormerlySerializedAs("RTexture")] public RenderTexture rTexture;
        public Camera paintingCamera;

        // Use this for initialization
        private void Start()
        {
            brush.transform.localScale = new Vector3(brushSize, brushSize, brushSize);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
            RaycastHit hit;
            var ray = paintingCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) return;
            var brush = Instantiate(this.brush, hit.point, Quaternion.identity);
            brush.transform.localScale = new Vector3(brushSize, brushSize, brushSize);
            brush.transform.parent = transform;
            this.brush.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }
}