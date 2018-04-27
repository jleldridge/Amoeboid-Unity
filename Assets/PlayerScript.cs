using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private static float _maxSpeed = 10.0f;
    private static float _speedAdjust = 10.0f;
    private static float _decayRate = 1.0f;

    float _dx = 0f;
    float _dy = 0f;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        float _deltaSpeedAdjust = _speedAdjust * Time.deltaTime;
        float _deltaDecayRate = _decayRate * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            _dy = Mathf.Abs(_dy + _deltaSpeedAdjust) > _maxSpeed ? _maxSpeed : _dy + _deltaSpeedAdjust;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _dy = Mathf.Abs(_dy - _deltaSpeedAdjust) > _maxSpeed ? -1 * _maxSpeed : _dy - _deltaSpeedAdjust;
        }
        else if (_dy > 0)
        {
            _dy = Mathf.Max(_dy - _deltaDecayRate, 0);
        }
        else if (_dy < 0)
        {
            _dy = Mathf.Min(_dy + _deltaDecayRate, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _dx = Mathf.Abs(_dx + _deltaSpeedAdjust) > _maxSpeed ? _maxSpeed : _dx + _deltaSpeedAdjust;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _dx = Mathf.Abs(_dx - _deltaSpeedAdjust) > _maxSpeed ? -1 * _maxSpeed : _dx - _deltaSpeedAdjust;
        }
        else if (_dx > 0)
        {
            _dx = Mathf.Max(_dx - _deltaDecayRate, 0);
        }
        else if (_dx < 0)
        {
            _dx = Mathf.Min(_dx + _deltaDecayRate, 0);
        }

        var position = this.transform.position;
        position.x += _dx * Time.deltaTime;
        position.y += _dy * Time.deltaTime;
        this.transform.position = position;
    }
}
