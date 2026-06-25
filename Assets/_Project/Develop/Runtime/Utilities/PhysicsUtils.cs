using UnityEngine;

namespace _Project.Develop.Runtime.Utilities
{
    public static class PhysicsUtils
    {
        public static int OverlapCollider(Collider col, Collider[] results, LayerMask mask)
        {
            const QueryTriggerInteraction ignore = QueryTriggerInteraction.Ignore;
            var t = col.transform;

            switch (col)
            {
                case SphereCollider s:
                    return Physics.OverlapSphereNonAlloc(
                        t.TransformPoint(s.center),
                        s.radius * MaxScale(t.lossyScale),
                        results, mask, ignore);

                case BoxCollider b:
                    return Physics.OverlapBoxNonAlloc(
                        t.TransformPoint(b.center),
                        Vector3.Scale(b.size * 0.5f, AbsVec(t.lossyScale)),
                        results, t.rotation, mask, ignore);

                case CapsuleCollider c:
                    GetCapsulePoints(c, out var p0, out var p1, out var r);
                    return Physics.OverlapCapsuleNonAlloc(p0, p1, r, results, mask, ignore);

                default:
                    return Physics.OverlapBoxNonAlloc(
                        col.bounds.center, col.bounds.extents,
                        results, Quaternion.identity, mask, ignore);
            }
        }

        public static void GetCapsulePoints(CapsuleCollider c, out Vector3 p0, out Vector3 p1, out float r)
        {
            var s = c.transform.lossyScale;
            int d = c.direction;
            r = c.radius * Mathf.Max(Mathf.Abs(s[(d + 1) % 3]), Mathf.Abs(s[(d + 2) % 3]));
            float offset = Mathf.Max(0f, c.height * 0.5f * Mathf.Abs(s[d]) - r);
            var center = c.transform.TransformPoint(c.center);
            var axis = d switch { 0 => c.transform.right, 2 => c.transform.forward, _ => c.transform.up };
            p0 = center - axis * offset;
            p1 = center + axis * offset;
        }

        public static float MaxScale(Vector3 s) => Mathf.Max(Mathf.Abs(s.x), Mathf.Abs(s.y), Mathf.Abs(s.z));
        public static Vector3 AbsVec(Vector3 s) => new(Mathf.Abs(s.x), Mathf.Abs(s.y), Mathf.Abs(s.z));
    }
}
