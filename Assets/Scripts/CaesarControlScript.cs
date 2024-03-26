using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaesarControlScript : MonoBehaviour
{
    public GameObject outerCaesar;

    [SerializeField]
    private float rZ; // Z축으로 회전한 값
    private int inputCount; // 입력을 몇 번 했는지 확인, 각도 수정을 위해 추가했지렁
    private bool isAngleChangingMethodCalled; // 각도 돌아갈 때 부를 부울변수, 왜 만듦? 업데이트 함수에서 각도 바꾸는 연산이 매 프레임마다 연산되지 않게하기 위해
    
    private void Awake()
    {
        inputCount = 0; // 초기값 0
        isAngleChangingMethodCalled = false;
    }

    // 아래 시계방향 반시계방향각각 메서드 2개는 각도 회전
    public void Clockwise()
    {
        rZ = rZ - 13.84615f;
        inputCount++;
        isAngleChangingMethodCalled = true;
    }
    public void AntiClockwise()
    {
        rZ = rZ + 13.84615f;
        inputCount++;
        isAngleChangingMethodCalled = true;
    }

    // 아래 메서드는 각도 변경 메서드
    public void ChangeAngle()
    {
        // 각도 변경
        Vector3 currentAngle = transform.eulerAngles;
        currentAngle = new Vector3(0, 0, rZ);
        transform.eulerAngles = currentAngle;
        // 각도 변경 임무 완료 후, 다시 부울변수 false 로
        isAngleChangingMethodCalled = false;
    }

    private void Update()
    {
        // 아래 if문은 키보드용 코드
        if (Input.GetKeyDown(KeyCode.D))
        {
            rZ = rZ - 13.84615f;
            inputCount++;
            isAngleChangingMethodCalled = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rZ = rZ + 13.84615f;
            inputCount++;
            isAngleChangingMethodCalled = true;
        }

        // 각도 변경 메서드를 부를깝숑
        if (isAngleChangingMethodCalled)
            ChangeAngle();

        // 입력 횟수 확인해서 각도 수정 메서드를 호출
        if (inputCount > 26)
            if (transform.eulerAngles.z > -0.5f && transform.eulerAngles.z < 0.5f)
                AngleModify();

        outerCaesar.transform.eulerAngles = new Vector3(0, 0, -13.846f * UIManagerScript.keyNum);
    }

    // 각도 수정 메서드
    public void AngleModify()
    {
        Vector3 setAngleDegreeToZero = transform.eulerAngles;
        setAngleDegreeToZero = new Vector3(0, 0, 0);
        transform.eulerAngles = setAngleDegreeToZero;
        Debug.Log("Angle Has Been Modified");
        inputCount = 0; // 오차 각도 수정 완료되면 카운트 다시 0으로
    }
}
