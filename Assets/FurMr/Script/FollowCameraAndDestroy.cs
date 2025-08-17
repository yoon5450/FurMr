using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowCameraAndDestroy : MonoBehaviour
{
    public Canvas uiCanvas; // Inspector에서 해당 Canvas를 할당해주세요.
    public Button destroyButton; // Inspector에서 해당 버튼을 할당해주세요.
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (uiCanvas != null && destroyButton != null)
        {
            // 버튼 클릭 이벤트 리스너 등록
            destroyButton.onClick.AddListener(DestroyUI);

            // UI를 카메라를 따라가게 설정
            StartCoroutine(FollowCamera());
        }
        else
        {
            Debug.LogError("Please assign the UI Canvas and Button in the Inspector.");
        }
    }

    // UI를 카메라를 따라가게 하는 코루틴
    IEnumerator FollowCamera()
    {
        while (true)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
            uiCanvas.transform.position = screenPos;
            yield return null;
        }
    }

    // UI를 제거하는 함수
    void DestroyUI()
    {
        if (uiCanvas != null)
        {
            Destroy(uiCanvas.gameObject);
        }
    }
}
