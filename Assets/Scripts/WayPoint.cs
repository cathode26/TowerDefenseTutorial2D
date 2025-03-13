using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (points != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position + points[i], 0.5f);

                if (i < points.Length - 1)
                {
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(transform.position + points[i], transform.position + points[i + 1]);
                }
            }
        }
    }
}
