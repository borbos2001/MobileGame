
using UnityEngine;

public class CanMove : MonoBehaviour
{
    [SerializeField] private int _num;
    [SerializeField] private MovementHandler _movementHandler;
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Plane")
        {
            _movementHandler.SelectionOfPoint(_num);
        }

        if (other.tag != "Plane")
        {
            Debug.Log("fafsa");
            _gameObject.SetActive(false);
        }
    }
}
