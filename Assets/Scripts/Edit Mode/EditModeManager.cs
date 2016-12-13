using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditModeManager : MonoBehaviour
{
    private List<GameObject> _walls;
    public static bool EditMode;

    void Start()
    {
        _walls = new List<GameObject>();
        PlaceMarkers();
    }

    private void PlaceMarkers()
    {
        PlaceMarkerRows();
        PlaceMarkerCols();
    }

    private void PlaceMarkerRows()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int z = 0; z < 7; z++)
            {
                GameObject marker = Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
                float x_pos = x + 1.0f;
                float z_pos = z + 0.5f;
                marker.transform.position = new Vector3(x_pos, 0.25f, z_pos);
                marker.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                _walls.Add(marker);
            }
        }
    }

    private void PlaceMarkerCols()
    {
        for (int z = 0; z < 6; z++)
        {
            for (int x = 0; x < 7; x++)
            {
                GameObject marker = Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
                float x_pos = x + 0.5f;
                float z_pos = z + 1.0f;
                marker.transform.position = new Vector3(x_pos, 0.25f, z_pos);
                marker.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                _walls.Add(marker);
            }
        }
    }
}
