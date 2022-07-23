using UnityEngine;
using shark;

[RequireComponent(typeof(Collider2D))]
public class dragmanager : MonoBehaviour
{
    public bool draggable = true;
    bool dragging = false;
    Vector3 hitDiff;

    // Update is called once per frame
    void Update()
    {
        if (!dragging || !draggable) return;
        transform.position = cman.getPoint() + hitDiff;
    }

    private void OnMouseDown()
    {
        hitDiff = transform.position - cman.getPoint();
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
