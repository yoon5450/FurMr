using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUIButtonHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public OVRCameraRig ovrCameraRig;
    public string prefabPath = "Assets/FurMr/Prefab/";  // Resources 폴더 기준으로 프리팹이 저장된 경로

    // 버튼 클릭 이벤트 핸들러
    public void OnButtonClick()
    {
        // 드롭다운에서 현재 선택된 항목의 이름 가져오기
        string selectedOption = dropdown.options[dropdown.value].text;

        Debug.Log(selectedOption);

        // 프리팹 로드 및 OVRCameraRig의 앞쪽에 오브젝트 생성
        CreateObjectInFrontOfCamera(selectedOption);
    }

    // OVRCameraRig의 앞쪽에 오브젝트 생성하는 함수
    private void CreateObjectInFrontOfCamera(string objectName)
    {
        // 오브젝트 프리팹 로드
        string prefabFullPath = prefabPath + objectName;
        GameObject objectPrefab = Resources.Load<GameObject>(prefabFullPath);

        if (objectPrefab == null)
        {
            Debug.LogError("Prefab not found at path: " + prefabFullPath);
            return;
        }

        // OVRCameraRig의 위치와 방향 가져오기
        Transform cameraTransform = ovrCameraRig.centerEyeAnchor;
        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * 2f;

        // 오브젝트 생성
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // 오브젝트에 이름 설정
        spawnedObject.name = objectName;

        /* 부착할 컴포넌트 추가 (예: Rigidbody) 이미 부착되어있으면 필요 없음
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        rb.mass = 1.0f;  // 원하는 값을 설정합니다.
        rb.isKinematic = true;*/
    }
}
