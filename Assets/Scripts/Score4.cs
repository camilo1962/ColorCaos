using System.Collections.Generic;
using UnityEngine;

public class Score4 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed4;
    [SerializeField] private List<Vector3> _spawnPos4;

    [HideInInspector]
    public int ColorId4;

    [HideInInspector]
    public Score4 NextScore4;

    private void Awake()
    {
        hasGameFinished4 = false;
        transform.position = _spawnPos4[Random.Range(0,_spawnPos4.Count)];
        int colorCount4 = GameplayManager4.Instance.Colors4.Count;
        ColorId4 = Random.Range(0, colorCount4);
        GetComponent<SpriteRenderer>().color = GameplayManager4.Instance.Colors4[ColorId4];
    }

    private void FixedUpdate()
    {
        if (hasGameFinished4) return;
        transform.Translate(_moveSpeed4 * Time.fixedDeltaTime * Vector3.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            GameplayManager4.Instance.GameEnded4();
        }
    }

    private void OnEnable()
    {
        GameplayManager4.Instance.GameEnd4 += GameEnded4;
    }

    private void OnDisable()
    {
        GameplayManager4.Instance.GameEnd4 -= GameEnded4;
    }

    private bool hasGameFinished4;

    private void GameEnded4()
    {
        hasGameFinished4 = true;
    }
}
