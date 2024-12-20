using UnityEngine;

public class BookController : MonoBehaviour
{
    public Transform[] pages;
    public PopUpElement[] popUpElements; 
    public float openSpeed = 2f;

    private int currentPage = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            OpenNextPage();
        }
    }

    void OpenNextPage()
    {
        currentPage++;
        if (currentPage < pages.Length)
        {
            StartCoroutine(OpenPage(pages[currentPage]));

            foreach (PopUpElement element in popUpElements)
            {
                element.TriggerPopUp();
            }
        }
    }

    System.Collections.IEnumerator OpenPage(Transform page)
    {
        float angle = 0;
        while (angle < 90)
        {
            angle += Time.deltaTime * openSpeed * 90;
            page.localRotation = Quaternion.Euler(-angle, 0, 0);
            yield return null;
        }
        page.localRotation = Quaternion.Euler(-90, 0, 0);
    }
}
