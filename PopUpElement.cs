using UnityEngine;

public class PopUpElement : MonoBehaviour
{
    public float riseHeight = 2f;
    public float animationSpeed = 2f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        endPosition = startPosition + new Vector3(0, riseHeight, 0);
    }

    public void TriggerPopUp()
    {
        StartCoroutine(RiseUp());
    }

    System.Collections.IEnumerator RiseUp()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * animationSpeed;
            yield return null;
        }
        transform.localPosition = endPosition;
    }
}
