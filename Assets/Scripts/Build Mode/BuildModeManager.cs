using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildModeManager : MonoBehaviour
{
    private static List<GameObject> _walls;
    private static List<GameObject> _checks;
    private static GameObject _wallContainer;
    private static GameObject _checkContainer;

    public static bool BuildMode;


    void Awake()
    {
        _walls = new List<GameObject>();
        _checks = new List<GameObject>();
        _wallContainer = GameObject.FindGameObjectWithTag("WallContainer");
        _checkContainer = GameObject.FindGameObjectWithTag("CheckpointContainer");
        PlaceMarkers();
        PlaceCheckpoints();
    }

    public static void ToggleBuildMode()
    {
        BuildMode = !BuildMode;
        foreach (GameObject wall in _walls)
        {
            Marker mrk = wall.GetComponent<Marker>();
            if (!mrk.Active)
            {
                mrk.ToggleMeshRenderer(BuildMode);
                mrk.ToggleColor(false);
            }
        }

        foreach (GameObject check in _checks)
        {
            Marker mrk = check.GetComponent<EndLevel>();
            if (!mrk.Active)
            {
                mrk.ToggleMeshRenderer(BuildMode);
                mrk.ToggleColor(false);
            }
        }
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
                marker.transform.parent = _wallContainer.transform;
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
                marker.transform.parent = _wallContainer.transform;
                _walls.Add(marker);
            }
        }
    }

    private void PlaceCheckpoints()
    {
        for (int z = 0; z < 7; z++)
        {
            for (int x = 0; x < 7; x++)
            {
                if (z == 0 && x == 0)
                {
                    continue;
                }

                GameObject check = Instantiate(Resources.Load("EndCheckpoint", typeof(GameObject))) as GameObject;
                float x_pos = x + 0.5f;
                float z_pos = z + 0.5f;
                check.transform.position = new Vector3(x_pos, 0.25f, z_pos);
                check.transform.parent = _checkContainer.transform;
                _checks.Add(check);
            }
        }
    }
}
