using UnityEngine;

public class ParabolaButton : MonoBehaviour
{
    public AnimationCurve curve;
    public Vector3 end;

    Vector3 start;
    float time;

    void Start()
    {
        start = transform.position;
    }
    void Update()
    {
        time += Time.deltaTime;
        Vector3 pos = Vector3.Lerp(start, end, time);
        pos.y += curve.Evaluate(time);
        transform.position = pos;
    }
}
