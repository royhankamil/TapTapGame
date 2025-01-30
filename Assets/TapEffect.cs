using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapEffect : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // UI untuk menampilkan skor
    private int score;
    private Vector3 originalScale;
    private float tapScaleFactor = 1.2f;  // Faktor pembesaran saat tap
    private float tapDuration = 0.1f; // Durasi animasi

    private void Start()
    {
        // Ambil skor terakhir dari PlayerPrefs
        score = PlayerPrefs.GetInt("TapScore", 0);
        scoreText.text = "Score: " + score;

        // Simpan ukuran asli objek
        originalScale = transform.localScale;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }

    }

    private void Click()
    {
        Debug.Log("uhu");
        // Tambah skor
        score++;
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("TapScore", score);

        // Mulai animasi tap
        StopAllCoroutines();
        StartCoroutine(TapAnimation());
    }

    private System.Collections.IEnumerator TapAnimation()
    {
        // Perbesar sedikit
        transform.localScale = originalScale * tapScaleFactor;
        yield return new WaitForSeconds(tapDuration);

        // Kembalikan ke ukuran semula
        transform.localScale = originalScale;
    }
}
