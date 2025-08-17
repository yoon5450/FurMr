using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurMrRayInteract : MonoBehaviour
{
    private GameObject grabbedObject;
    private bool isGrabbing = false;
    private Vector3 grabOffset; // ������Ʈ�� ��Ʈ�ѷ��� ��� ��ġ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Trigger ��ư�� ��������
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            // Ray�� �����Ͽ� ��ȣ�ۿ� ������ ������Ʈ Ȯ��
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                // ��ȣ�ۿ� ������ ������Ʈ�� Rigidbody ������Ʈ�� �ִٸ�
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // ������Ʈ�� ���
                    grabbedObject = hit.collider.gameObject;

                    // ������� ��ġ ���̸� ����Ͽ� �ʱ� grabOffset ���
                    grabOffset = grabbedObject.transform.position - hit.point;

                    isGrabbing = true;
                }
            }
        }

        // Trigger ��ư�� ������
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            isGrabbing = false;
        }

        if (isGrabbing && grabbedObject != null)
        {
            // ��Ʈ�ѷ��� ���� ��ġ
            Vector3 controllerPosition = transform.position;

            // ��Ʈ�ѷ��� ���� ȸ��
            Quaternion controllerRotation = transform.rotation;

            // ������Ʈ�� ���ο� ��ġ ���
            Vector3 newPosition = controllerPosition + controllerRotation * grabOffset;

            // ������Ʈ�� ��ġ�� �ε巴�� �̵�
            grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, newPosition, Time.deltaTime * 10f);
        }
    }
}