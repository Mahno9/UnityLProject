#if UNITY_EDITOR
using UnityEngine;

namespace _Project.Develop.Runtime.Utilities
{
    public static class DebugDrawUtils
    {
        public static void DrawWireCollider(Collider col, Color color, float duration = 0f)
        {
            var t = col.transform;
            switch (col)
            {
                case SphereCollider s:
                    DrawWireSphere(t.TransformPoint(s.center), s.radius * PhysicsUtils.MaxScale(t.lossyScale), color, duration);
                    break;
                case BoxCollider b:
                    DrawWireBox(t.TransformPoint(b.center), Vector3.Scale(b.size * 0.5f, PhysicsUtils.AbsVec(t.lossyScale)), t.rotation, color, duration);
                    break;
                case CapsuleCollider c:
                    PhysicsUtils.GetCapsulePoints(c, out var p0, out var p1, out var r);
                    DrawWireCapsule(p0, p1, r, color, duration);
                    break;
            }
        }

        public static void DrawWireSphere(Vector3 center, float r, Color color, float duration = 0f)
        {
            DrawCircle(center, Vector3.right, Vector3.up, r, 16, color, duration);
            DrawCircle(center, Vector3.right, Vector3.forward, r, 16, color, duration);
            DrawCircle(center, Vector3.up, Vector3.forward, r, 16, color, duration);
        }

        public static void DrawWireBox(Vector3 c, Vector3 h, Quaternion q, Color color, float duration = 0f)
        {
            var x = q * Vector3.right * h.x;
            var y = q * Vector3.up * h.y;
            var z = q * Vector3.forward * h.z;
            Debug.DrawLine(c - x - y - z, c + x - y - z, color, duration);
            Debug.DrawLine(c - x - y + z, c + x - y + z, color, duration);
            Debug.DrawLine(c - x - y - z, c - x - y + z, color, duration);
            Debug.DrawLine(c + x - y - z, c + x - y + z, color, duration);
            Debug.DrawLine(c - x + y - z, c + x + y - z, color, duration);
            Debug.DrawLine(c - x + y + z, c + x + y + z, color, duration);
            Debug.DrawLine(c - x + y - z, c - x + y + z, color, duration);
            Debug.DrawLine(c + x + y - z, c + x + y + z, color, duration);
            Debug.DrawLine(c - x - y - z, c - x + y - z, color, duration);
            Debug.DrawLine(c + x - y - z, c + x + y - z, color, duration);
            Debug.DrawLine(c - x - y + z, c - x + y + z, color, duration);
            Debug.DrawLine(c + x - y + z, c + x + y + z, color, duration);
        }

        public static void DrawWireCapsule(Vector3 p0, Vector3 p1, float r, Color color, float duration = 0f)
        {
            var up = p1 - p0;
            if (up.sqrMagnitude < 0.0001f) return;
            up.Normalize();

            var perp1 = Vector3.Cross(up, Vector3.right);
            if (perp1.sqrMagnitude < 0.001f)
                perp1 = Vector3.Cross(up, Vector3.forward);
            perp1.Normalize();
            var perp2 = Vector3.Cross(up, perp1).normalized;

            const int seg = 16;
            DrawCircle(p0, perp1, perp2, r, seg, color, duration);
            DrawCircle(p1, perp1, perp2, r, seg, color, duration);
            Debug.DrawLine(p0 + perp1 * r, p1 + perp1 * r, color, duration);
            Debug.DrawLine(p0 - perp1 * r, p1 - perp1 * r, color, duration);
            Debug.DrawLine(p0 + perp2 * r, p1 + perp2 * r, color, duration);
            Debug.DrawLine(p0 - perp2 * r, p1 - perp2 * r, color, duration);
            DrawHemisphereArc(p0, -up, perp1, perp2, r, seg, color, duration);
            DrawHemisphereArc(p1, up, perp1, perp2, r, seg, color, duration);
        }

        public static void DrawCircle(Vector3 center, Vector3 axisA, Vector3 axisB, float r, int seg, Color color, float duration = 0f)
        {
            float step = 2f * Mathf.PI / seg;
            var prev = center + axisA * r;
            for (int i = 1; i <= seg; i++)
            {
                float a = i * step;
                var next = center + (axisA * Mathf.Cos(a) + axisB * Mathf.Sin(a)) * r;
                Debug.DrawLine(prev, next, color, duration);
                prev = next;
            }
        }

        public static void DrawHemisphereArc(Vector3 center, Vector3 pole, Vector3 axisA, Vector3 axisB, float r, int seg, Color color, float duration = 0f)
        {
            float step = Mathf.PI / seg;
            var prev = center + axisA * r;
            for (int i = 1; i <= seg; i++)
            {
                float a = i * step;
                var next = center + (axisA * Mathf.Cos(a) + pole * Mathf.Sin(a)) * r;
                Debug.DrawLine(prev, next, color, duration);
                prev = next;
            }
            prev = center + axisB * r;
            for (int i = 1; i <= seg; i++)
            {
                float a = i * step;
                var next = center + (axisB * Mathf.Cos(a) + pole * Mathf.Sin(a)) * r;
                Debug.DrawLine(prev, next, color, duration);
                prev = next;
            }
        }
    }
}
#endif
