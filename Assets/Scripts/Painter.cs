using UnityEngine;

public class Painter : MonoBehaviour
{
    private LineRenderer line;
    private Color currentColor = Color.black;
    private bool isDrawing = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.Equals("melyna_spalva"))
                {
                    currentColor = Color.blue;
                    isDrawing = false;
                }
                else if (hit.collider.gameObject.name.Equals("zalia_spalva"))
                {
                    currentColor = Color.green;
                    isDrawing = false;
                }
                else if (hit.collider.gameObject.name.Equals("raudona_spalva"))
                {
                    currentColor = Color.red;
                    isDrawing = false;
                }
                else
                {
                    isDrawing = true;
                    CreateLine();
                }
            }
        }

        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }

    private void CreateLine()
    {
        GameObject newLineObject = new GameObject("LineRenderer");
        line = newLineObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = currentColor;
        line.endColor = currentColor;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
    }
}