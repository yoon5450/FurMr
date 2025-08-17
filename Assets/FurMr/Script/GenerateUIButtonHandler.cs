using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUIButtonHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public OVRCameraRig ovrCameraRig;
    public string prefabPath = "Assets/FurMr/Prefab/";  // Resources ���� �������� �������� ����� ���

    // ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void OnButtonClick()
    {
        // ��Ӵٿ�� ���� ���õ� �׸��� �̸� ��������
        string selectedOption = dropdown.options[dropdown.value].text;

        Debug.Log(selectedOption);

        // ������ �ε� �� OVRCameraRig�� ���ʿ� ������Ʈ ����
        CreateObjectInFrontOfCamera(selectedOption);
    }

    // OVRCameraRig�� ���ʿ� ������Ʈ �����ϴ� �Լ�
    private void CreateObjectInFrontOfCamera(string objectName)
    {
        // ������Ʈ ������ �ε�
        string prefabFullPath = prefabPath + objectName;
        GameObject objectPrefab = Resources.Load<GameObject>(prefabFullPath);

        if (objectPrefab == null)
        {
            Debug.LogError("Prefab not found at path: " + prefabFullPath);
            return;
        }

        // OVRCameraRig�� ��ġ�� ���� ��������
        Transform cameraTransform = ovrCameraRig.centerEyeAnchor;
        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * 2f;

        // ������Ʈ ����
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // ������Ʈ�� �̸� ����
        spawnedObject.name = objectName;

        /* ������ ������Ʈ �߰� (��: Rigidbody) �̹� �����Ǿ������� �ʿ� ����
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        rb.mass = 1.0f;  // ���ϴ� ���� �����մϴ�.
        rb.isKinematic = true;*/
    }
}
