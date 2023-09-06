using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    [SerializeField] private List<GameObject> traits = new List<GameObject>();

    [SerializeField] private int targetTrace;

    public delegate void TracerDelegate();
    public static event TracerDelegate OnDoneTracing;

    private void Start()
    {
        targetTrace = gameObject.transform.childCount;
    }

    private void CheckTarget()
    {
        if (traits.Count == targetTrace)
        {
            OnDoneTracing?.Invoke();
            return;
        }
    }

    public void OnTouchPlayer(GameObject target)
    {
        traits.Add(target);
        target.SetActive(false);

        CheckTarget();
    }
}
