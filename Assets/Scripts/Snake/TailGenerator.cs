using UnityEngine;
using System.Collections.Generic;


public class TailGenerator : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplate;
    
    public List<Segment> Generate(int count)
    {
        List<Segment> tail = new List<Segment>();

        for (int i = 0; i < count; i++)
        {
            tail.Add(Instantiate(_segmentTemplate, transform));
        }

        return tail;
    }
}
