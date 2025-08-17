using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurMrRayInteract : MonoBehaviour
{
    private GameObject grabbedObject;
    private bool isGrabbing = false;
    private Vector3 grabOffset; // 오브젝트와 컨트롤러의 상대 위치

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Trigger 버튼이 눌러지면
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            // Ray를 생성하여 상호작용 가능한 오브젝트 확인
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                // 상호작용 가능한 오브젝트에 Rigidbody 컴포넌트가 있다면
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // 오브젝트를 잡기
                    grabbedObject = hit.collider.gameObject;

                    // 상대적인 위치 차이를 사용하여 초기 grabOffset 계산
                    grabOffset = grabbedObject.transform.position - hit.point;

                    isGrabbing = true;
                }
            }
        }

        // Trigger 버튼이 떼지면
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            isGrabbing = false;
        }

        if (isGrabbing && grabbedObject != null)
        {
            // 컨트롤러의 현재 위치
            Vector3 controllerPosition = transform.position;

            // 컨트롤러의 현재 회전
            Quaternion controllerRotation = transform.rotation;

            // 오브젝트의 새로운 위치 계산
            Vector3 newPosition = controllerPosition + controllerRotation * grabOffset;

            // 오브젝트의 위치를 부드럽게 이동
            grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, newPosition, Time.deltaTime * 10f);
        }
    }
}