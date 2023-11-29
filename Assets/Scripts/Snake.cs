using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(TailGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;
    
    private List<Segment> _tail;
    private TailGenerator _tailGenerator;

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _tail = _tailGenerator.Generate();
    }

    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * _speed * Time.fixedDeltaTime);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _snakeHead.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPosition,
                _tailSpringiness * Time.deltaTime);
            previousPosition = tempPosition;
        }
        
        _snakeHead.Move(nextPosition);
    }
}
