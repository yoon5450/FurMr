# FurMr

졸업논문, 프로젝트용 VR 가구 프로젝트입니다.

Quest3의 Depth Sensor와 depth 관련 api를 이용해 실제 사물과 depth를 판별하여 실제 가구처럼 보이고자 한 프로젝트입니다.

호스팅중인 컴퓨터의 화면 미러링 오브젝트를 라이브러리를 통해 가져와 폐색(Occlusion)이 가능한 형태로 보여줄 수 있습니다. 

- 화면 미러링 라이브러리 [uWindowCapture]( https://github.com/hecomi/uWindowCapture )

구현내용
- Depth 인식을 통한 폐색
- 호스팅중인 컴퓨터의 화면 미러링 오브젝트
- 논문 작성

졸업논문 링크:(https://drive.google.com/file/d/1oTOQjSn42scBLCr2PQkxDezpqNEGNYjV/view?usp=drive_link)

논문 요약

# Mixed Reality Virtual Furniture (Unity + Meta Quest 3)

> Quest 3에서 **Passthrough MR**와 **폐색(Occlusion)**을 이용해 가상 가구를 자연스럽게 배치/상호작용하는 프로젝트.

## ✨ Overview
- **문제의식**: MR에서 현실 물체와 가상 오브젝트의 깊이 관계가 어긋나면 멀미·몰입도 저하.
- **접근**: Depth Sensor 기반 실시간 폐색 vs. **SelectivePassthrough**(사전 스캔 맵 기반) 비교 후, **성능/안정성** 때문에 SelectivePassthrough 채택.
- **핵심 결과**: 정의된 환경(벽/바닥 등)과 가상 오브젝트 간 **정확한 폐색**을 구현하면서도 휴대형 HMD에서 **프레임 유지**.

## 🎥 Demo
- `Docs/images/demo.gif` (추가 예정)

## 🧩 Features
- **Passthrough MR** with SelectivePassthrough shader
- **OVRSceneManager**로 사전 스캔된 Depth Mesh 로드 및 글로벌 콜라이더 세팅
- **Occlusion 렌더링**: 현실-가상 깊이관계에 따른 가림 처리
- **인터랙션 데모**
  - Pistol + 튀는 Ball 발사 (Rigidbody/Physics Material)
  - Dart Throwing: `OVRGrabbable` 커스텀 상속으로 속도/중력 제어
- **uWindowCapture**로 PC 화면을 텍스처화해 MR 공간에 미러링

## 🛠 Tech Stack
- Unity (URP/내부 렌더러 자유)
- Oculus Integration + XR Interaction
- Meta Quest 3 (Android/ARM64)

## 🏗 Setup
1. Clone 후 Unity Hub로 열기
2. **Project Settings**
   - **Version Control**: Visible Meta Files
   - **Asset Serialization**: Force Text
3. **Build Settings**
   - Platform: **Android** (Switch Platform)
   - XR Plug-in Management: **Oculus**
   - Scripting Backend: **IL2CPP**, Target Architectures: **ARM64**
4. Quest 3 연결 → **Build & Run**
