using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClick : MonoBehaviour
{
    public int count = 0;
    public Text characterText;
    public GameManager GM;

    public void CharacterClicked()
    {
        Debug.Log("클릭감지");

        if (count == 0) //최초 클릭시 대사와 돈,포스트잇, 특별 재료 등을 반환 (돈을 일정이상 클릭해야 하는 기믹도)
        {
            GM.ChageIngredients();
            count = 1;
            //캐릭터 대사
        }
        else
        {
            count = count + 1;
        }

    }
}
