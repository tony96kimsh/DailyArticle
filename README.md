# 📰 Daily Article (영어 신문 리더 앱)
> The Guardian API를 사용하여 영어 신문을 제공하는 심플한 데스크톱 어플리케이션입니다.

![첫화면](./img/home.jpg) | ![리스트 화면](./img/list.jpg)
--|--|

<br>

- **[⬇ 실행 파일 다운로드](https://github.com/tony96kimsh/DailyArticle/releases/download/1.1.0/DailyArticle.exe)**  


- [✍️ 노션 개발 일지 링크](https://github.com/tony96kimsh/DailyArticle/releases/download/1.1.0/DailyArticle.exe)

---

## 프로젝트 개요

### 제작 배경

영어 신문은 영어 공부에 활용하기 좋은 자료입니다.  
웹사이트에서 신문을 읽을 때는 광고나 불필요한 UI가 학습에 방해가 되기 쉬운데,  
단순하고 광고 없는 환경에서 핵심 뉴스 기사만 제공되면 더 효율적인 학습이 가능하다고 판단했습니다.  
WinForms를 활용한 데스크톱 앱 형태로 영어 뉴스 리더를 개발하였습니다.

### 기술 스택

- 언어: C#
- 플랫폼: WinForms (.NET Framework)
- 외부 라이브러리: Newtonsoft.Json
- API: [The Guardian Open API](https://open-platform.theguardian.com/)

### 주요 기능

- 매일 가장 중요한 영어 뉴스를 자동으로 제공
- 기사 제목, 본문, 발행일 표시
- HTML 태그 제거로 깔끔한 기사 출력
- 기사 원문 링크 열기
- 로딩 중 딤 처리 및 "Loading..." 표시
- API 키 외부 파일에서 설정 (App.config)
- **JSON 파일을 이용한 기사 저장**
  - 최근 읽은 기사 목록 저장 (`readArticle.json`)
  - 즐겨찾기 목록 저장 (`favoriteList.json`)
- 읽은 기사와 즐겨찾기 리스트 열람 및 삭제 가능
- 기사 클릭 시 다시 본문으로 돌아가 보기 기능 지원

---

## 프로젝트 구조

### 레이아웃 구성

- `txtTitle`: 뉴스 제목 표시
- `txtAriticle`: 본문 표시용 RichTextBox (읽기 전용, 포커스 캐럿 제거)
- `lblDate`: 발행일 표시
- `linkLabel1`: Guardian 기사 원문 열기
- `llbDev`: GitHub 프로젝트 열기
- `btnChange`: 기사 갱신 버튼
- `btnFavorite`: 즐겨찾기 추가/제외 버튼
- `btnHistory`: 최근 기록 페이지 열기 버튼
- `btnFavoriteList`: 즐겨찾기 페이지 열기 버튼
- `overlay(Form)`: "Loading..." 표시용 반투명 폼 (TopMost)

### 폴더 구조

```
DailyArticle/
│
├── FormArticleView.cs               # WinForm: 기사 상세 보기 UI
├── FormArticleView.Designer.cs
├── FormArticleView.resx
│
├── FormReadList.cs                  # WinForm: 기사 목록 보기 UI
├── FormReadList.Designer.cs
├── FormReadList.resx
│
├── Article.cs                        # 기사 데이터 모델 클래스
├── MakeArticle.cs                   # 기사 요청 및 Article 객체 생성
├── MakeJson.cs                      # HTML 파싱, JSON 저장 기능
├── Loading.cs                       # 로딩 오버레이 구현
│
├── fonts/                            # UI 폰트
│   ├── Merriweather_24pt_SemiCondensed-Bold.ttf
│   └── Merriweather_24pt_SemiCondensed-Regular.ttf
│
└── img/                              # README용 이미지

```

### 코드 구조 요약

- `Form1.cs`
  - `InitOverlay()`: 오버레이 폼 초기화
  - `showArticle()`: Guardian API 요청 및 기사 표시
  - `ParseHTML()`: HTML 제거 후 본문 정리
  - `SaveArticle()`: JSON 파일로 기사 저장
  - `ShowArticle(Article)`: 전달받은 기사 표시
- `FromReadList.cs`
  - `showList()`: JSON 파일에서 리스트 읽어오기
  - `btnDelete_Click()`: 기사 삭제
  - `btnViewArticle_Click()`: 기사 본문 다시 보기

---

## 참고자료

- Merriweather 폰트  
- The Guardian Open API  
- [Microsoft Docs - WinForms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
