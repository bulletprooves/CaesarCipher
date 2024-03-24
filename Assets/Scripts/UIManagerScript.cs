using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public static int keyNum;

    public CaesarControlScript caesarControl; // 시저컨트롤스키립트파일 불러옴

    public TextMeshProUGUI txtAlphabet; // Plain
    public TextMeshProUGUI txtCiphered; // Cipher
    public TextMeshProUGUI key; // 레퍼런스 할당 ㄱㄱ

    Animator anim;

    public char[] alphabet;
    string exhibitAlpha; // 텍스트로 치환 할 거, 평문
    string exhibitCiph_string; // 텍스트로 치환 할 거, 암호문
    public int asciiNum;
    bool isOpend; // 슬롯 열고닫기 부울 필드

    void Start()
    {
        anim = GetComponent<Animator>();
        keyNum = 0;
        asciiNum = 65;
        isOpend = false;
        for(int i = 0; i < 26; i++)
        {
            // alphabet[i] = (char)(i + (int)'A'); 유니티에선 이렇게 안됨. 아래처럼 해야함.
            alphabet[i] = System.Convert.ToChar(i + (int)'A'); // (int)'A'라 쓰던지 65라 쓰던지 맘대루
            exhibitAlpha = alphabet[0].ToString(); // 캐릭터를 스트링으로 치환
            txtAlphabet.text = exhibitAlpha;
        }
        key.text = keyNum.ToString();
    }

    // 아래 시계, 반시계 메서드는 각각 돌고돌아~ |(@~@)/ 야후~
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

    // 알파벳 바꾸는 메서드
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
    // 귀찮아서 걍 밑에 때려박음 ㅎ.ㅎ
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
