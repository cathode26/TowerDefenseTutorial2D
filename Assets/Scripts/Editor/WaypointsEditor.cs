using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoints))]
public class WaypointsEditor : Editor
{
    Waypoints Waypoints => target as Waypoints;
    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        for (int i = 0; i < Waypoints.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            Vector3 currentWaypointPosition = Waypoints.CurrentPosition + Waypoints.Points[i];
            Vector3 newWayPointPosition = Handles.FreeMoveHandle(currentWaypointPosition, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);
        
            //Create text
            GUIStyle textstyle = new GUIStyle();
            textstyle.fontStyle = FontStyle.Bold;
            textstyle.fontSize = 18;
            textstyle.normal.textColor = Color.yellow;
            Vector3 textAlignment = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(Waypoints.CurrentPosition + Waypoints.Points[i] + textAlignment, $"{i+1}", textstyle);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Waypoints.Points[i] = newWayPointPosition - Waypoints.CurrentPosition;
            }
        }
    }
}
