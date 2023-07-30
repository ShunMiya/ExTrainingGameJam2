using System.Collections;
using UnityEngine;
using StageSystem;

namespace Player
{
    public class AreaClear : MonoBehaviour
    {
        public bool HaveKey = false;
        private bool AreaClearPoint = false;
        private CameraMove cameraMove;

        private SpriteRenderer playerSpriteRenderer;

        public float moveDuration = 1f;
        public float yOffset = 2f;

        public void Start()
        {
            cameraMove = FindObjectOfType<CameraMove>();
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!AreaClearPoint) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ここまで来てる");
                if (!HaveKey) return;
                Debug.Log("ここにも来てる");

                cameraMove.PointUpdate();

                // プレイヤーを上に移動させるコルーチンを開始
                StartCoroutine(MovePlayer());
            }

        }

        private IEnumerator MovePlayer()
        {
            // 移動開始時の透明度を保存
            float startAlpha = playerSpriteRenderer.color.a;
            Vector3 startPosition = transform.position;

            // 移動中は透明度を0にする
            Color startColor = playerSpriteRenderer.color;
            playerSpriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

            // プレイヤーを上に移動させる
            Vector3 targetPosition = transform.position + Vector3.up * yOffset;
            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                float t = elapsedTime / moveDuration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 移動が終わったら透明度を元に戻す
            playerSpriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, startAlpha);
            HaveKey = false;
        }

        public void AreaClearPointUpdate(bool data)
        {
            AreaClearPoint = data;
        }

        public void HaveKeyUpdate()
        {
            HaveKey = true;
        }
    }
}
