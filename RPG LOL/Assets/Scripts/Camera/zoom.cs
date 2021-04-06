using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private float _x_Axis;
    private float _y_Axis;
    public GameManager GM;

    public Camera cam;

    void Update()
    {
        if (GM.isPaused == false)
        {
            if (Input.mouseScrollDelta.y < 0 && cam.orthographicSize < 10)
            {
                cam.orthographicSize += 30 * Time.deltaTime;
            }

            if (Input.mouseScrollDelta.y > 0 && cam.orthographicSize > 2)
            {
                cam.orthographicSize -= 30 * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                cam.orthographicSize = 5;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GM.isPaused == false)
        {
            _x_Axis = Input.GetAxisRaw("Horizontal");
            _y_Axis = Input.GetAxisRaw("Vertical");

            if (_x_Axis != 0)
            {
                transform.position = new Vector3((transform.position.x + (_x_Axis * _speed * Time.deltaTime)), transform.position.y, -10f);
            }

            if (_y_Axis != 0)
            {
                transform.position = new Vector3(transform.position.x, (transform.position.y + (_y_Axis * _speed * Time.deltaTime)), -10f);
            }
        }
    }
}
