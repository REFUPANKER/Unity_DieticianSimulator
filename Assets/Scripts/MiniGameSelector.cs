using TMPro;
using UnityEngine;

public class MiniGameSelector : MonoBehaviour
{
    private float defaultSpeed = 0;
    public float speed = 20f;
    public float itemGap = 5f;
    private RectTransform[] items;
    public bool CanSpin = false;
    public GameObject ReStarterButton;
    public RectTransform Bar;
    public GameObject SelectedObject;
    void Start()
    {
        defaultSpeed = speed;
        items = new RectTransform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            items[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
    }

    public void Shuffle()
    {
        Vector2[] positions = new Vector2[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            positions[i] = items[i].anchoredPosition;
        }

        for (int i = 0; i < items.Length; i++)
        {
            int j = Random.Range(i, items.Length);
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i].anchoredPosition = positions[i];
        }
    }

    public void ReStartSpin()
    {
        Shuffle();
        speed = defaultSpeed;
        CanSpin = true;
        ReStarterButton.SetActive(false);
    }

    void Update()
    {
        if (CanSpin)
        {
            foreach (var item in items)
            {
                item.anchoredPosition += Vector2.left * speed;
                if (Bar.rect.width / 2 > item.anchoredPosition.x  && Bar.rect.width / 2 < item.anchoredPosition.x + item.rect.width)
                {
                    SelectedObject = item.gameObject;
                }
                if (item.anchoredPosition.x + item.rect.width < 0)
                {

                    RectTransform rightmostItem = items[0];
                    for (int i = 1; i < items.Length; i++)
                    {
                        if (items[i].anchoredPosition.x > rightmostItem.anchoredPosition.x)
                        {
                            rightmostItem = items[i];
                        }
                    }

                    item.anchoredPosition = new Vector2(rightmostItem.anchoredPosition.x + rightmostItem.rect.width + itemGap, item.anchoredPosition.y);

                    speed -= 1;
                }
            }
            if (speed <= 1)
            {
                CanSpin = false;
                ReStarterButton.SetActive(true);
                if (SelectedObject != null)
                {
                    TextMeshProUGUI txt = SelectedObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    Debug.Log(txt.text);
                }
            }
        }
    }
}
