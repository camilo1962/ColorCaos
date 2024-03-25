using UnityEngine;

public class Player4 : MonoBehaviour
{
    public int ColorId4;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = GameplayManager4.Instance.Colors4[ColorId4];
    }
}
