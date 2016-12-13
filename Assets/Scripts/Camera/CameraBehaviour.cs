using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    private Camera _camera;
    private GameObject _player;

    private bool _orthoCamera;
    private float _fieldOfView = 47f;
    private float _orthoSize = 3.75f;

    private Vector3 _offset;
    private Vector3 _cameraOrthoPosition;
    private Vector3 _cameraPerspPosition;
    private Quaternion _cameraPerspRot;
    private Quaternion _cameraOrthoRot;

    void Start()
    {
        _orthoCamera = true;
        _camera = GetComponent<Camera>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _offset = transform.position - _player.transform.position;
        _cameraPerspPosition = new Vector3(0.40f, 2.45f, -1.35f);
        _cameraPerspRot = Quaternion.Euler(48.85f, 0f, 0f);
        _cameraOrthoPosition = new Vector3(3.5f, 5.0f, 3.5f);
        _cameraOrthoRot = Quaternion.Euler(90f, 0f, 0f);
        SetCameraOrtho();
    }

    void LateUpdate()
    {
        if (!_orthoCamera)
        {
            transform.position = _player.transform.position + _offset;
        }
    }

    public void OnCameraSwitch()
    {
        if (!EditModeManager.EditMode)
        {
            if (_orthoCamera)
            {
                SetCameraPersp();
            }
            else
            {
                SetCameraOrtho();
            }
            _orthoCamera = !_orthoCamera;
        }
    }

    private void SetCameraOrtho()
    {
        _camera.orthographic = true;
        _camera.orthographicSize = _orthoSize;
        _camera.transform.position = _cameraOrthoPosition;
        _camera.transform.rotation = _cameraOrthoRot;
    }

    private void SetCameraPersp()
    {
        _camera.orthographic = false;
        _camera.fieldOfView = _fieldOfView;
        _camera.transform.position = _cameraPerspPosition;
        _camera.transform.rotation = _cameraPerspRot;
    }
}
