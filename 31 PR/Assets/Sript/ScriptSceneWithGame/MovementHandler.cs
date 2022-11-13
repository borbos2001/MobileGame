using System;
using System.Collections;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameObject[] _pointCheck;
    [SerializeField] private GameObject _playerPosition;
    [SerializeField] private GameObject _particle;
    [SerializeField] private float _speed;
    private Vector3 _goTo;
    private bool _canMove = true;
    void Start()
    {
        _goTo = _playerPosition.transform.position;
    }
    void Update()
    {
        ChackCanMove();
        Move();
    }
    private void Move()
    {
        if (_goTo != _playerPosition.transform.position)
        {
            _particle.SetActive(true);
            _playerPosition.transform.position = Vector3.MoveTowards(_playerPosition.transform.position, _goTo, Time.deltaTime * _speed);
        }
        else
        {
            _particle.SetActive(false);
        }
    }
    public void ChackCanMove()
    {
        if (_inputManager.IsThereTouchOnScreen())
        {
            if (_canMove)
            {
                Vector2 currDeltaPos = _inputManager.GetTouchDeltaPosition();
                if (currDeltaPos.x > 60 && Math.Abs(currDeltaPos.y) < 60)
                {
                    Debug.Log("движение впрво");
                    StartCoroutine(TimeDelay());
                    _pointCheck[2].SetActive(true);
                }
                if (currDeltaPos.x < -60 && Math.Abs(currDeltaPos.y) < 60)
                {
                    Debug.Log("движение ввлево");
                    StartCoroutine(TimeDelay());
                    _pointCheck[1].SetActive(true);

                }
                if (currDeltaPos.y > 60 && Math.Abs(currDeltaPos.x) < 60)
                {
                    Debug.Log("движение вверх");
                    StartCoroutine(TimeDelay());
                    _pointCheck[0].SetActive(true);
                }
                if (currDeltaPos.y < -60 && Math.Abs(currDeltaPos.x) < 60)
                {
                    Debug.Log("движение ввниз");
                    StartCoroutine(TimeDelay());
                    _pointCheck[3].SetActive(true);
                }
            }
        }
    }
    public void SelectionOfPoint(int _num)
    {
        switch (_num)
        {
            case 0:
                _pointCheck[0].SetActive(false);
                _goTo =  new Vector3(_pointCheck[0].transform.position.x, _playerPosition.transform.position.y, _pointCheck[0].transform.position.z) ;
                break;
            case 1:
                _pointCheck[1].SetActive(false);
                _goTo = new Vector3(_pointCheck[1].transform.position.x, _playerPosition.transform.position.y, _pointCheck[1].transform.position.z);
                break;
            case 2:
                _pointCheck[2].SetActive(false);
                _goTo = new Vector3(_pointCheck[2].transform.position.x, _playerPosition.transform.position.y, _pointCheck[2].transform.position.z);
                break;
            case 3:
                _pointCheck[3].SetActive(false);
                _goTo = new Vector3(_pointCheck[3].transform.position.x, _playerPosition.transform.position.y, _pointCheck[3].transform.position.z);
                break;
        }
    }
    private IEnumerator TimeDelay()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.3f);
        _canMove = true;
    }
}
