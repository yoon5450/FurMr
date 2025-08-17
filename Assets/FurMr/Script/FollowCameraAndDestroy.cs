using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowCameraAndDestroy : MonoBehaviour
{
    public Canvas uiCanvas; // Inspector���� �ش� Canvas�� �Ҵ����ּ���.
    public Button destroyButton; // Inspector���� �ش� ��ư�� �Ҵ����ּ���.
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (uiCanvas != null && destroyButton != null)
        {
            // ��ư Ŭ�� �̺�Ʈ ������ ���
            destroyButton.onClick.AddListener(DestroyUI);

            // UI�� ī�޶� ���󰡰� ����
            StartCoroutine(FollowCamera());
        }
        else
        {
            Debug.LogError("Please assign the UI Canvas and Button in the Inspector.");
        }
    }

    // UI�� ī�޶� ���󰡰� �ϴ� �ڷ�ƾ
    IEnumerator FollowCamera()
    {
        while (true)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
            uiCanvas.transform.position = screenPos;
            yield return null;
        }
    }

    // UI�� �����ϴ� �Լ�
    void DestroyUI()
    {
        if (uiCanvas != null)
        {
            Destroy(uiCanvas.gameObject);
        }
    }
}
