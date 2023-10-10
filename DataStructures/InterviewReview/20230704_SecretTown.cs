﻿//2023 07 04 시크릿 타운 면접 복습.



/*
 * 1. OOP 문법 중 C#에서의 다양화.
 * 2. C# 상속 중 Abstract, Virtual 의 차이점.
 * 3. 큐(FIFO), 스택(LIFO)를 사용하는 범위 및 차이.
 * 4. delegate와 interface 차이.
 * 5. 싱글톤과 전역변수의 차이.
 * 6. 트리 종류 정리 필요함.
 * 7. 가비지 컬렉터가 하는일.
 * 8. 렌더링 파이프라인.
 * 9. UGUI가 유니티에서 어떻게 실행되는지?
 * 10. 배치(Batch), 드로우콜(DrawCall)의 차이.
 * 11. Unity 실행 순서
 */

/*
 * 1. OOP 문법
 * - 1. 추상화(Abstraction)
 * - 공통의 속성이나 기능을 묶어 이름을 붙이는 것.
 * - 객체 지향적 관점에서 클래스를 정의하는 것을 바로 추상화라고 정의 내릴 수 있겠다.
 * 
 * - **객체의 공통적인 속성과 기능을 추출하여 정의하는것.**
 *
 *
 * - 2. 캡슐화(Encapsulation)
 * - 데이터 구조와 데이터를 다루는 방법들을 결합 시켜 묶는 것. 변수와 함수를 하나로 묶는것을 말한다.
 * - 무작정 한군데 묶으면 되는 것이 아니라 객체가 맡은 역할을 수행하기 위한 하나의 목적을 한데 묶는다 라고 생각해야한다.(은닉화)
 * - 데이터를 절대로 외부에서 직접접근을 하면 안되고 오로지 함수를 통해서만 접근해야하는데 이를 가능하게 하는게 캡슐화다.
 * - 캡슐화에 성공하면 당연히 은닉화도 자연스럽게 효력이 나타난다.
 * 
 * - 서로 연관있는 속성과 기능들을 하나의 캡슐로 만들어 데이터를 외부로 보호하는 것.
 * 데이터 보호 - 외부로부터 클래스에 정의된 속성과 기능 보호
 * 데이터 은닉 - 내부으 ㅣ동작을 감추고 외부에는 필요한 부분만 노출.
 *
 *
 * - 3. 상속성, 재사용(Inheritance)
 * - 상위 개념의 특징을 하위 개념이 물려받는 것
 * - 부모클래스에 정의 해 두고 자식클래스에서 재사용 할수 있어 반복적인 코드를 최소화 하고 공유하는 속성과 기능에 간편하게 접근하여 사용.
 * 
 * 
 * - 4. 다형성(Polymorphism)
 * - 부모 클래스에서 물려받은 가상 함수를 자식 클래스 내에서 오버라이딩 되어 사용 되는것.
 * 
 * - 어떤 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질.
 * 대표 예시로 오버라이딩, 오버로딩이 있다.
 * 오버로딩 : 같은 이름의 메소드를 중복하여 정의하는 것.
 * 오버라이딩 : 부모클래스에서 이미 정의된 메소드를 자식클래스에서 다시 정의 하는것.
 * 
 */

/*
 * 2. C# 상속 중 Abstract, Virtual, Interface.
 * - 1. Virtual(가상 키워드)
 * - virtual 키워드는 메서드, 속성, 인덱서 또는 이벤트 선언을 한정하는데 사용됩니다.
 * - 파생 클래스에서 필요에 따라서 재정의(override) 할 수있지만 필수적으로 재정의 할 필요는 없다.
 * - Virtual 한정자를 사용한 클래스는 완벽한 기능을 제공할 수 있습니다.
 *  public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Nothing!");
        }
    }
 
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("멍멍!");
        }
    }
 
    Dog temp = new Dog();
    temp.Speak();//멍멍!
 * 
 * 
 * - 2. Abstract(추상화)
 * - abstact 키워드를 사용하면 불완전하여 파생클래스에서 구현해야하는 클래스 및 클래스 멤버를 만들수있다.
 * - 추상 클래스의 사용 목적은 여러개의 파생 클래스에서 공유할 기본 클래스의 공통적인 정의를 제공하는 것입니다.
 * - 추상 클래스는 인스턴스화 할 수 없다.
 * 
 *  public abstract class Animal
    {
        public abstract void Speak();
    }
 
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("멍멍!");
        }
    }
 
    Dog temp = new Dog();
    temp.Speak();//멍멍!

 * - 3. Interface(인터페이스)
 * - 인터페이스는 abstract와 비슷하지만 멤버필드(변수) 를 사용할 수 없습니다. 대신 프로퍼티는 사용이 가능합니다.
 * - 인터페이스는 보통 여러클래스에 공통적인 기능을 추가하기위해 사용합니다.
 *  public interface Animal
    {
        void Speak();
 
        string Name
        {
            get;
            set;
        }
    }
 
    class Dog : Animal
    {
        private string name;
     
        public void Speak()
        {
            Console.WriteLine(name + "->멍멍!");
        }
     
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
     
    Dog temp = new Dog();
    temp.Name = "흰둥이";
    temp.Speak(); //흰둥이->멍멍!
 * 
 * 결론====
 * - Virtual은 하나의 기능을 하는 완전한 클래스다.
 * 파생클래스에서 상속해서 추가적인 기능추가 및 virtual 한정자가 달린 것을 재정의해서 사용가능하다.
 * 
 * - Abstract는 여러개의 파생 클래스에서 공유할 기본 클래스의 공통적인 정의만 하고,
 * 파생클래스에서 abstract 한정자가 달린 것을 모두 재정의(필수)해야 합니다.
 * 
 * - Interface에서도 abstract와 비슷하지만 멤버변수를 사용할 수 없습니다.
 * 보통 abstract는 개념적으로 계층적인 구조에서 사용이 되며(동물이나 어떤 사물의 계층적인 구조가있을때)
 * Interface는 서로다른 계층이나 타입이라도 같은 기능을 추가하고 싶을때 사용합니다.
 * (사람이나 기계가 말을하게(speak)하는 인터페이스를 추가할때)

 */

/*
 * 3. 큐(FIFO), 스택(LIFO)를 사용하는 범위 및 차이.
 * - 1. 스택(Stack)이란?
 * - Last in First Out의 구조로 입력한 데이터가 가장 위에 쌓이고.
 * 가장 위에서 데이터를 가져가는 방식이다.
 * 활용 방식 : 
 * 웹 브라우저 방문기록 : 뒤로가기
 * 역순 문자열 만들기 : 가장 나중에 입력된 문자부터 출력된다.
 * 실행 취소(Undo) : 가장 나중에 실행된 것부터 실행을 취소한다.
 * 후위 표기법 계산
 * 수식의 괄호 검사(연산자 우선순위 표현을 위한 괄호 검사)
 * 
 * - 2. 큐(Queue) 란?
 * - First in First Out의 구조로 입력한 데이터가 순서대로 쌓이고
 * 가장 처음 입력된 데이터를 가져가는 방식이다.
 * 활용방식 : 
 * 우선 순위가 같은 작업 예약(프린터의 인쇄 대기열) 
 * 은행 업무
 * 콜센터 고객 대기시간
 * 프로세스 관리
 * 너비 우선 탐색(BFS, Breadth - First Search) 구현
 * 캐시(Cache) 구현
 */

/*
 * 4. delegate와 interface 차이.
 * 
 * 인터페이스 : 
 * - 메소드의 목록만을 가지는 특별한 타입
 * - 멤버들은 구현코드들을 가지지않는다.
 * - 본체가 없고 동작이 정의되어있지 않기때문에 직접 호출할 수 없는 추상메소드
 * - 메소드를 물려주는 역할
 * - 계약, 약속 : 메소드의 구현을 강제한다.
 * - 인터페이스로부터 상속을 받는 클래스들은 인터페이스에 포함된 모든 메소드를 구현해야한다.
 * 
 * 델리게이트 : 
 * - 메소드를 가리키는 참조형으로서 메소드의 번지를 저장하거나 다른 메소드의 인수로 메소드 자체를 전달하고싶을때 사용
 * - C++의 함수 포인터에 대응되는 타입.
 * 
 */

/*
 * 5. 싱글톤과 전역변수의 차이.
 * 
 * 싱글톤 :
 * 해당 객체의 메모리를 정적으로 할당하여 하나의 객체에만 접근하는 방법.
 * 
 * 장점:
 * 프로그램이 동작하는 동안 최초로 생성된 객체 하나에만 접근을 하게 되므로 데이터를 접근하고 수정하는데 아주 용이한 특징이 있다.
 * 생성자를 다른곳에서 새롭게 선언 하더라도 이미 정적으로 선언된 객체가 반환되기 때문에 중복 생성을 방지 할 수 있다.
 * 초기 객체를 생성을 하게 되면 정적 메모리에 올라가기때문에 이후 호출하는데 아주 빠르게 접근 할 수 있다.
 * 
 * 단점:
 * 정적 메모리에 할당된 객체로 해당 객체에 너무 큰 메모리가 쌓이게 되면 프로그램 성능이 현저히 낮아질 수 있다.(정적 메모리에 할당할 수 있는 메모리 크기가 제한적이라서)
 * 하나의 정적 메모리를 사용하기때문에 병령 처리나 동기화와 같이 여러방법으로 메모리에 접근하는데 문제가 생기게된다.
 * 
 * 전역변수 : 함수의 외부에서 선언된 변수를 뜻한다.
 * 프로그램 어디에서나 접근할 수 있으며, 프로그램이 종료되어야만 메모리에서 사라진다.
 * 전역변수는 메모리상의 "데이터 영역"에 저장되며, 직접 초기화하지 않아도 0으로 자동 초기화 됩니다.
 * 
 * 둘의 차이점 : 
 * 1. 생성 시점
 * 전역변수 - 애플리케이션이 실행될 때 생성.
 * 싱글톤 - 해당 함수가 initialize(초기화) 되면서 생성.
 * 
 * 2. 자원 할당 : 
 * 전역변수 - 자원의 양이 엄청나게 크다고 가정함(특정 시점에서만 사용된다면 엄청난 낭비)
 * 싱글톤 - 사용할 때 자원을 할당하고 자신이 원할 때 자원을 해제 가능.
 * 
 */

/*
 * 6. 트리란:
 * 
 * 트리(Tree)는 계층적인 자료를 나타내는데 자주 사용되는 자료구조로서 하나이하의 부모 노드와 복수 개의 자식 노드들을 가질 수 있다.
 * 트리는 하나의 루트(Root) 노드에서 출발 하여 자식노드들을 갖게 되며, 각각의 자식노드 또한 자신의 자식노드들을 가질 수 있다.
 * 트리 구조는 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없다. 
 * 
 * 요약
 * - 부모 자식 관계를 가짐.
 * - 노드가 하나이상의 자식을 가지기 때문에 계층이 있고, 그룹이 있다.
 * - 자식이 없는 노드를 leaf라 부른다.
 */

/*
 * 7. 가비지 컬렉터가 하는일.
 * GC : 메모리를 자동으로 해제해주는 기능이다.
 * 
 * c#의 메모리 할당 방식은 메모리 조각이 발생하지 않는 방식.
 * 
 * C# 메모리 할당 방식:
 * C# 어플리케이션이 실행되면 CLR(Common Language Runtime, 공통 언어 런타임)이 해당 어플리케이션을 위한 메모리 공간을 제공하며, 
 * CLR에 의해 관리되기때문에 이를 Managed Heap이라고 부른다.
 * 각 어플리 케이션은 실행되면서 자신의 Managed Heap의 첫 주소를 가리키는 포인터를 가진다.
 * 이때 힙 메모리를 참조하는 필드는 루트 목록으로 관리되며, 동적으로 힙 메모리 를 할당할 때 마다 루트 목록과 힙이 연결된다.
 * Managed Heap의 포인터는 메모리를 할당해 줄 때 마다 할당한 메모리 만큼 이동하여 연속된 다음 주소를 가리킨다.
 * 
 * C#의 GC :
 * 각 어플리케이션의 Managed Heap은 그 공간이 유한하기 때문에 메모리 영역을 관리해주어야한다.
 * C# 어플리케이션의 메모리는 주어진 공간으로 순차적으로 채우는 특징 때문에 할당을 반복하면 힙의 마지막 주소에 도달하게 된다.
 * 이때 GC가 필요없는 메모리를 수집하여 해당 공간의 할당을 해제하는데,
 * 이것이 Garbage Collection이다.
 * 
 * 메모리 공간이 ABCDEF Empty가 있고 루트목록(스택, 정적필드)가 ACDF를 참조하는 상황이면
 * B,E는 Garbage로 취급되고, GC의 대상이 된다. C#의 GC는 다음의 과정으로 Garbage를 처리한다.
 * 
 * - 1. Managed Heap으 모든 메모리 영역을 Garbage로 간주하여 초기화한다.
 * - 2. 루트 목록을 돌며 루트가 가리키고 있는 영역과 그렇지 않은 영역을 구분한다.
 * 이때 할당된 메모리 영역이 다른 영역을 가리킬 수도 있으며, 그 영역도 루트와 관련된 영역으로 취급한다.
 * - 3.루트와 관련 없는 영역만을 Garbage로 남기고, 해당 메모리 영역을 해제(Sweep)한다.
 * - 4.Managed Heap을 순차적으로 탐색하며 해제되어 Empty가 된 영역을 채우도록 앞선 영역을 당겨 연속된 메모리 공간으로 만든다.
 * 
 * 이때 GC도 CLR 위에서 실행되는 일종의 소프트웨어이므로 작업할 때의 오버헤드가 발생한다.
 * 루트 목록을 살피고 Managed Heap을 순회하는 것이 꽤나 큰시간을 소요하게 될 수 있는데,
 * 다른 어플리케이션의 메모리를 정리하는 것이므로 GC가 쓰레기를 수집하는 동안 해당 어플리케이션이 일시적으로 중지될 수 있다.
 * 
 * Generation of GC : 
 * 위 문제를 개선하기 위해 도입된 것이 Generation 개념이다. 
 * 쓰레기가 나올 가능성이 높은 세대를 우선적으로 수집해주고 조건에 따라 다음세대를 순차적으로 수집해주는 것이다.
 * 그 기준은 가비지 컬렉션을 겪은 횟수이다. 가비지 컬렉션을 여러차례 겪었는데도 메모리에 남아 있다면 계속 사용될 가능성이 높은 영역이므로 수집의 후순위로 두고, 
 * 그렇지 않은영역을 먼저 주목하는 것이다. 따라서 할당된지 얼마 안 된 영역일수록 빈번하게 가비지 컬렉션이 일어난다.
 * 
 * 처음 메모리를 할당한 영역은 0세대가 되고, GC의 최우선 대상이 된다.
 * 1회의 가비지 컬렉션을 거치고 살아남은 메모리는 1세대로 승격되고, 새롭게 할당된 메모리가 0세대가 된다.
 * 이후 GC는 0세대만 수집을 하게 된다. 0세대의 영역들을 수집해 살아남은 영역은 다음 세대로 승격되고, 다음세대의 할당된 영역을 초과했을때 0세대 이후의 영역에 가비지 컬렉션을 해주는 것이다.
 * 전체 Managed Heap을 각 세대에 적절히 분배하고, 해당 영역에 Overflow가 일어났을 때 GC의 대상이 된다.
 * 
 * C# 은0~2세대가 존재하고, 2세대는 최소 2회 이상의 GC의 대상이 되었던 메모리 영역,
 * 1세대는 0세대와 2세대의 사이 과도기에 존재하는 영역, 0세대는 한번도 GC의 대상이 된적 없는 신생 메모리 영역으로 분류된다.
 * 
 * GC의 효율을 높이는 방법 :
 * 0세대는 단독으로 가비지 컬렉션이 일어날 수 있지만, 상위 세대는 그럴 수 없다. 2세대 가비지 컬렉션이 일어난다면 반드시 1세대와 0세대도 가비지 컬렉션이 일어난다.
 * 이때 2세대 가비지 컬렉션이 일어나면 모든 세대가 GC의 대상이 되는 것이고, Managed Heap 전체에서 가비지 컬렉션이 일어나는 것이므로 이를 FullGC라고 한다. GC의 핵심은 이 FullGC를 최소화하는 것이다.
 * 
 * FullGC를 방지하기위한 주의점 : 
 * 1. 너무많은 객체를 할당하지 않는다. 메모리 영역이 가득차 GC가 애초에 일어나지 않도록 하는 것이 가장 중요하다.
 * 2. 매우 큰 객체를 할당하면 LOH(Large Object Heap)이라는 특수 케이스로 분류되어 0세대가 아닌 2세대에 할당된다. 따라서 FullGC가 일어날 확률이 높아지므로 대형 객체 할당을 자제하는 것이 좋다.
 * 3. 참조 관계를 최소화 한다. 참조관계가 복잡해질수록 힙에 메모리가 남아 있을 확률이 높아지게 되고, GC를 호출할 확률이 높아진다. 
 * 또한, GC 이후 메모리 주소를 변경할 때 참조 관계에 있는 주소를 전부 변경해야 하는데, 이 과정에 대한 오버헤드도 커진다.
 * 4. 루트 목록이 작을수록 GC가 빠르게 끝난다.
 * 
 */

/*
 * 8. 렌더링 파이프라인.
 * 로컬스페이스 -> 월드스페이스 -> 뷰 스페이스 -> 후면 추려내기(Backface Culling) -> 조명 -> 클리핑 -> 투영 -> 뷰포트 -> 래스터라이즈
 * 
 * 로컬스페이스 : 모델링 스페이스라고도 불림, 물체의 삼각형 리스트를 정의하는데 이용하는 좌표 시스템.
 * 
 * 월드스페이스 : 자체의 로컬 좌표 시스템 내에 다수의 모델을 구성한 다음에는 이를 전역(월드)좌표 시스템으로 옮겨 하나의 장면을 구성해야한다.
 * 로컬 스페이스의 물체들은 이동, 회전, 크기 변형 등을 포함하는 월드 변환이라는 작업을 거쳐 월드 스페이스로 옮겨진다.
 * 월드 변환은 위치와 크기, 방위를 포함하는 각 물체 간의 관계를 정의함으로써 이루어진다.
 * 
 * 뷰 스페이스 : 월드 스페이스 내에서 기하물체와 카메라는 월드 좌표 시스템과 연계되어 정의된다.
 * 한편, 카메라가 월드 내 임의의 위치나 방위를 가진다면 투영이나 그밖에 작업이 어렵거나 덜 효율적이 된다.
 * 따라서 작업의 수월함을 위해 카메라를 월드 시스템의 원점으로 변환하고, 카메라에 맞추어 월드 내의 모든 기하물체를 변환해야하는데, 이와 같은 변환을
 * 뷰스페이스 변환이라 하며, 이변환을 거친 뒤의 기하물체는 뷰스페이스 내에 위치한다고 말할 수 있다.
 * 
 * 후면 추려내기 : 폴리곤은 두개의 면을 가지고있으며 하나의 면을 전면, 다른면을 후면이라 부른다.
 * 일반적으로 폴리곤의 후면은 절대 보여지지 않는데, 이는 장면 내의 물체들이 내부로 카메라를 넣는 것이 혀용되지 않기 때문이다.
 * 카메라는 절대로 폴리곤의 후면을 보지 못한다. 이와 같은 사실은 매우 중요한데, 폴리곤의 후면을 볼 수 있는 경우에는 후면 추려내기가 작동하지 않기 때문이다.
 * 
 * 조명 : 광원은 월드 스페이스 내에 정의되지만 뷰 스페이스 변환에 의해 뷰 스페이스로 변환된다.
 * 광원은 물체에 명암을 추가하여 장면에 사실감을 더해준다.
 * 
 * 클리핑 : 시야 볼륨 외부의 기하물체를 추려내야한다. 이과정을 클리핑이라 한다.
 * 시야 철두체에서의 삼각형 위치는 다음과 같이 세 가지도 분류 할 수 있다.
 * 1. 완전한 내부 -> 삼각형이 완전히 절두체 내부에 위치하면 그대로 보존되어 다음 단계로 진행한다. 
 * 2. 완전한 외부 -> 삼각형이 완전히 절두체 외부에 위치하면 추려내어진다.
 * 3. 부분적 내부(부분적 외부) -> 삼각형이 부분적으로 절두체 내부에 위치하면 삼각형을 두 개의 부분으로 분리한다. 절두체 내부의 부분은 보존되며, 나머지는 추려내어진다.
 * 
 * 투영 : 뷰 스페이스에서는 3D 장면의 2D 표현을 얻는 과정이 남아있다. 이와 같이 n차원에서 n-1차원을 얻는 과정을 투영(Projection)이라 한다.
 * 투영은 여러가지 방법이 있지만 원근 투영(Perspective Projection)이라는 방법으로, 원근법을 이용하여 기하물체를 투사한다.
 * 즉, 카메라에서 멀리 떨어진 물체는 가까운 물체에 비해 작게 나타난다. 이와 같은 타입의 투영은 3D장면을 2D 이미지로 표현하는 데 가장 적합 하다.
 * 
 * 뷰표트 변환 : 뷰포트 변환은 프로젝트 윈도으의 좌표를 부표트라 불리는 화면의 직사각형으로 변환하는 과정을 말한다.
 * 게임에서의 뷰포트는 보통 직사각형으 ㅣ전체 화면이 되지만, 윈도우 모드에서 실행하는 경우에는 클라이언트 영역이나 화면의 일부가 될 수도 있다.
 * 뷰포트사각형은 이를 포함하고 있는 윈도우와 상대적이며, 윈도우 좌표를 이용해 지정된다.
 * 
 * 래스터라이즈 : 스크린 좌표로 버텍스들을 변환한 다음에는 2D 삼각형들의 리스트를 가지게된다.
 * 래스터라이즈 단계는 각각의 삼각형을 그리는데 필요한 픽셀 컬러들을 계산하는 과정이다.
 * 래스터라이즈 과정은 엄청난 작업 양을 필요로 하므로 반드시 전용 그래픽 하드웨어에서 처리되야 한다.
 * 래스터라이즈의 결과물은 모니터에 바로 디스플레이 할수 있는 2D 이미지가 된다.
 * 
 * 요약 - 
 * - 3D 물체들은 물체의 모양과 외각을 묘사하는 삼각형들의 리스트인 삼각형 메쉬들로 표현된다.
 * - 가상 카메라는 절두체로 모델링되며 절두체 내의 공간이 카메라가 "보는" 것이 된다.
 * - 3D 물체들은 로컬스페이스 내에 정의되며 모두 하나의 월드 스페이스 시스템으로 옮겨진다.
 * 투영을 위해서는 추려내기와 같은 다른작업이 필요하며, 뷰스페이로 물체를 변환하고 카레마를 원점으로 옮기고 양의 z축을 내려다 보도록 하는 과정이 진행된다.
 * 뷰 스페이스 내에 놓여진 물체들은 투영 윈도우로 투영되며, 뷰포트 변환을 통해 투영 윈도우의 기하물체가 뷰포트로 변환된다. 
 * 이제 최정적으로 래스터라이즈를 거쳐 최종 2D 이미지를 구성하는 각각의 픽셀 컬러가 계산된다.
 * 
 */

/*
 * 9. UGUI가 유니티에서 어떻게 실행되는지?
 * 
 * UGUI는 built-in으로 탑재된 GameObject 기반의 UI관련 패키지이다.
 * GameObject기반이니 당연히 컴포넌트 기반으로 동작한다.
 * 제공되는 각기 다른 특성을 지닌 컴포넌트를 사용해 Canvas게임오브젝트 아래에 자식 UI게임오브젝트들을 구성하면
 * Canvas 게임오브젝트는 자식까지 포함해 C++엔진과 연동해서 UI로 각 프레임에 그려준다.
 * (C++로 작성된 핵심 컴포넌트는 Canvas, RectTransform, CanvasRenderer, CanvasGroup가 있다.)
 */

/*
 * 10. 배치(Batch), 드로우콜(DrawCall)의 차이.
 * - 1. 드로우콜(DrawCall)
 * 그리기 요청, cpu가 gpu 에게 그려달라고 요청 하는 것.
 * 
 * - 2. 배칭(Batching)
 * 배칭이란 동일한 메터리얼을 공유하는 오브젝트들을 묶어서 드로우콜 하는 기법이다.
 * 동일한 메터리얼을 공유하는 오브젝트만 배칭할 수 있다.
 * 
 */

/*
 * 11. Unity 실행 순서
 * 1. Awake
 * 프리팹이 인스턴스화(생성) 된 직후에 호출.
 * 오브젝트가 비활성화 되어있을땐 Awake가 호출되지 않다가 활성화 되는 순간 호출된다.
 * 활성화 되고 비활성화 시킨 뒤 다시 활성화 한다해도 호출되지 않는다. 최초 1회만 호출된다.
 * 
 * Awake만 있는 스크립트에 경우에 스크립트 활성화 버튼이 뜨지 않는다. 
 * OnEnable, Start같은 함수가 있어 스크립트가 비활성화 해놓았어도 awake는 호출된다(프리팹이 활성화 되니까).
 * 
 * 2. OnEnable
 * 오브젝트 활성화(스크립트활성화 포함) 직후 이 함수를 호출 합니다. 게임 오브젝트 + 스크립트 모두 활성화 되어있어야 합니다.
 * 
 * Awake와는 다르게 비활성화 -> 활성화 할때마다 호출됩니다.
 * 오브젝트 비활성화 -> 활성화 or 스크립트 비활성화 -> 활성화 두가지 경우 모두 출력됩니다.
 * 
 * 3. Start
 * 스크립트가 인스턴스가 활성화 된 경우에 호출합니다.
 * 즉 게임 오브젝트 + 스크립트 모두 활성화 되어있을때 최초 1회의 한정하여 호출합니다.
 * 호출 시기는 첫번째 프레임 업데이트 전이다.
 * 
 * Awake, Start 차이
 * 1. Awake가 Start 보다 빠르다.(Awake는 프리팹 인스턴스화(생성) 된 직후, Start 는 첫 프레임 업데이트 전)
 * 각각의 스크립트에서 Start를 호출한다면 두 스크립트의 호출 순서는 유니티가 내부적으로 결정하므로 랜덤이라 생각하면 된다.
 * (기본적으로 제어가 안됨)
 * 2. Awake는 스크립트가 비활성화 되어있더라도 호출된다.
 * 보통 Awake는 자신이 초기화 할 수 있는 작업을 수행하고 Start는 다른 Class 를 참조하는 경우 사용한다.
 */


/*
 * Call By Value, Call By Reference
 * 1. Call By Value
 *  - 함수가 인수로 전달 받은 값을 복사하여 처리하는 방식이다.
 *  - 전달 받은 값을 복사하여 전달 하므로 함수 내에서 값을 변경해도 원본값은 변경되지않는다.
 *  장점 : 복사하여 처리하기때문에 안전하다. 원래 값이 보존된다.
 *  단점 : 복사를 하기때문에 메모리 사용량 증가.
 *  
 * 2. Call By Reference
 *  - 함수 호출 시 인수로 전달되는 변수의 참조값을 함수 내부로 전달하는 방식.
 *  - 전달된 변수의 값을 변경하면, 호출한 쪽에서도 해당 변수의 값이 변경된다.
 *  장점 : 복사를 하지 않기 때문에 빠르다.
 *  단점 : 직접 참조를 하기때문에 원래 값이 영향을 받는다.
 * 
 */

/*
 * 깊은 복사, 얕은 복사
 * 1. 얕은 복사
 *  - 객체를 복사 할대 원래값과 복사된 값이 같은 참조를 가리키고 있는것을 말한다.
 *  - 한쪽 객체에서 해당 참조 객체를 변경하면 다른 객체의 값도 변경된다.
 *  
 * 2. 깊은 복사
 *  - 객체를 새로 생성하여 내부의 모든 참조 객체도 새롭게 생성하여 복사하는 방식.
 *  - 한쪽 객체에서 참조 객체를 변경하더라도 다른 객체는 영향 받지 않는다.
 */

/*
 * Class, Struct
 *  - Class -> private
 *  상속이 가능하다, 구조체는 상속 불가.
 *  - Struct -> pubilc
 *  struct는 값 타입 이지만 class는 참조 타입이다.
 */



/*
 * BFS(너비우선탐색)
 *  - 시작 정점을 방문한 후 시작 정점에 인접한 모든 정점들을 우선 방문하는 방법.
 * 장점 : 노드 수가 적고 깊이가 얕은 해가 존재 할 때 유리하다. 
 * 단점 :
 * - 큐(Queue - FIFO)를 이용해 다음 탐색 할 노드들을 저장하기 때문에 노드의 수가 많을 수록 필요없는 노드들까지 저장해야하기 때문에 더 큰 저장 공간이 필요.
 * - 노드의 수가 늘어나면 탐색해야할 노드가 많아져 비효율적.
 * 
 * DFS(깊이우선탐색)
 *  - 임의의 노드에서 시작하여 다음분기로 넘어가기전에 해당 분기를 완벽하게 탐색하느 방법.
 *  장점 : 
 *  - BFS에 비해 저장공간의 필요석이 적다. 백트래킹을 해야하는 노드들만 저장해주면 됨.
 *  - 찾는 노드가 깊은단계 일수록, 그 노드가 좌측에 있을수록 BFS보다 유리하다.
 *  
 *  단점 : 
 *  - 답이 아닌 경로가 매우 깊다면 그 경로에 깊이 빠질 우려가 있다.(시간이 늘어난다.)
 *  - 찾은 해가 최단 경로라는 보장이 없다.
 *  
 * 
 */