using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToDie : MonoBehaviour
{
    [SerializeField] float _maxTime;
    [SerializeField] GameObject _deathText;
    [SerializeField] GameObject _interface;
    private Image _img;
    private float _curremtTime;

    void Start()
    {
        _img = GetComponent<Image>();
        _curremtTime = _maxTime;
    }

    void Update()
    {
        _curremtTime -= Time.deltaTime;
        if (_curremtTime <= 0)
        {
            _interface.SetActive(false);
            _deathText.SetActive(true);
            Time.timeScale = 0f;
        }
        _img.fillAmount = _curremtTime/_maxTime;
    }
    public void PlusTime()
    {
        _curremtTime = _maxTime;
    }
}
