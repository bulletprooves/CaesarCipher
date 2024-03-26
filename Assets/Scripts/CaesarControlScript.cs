using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaesarControlScript : MonoBehaviour
{
    public GameObject outerCaesar;

    [SerializeField]
    private float rZ; // Z������ ȸ���� ��
    private int inputCount; // �Է��� �� �� �ߴ��� Ȯ��, ���� ������ ���� �߰�������
    private bool isAngleChangingMethodCalled; // ���� ���ư� �� �θ� �οﺯ��, �� ����? ������Ʈ �Լ����� ���� �ٲٴ� ������ �� �����Ӹ��� ������� �ʰ��ϱ� ����
    
    private void Awake()
    {
        inputCount = 0; // �ʱⰪ 0
        isAngleChangingMethodCalled = false;
    }

    // �Ʒ� �ð���� �ݽð���Ⱒ�� �޼��� 2���� ���� ȸ��
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

    // �Ʒ� �޼���� ���� ���� �޼���
    public void ChangeAngle()
    {
        // ���� ����
        Vector3 currentAngle = transform.eulerAngles;
        currentAngle = new Vector3(0, 0, rZ);
        transform.eulerAngles = currentAngle;
        // ���� ���� �ӹ� �Ϸ� ��, �ٽ� �οﺯ�� false ��
        isAngleChangingMethodCalled = false;
    }

    private void Update()
    {
        // �Ʒ� if���� Ű����� �ڵ�
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

        // ���� ���� �޼��带 �θ�����
        if (isAngleChangingMethodCalled)
            ChangeAngle();

        // �Է� Ƚ�� Ȯ���ؼ� ���� ���� �޼��带 ȣ��
        if (inputCount > 26)
            if (transform.eulerAngles.z > -0.5f && transform.eulerAngles.z < 0.5f)
                AngleModify();

        outerCaesar.transform.eulerAngles = new Vector3(0, 0, -13.846f * UIManagerScript.keyNum);
    }

    // ���� ���� �޼���
    public void AngleModify()
    {
        Vector3 setAngleDegreeToZero = transform.eulerAngles;
        setAngleDegreeToZero = new Vector3(0, 0, 0);
        transform.eulerAngles = setAngleDegreeToZero;
        Debug.Log("Angle Has Been Modified");
        inputCount = 0; // ���� ���� ���� �Ϸ�Ǹ� ī��Ʈ �ٽ� 0����
    }
}
