using UnityEngine;
using TMPro;
// using Unity.VisualScripting;
// using Unity.Collections.LowLevel.Unsafe;
public class GameUI : MonoBehaviour
{
    [Header("UI要素")]
    [SerializeField]
    private TextMeshProUGUI itemCountText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI timerText;

    void Start()
    {
        // テキストが設定されていない場合は自動で検索
        if (itemCountText == null)
        {
            itemCountText = GameObject.Find("ItemCountText")?.GetComponent<TextMeshProUGUI>();
        }

        UpdateUI();
    }

    void Update()
    {
        UpdateUI();




        if (GameManager.Instance == null) return;

        // アイテム表示（既存）
        if (itemCountText != null)
        {
            itemCountText.text = "ITEMS: " +
                GameManager.Instance.GetItemCount() + " / " +
                GameManager.Instance.GetRequiredItemCount();
        }

        // スコア表示
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " +
                GameManager.Instance.GetScore();
        }

        // タイマー表示
        if (timerText != null)
        {
            // 残り時間を整数に切り上げて表示
            int timeInt = Mathf.CeilToInt(
                GameManager.Instance.GetRemainingTime());
            timerText.text = "TIME: " + timeInt;

            // 残り10秒以下は赤くする
            if (timeInt <= 10)
            {
                timerText.color = Color.red;
            }
            else
            {
                timerText.color = Color.white;
            }
        }
    }

    // <summary>
    // UIを更新する
    // </summary>
    private void UpdateUI()
    {
        if (itemCountText != null && GameManager.Instance != null)
        {
            int current = GameManager.Instance.GetItemCount();
            int required = GameManager.Instance.GetRequiredItemCount();
            itemCountText.text = "ITEMS:" + current + " / " + required;
        }
    }
}
