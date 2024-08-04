using UnityEngine;
using UnityEngine.EventSystems;

public class HintController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public LineRenderer line;
    public RectTransform lampPoint;
    public RectTransform startPosition;
    public bool isLineClicked;
    public float speed;
    public AnimationCurve curve;

    private Vector2 intPosition;
    private float totalLenght;
    private float animTime;
    public void Start()
    {
        line.positionCount = 2;
        Vector2 SPosition = startPosition.position;
        Vector2 LPosition = lampPoint.position;
        line.SetPosition(0, SPosition);
        line.SetPosition(1, LPosition);
        Vector2 currentLocalPosition = this.transform.localPosition;
        intPosition = currentLocalPosition;
        totalLenght = Vector2.Distance(intPosition, Vector3.zero);
        animTime = 0f;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isLineClicked = true;
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = position;
        line.SetPosition(1, lampPoint.transform.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isLineClicked = false;
        intPosition = this.transform.localPosition;
        totalLenght = Vector2.Distance(intPosition, Vector2.zero);
        animTime = 0f;
    }

    Vector3 currentLapPosition = Vector3.zero;
    public void Update()
    {
        if (isLineClicked)
        {
            currentLapPosition = lampPoint.transform.position;
            currentLapPosition.z = 0;
            line.SetPosition(1, currentLapPosition);
        }
        else
        {
            animTime += Time.deltaTime * speed;
            float progress = Mathf.Clamp01(animTime / totalLenght);
            float curveValue = curve.Evaluate(progress);
            this.transform.localPosition = Vector2.LerpUnclamped(intPosition, Vector3.zero, curveValue);
            currentLapPosition = lampPoint.transform.position;
            currentLapPosition.z = 0;
            line.SetPosition(1, currentLapPosition);
            if (progress >= 1f)
            {
                isLineClicked = true;
            }
        }
    }
}