using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public static int keyNum;

    public CaesarControlScript caesarControl; // ������Ʈ�ѽ�Ű��Ʈ���� �ҷ���

    public TextMeshProUGUI txtAlphabet; // Plain
    public TextMeshProUGUI txtCiphered; // Cipher
    public TextMeshProUGUI key; // ���۷��� �Ҵ� ����

    Animator anim;

    public char[] alphabet;
    string exhibitAlpha; // �ؽ�Ʈ�� ġȯ �� ��, ��
    string exhibitCiph_string; // �ؽ�Ʈ�� ġȯ �� ��, ��ȣ��
    public int asciiNum;
    bool isOpend; // ���� ����ݱ� �ο� �ʵ�

    void Start()
    {
        anim = GetComponent<Animator>();
        keyNum = 0;
        asciiNum = 65;
        isOpend = false;
        for(int i = 0; i < 26; i++)
        {
            // alphabet[i] = (char)(i + (int)'A'); ����Ƽ���� �̷��� �ȵ�. �Ʒ�ó�� �ؾ���.
            alphabet[i] = System.Convert.ToChar(i + (int)'A'); // (int)'A'�� ������ 65�� ������ �����
            exhibitAlpha = alphabet[0].ToString(); // ĳ���͸� ��Ʈ������ ġȯ
            txtAlphabet.text = exhibitAlpha;
        }
        key.text = keyNum.ToString();
    }

    // �Ʒ� �ð�, �ݽð� �޼���� ���� ������~ |(@~@)/ ����~
    public void ButtonDownClockwise()
    {
        caesarControl.Clockwise();
        if (asciiNum >= 90)
            asciiNum = 65;
        else
            asciiNum++;
        ChangeText();
    }

    public void ButtonDownAntiClockwise()
    {
        caesarControl.AntiClockwise();
        if (asciiNum <= 65)
            asciiNum = 90;
        else
            asciiNum--;
        ChangeText();
    }

    // ���ĺ� �ٲٴ� �޼���
    public void ChangeText()
    {
        exhibitAlpha = alphabet[asciiNum - (int)'A'].ToString();
        txtAlphabet.text = exhibitAlpha;
    }

    public void ButtonOpenSlot()
    {
        if (isOpend)
        {
            isOpend = false;
            anim.SetBool("isOpen", false);
        }
        else
        {
            isOpend = true;
            anim.SetBool("isOpen", true);
        }
    }

    public void Sub()
    {
        if (keyNum <= 0)
            keyNum = 25;
        else
            keyNum--;
        key.text = keyNum.ToString();
    }
    public void Add()
    {
        if (keyNum >= 25)
            keyNum = 0;
        else
            keyNum++;
        key.text = keyNum.ToString();
    }
    // �����Ƽ� �� �ؿ� �������� ��.��
    private void Update()
    {
        char cipheredCipher_char;
        int cipherNumber = asciiNum + keyNum;
        if (cipherNumber > 90)
            cipherNumber -= 26;
        cipheredCipher_char = System.Convert.ToChar(cipherNumber);
        exhibitCiph_string = cipheredCipher_char.ToString();
        txtCiphered.text = exhibitCiph_string;
    }
    public void GoToMyChannel()
    {
        Application.OpenURL("https://www.youtube.com/@bulletprooves"); // visit my Y0uTubeChannel
    }
}
