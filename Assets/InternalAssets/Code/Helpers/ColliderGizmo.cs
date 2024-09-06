#if UNITY_EDITOR
using UnityEngine;

public class ColliderGizmo : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public Color color;
    private void OnDrawGizmos()
    {

        if (circleCollider == null) return;
        color.a = 1;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y) + circleCollider.offset, circleCollider.radius);
    }
}
#endif
