using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{
    Text textBox;
    int scriptIndex = 0;
    int index = 0;

    public List<string[]> ScriptList = new List<string[]>();
    string[] Scripts = {
        $"<color=#FFD66D>피아니스트</color> : 안녕?\n" +
            $"<color=#19C2A3>상호</color> :여기가 어디지..?",
            $"<color=#FFD66D>피아니스트</color> : 내 숲에 온걸 환영해.\n" +
            $"<color=#19C2A3>상호</color> : ... 누구세요?",
            $"<color=#FFD66D>피아니스트</color> : 응... 난 숲속의 피아니스트야.\n" +
            $"<color=#19C2A3>상호</color> : 내가 왜 여기에 있지? 난 분명...",
            $"<color=#FFD66D>피아니스트</color> : 내가 널 이곳으로 초대했어. 작곡가가 필요해서 말이야.\n" +
            $"<color=#19C2A3>상호</color> : 난 작곡은 커녕 악보도 볼 줄 몰라",
            $"<color=#FFD66D>피아니스트</color> : 괜찮아. 너라면 훌륭한 곡을 만들 수 있을거야.\n" +
            $"<color=#19C2A3>상호</color> : ...무슨 소리야?",
            $"<color=#FFD66D>피아니스트</color> : 날 따라올래?"
    };
    string[] Scripts_1 = {"",
            $"<color=#FFD66D>피아니스트</color> : 사람들은 참 재미있게 사는 것 같아\n" +
            $"<color=#19C2A3>상호</color> : ...?",
            $"<color=#FFD66D>피아니스트</color> : 하루에도 수십, 수백가지의 감정을 느끼며 살아가잖아. 기쁨과 슬픔, 즐거움과 화, 사랑과 미움...\n" +
            $" 난 이런 감정들을 단어로만 알고 있지 느껴보지 못했거든...\n" +
            $"<color=#19C2A3>상호</color> : 그래서 날 여기로 초대한거야?",
            $"<color=#FFD66D>피아니스트</color> : 음악의 언어는 무한하다는 말 알아?\n" +
            $"<color=#19C2A3>상호</color> : 들어본 적 있어",
            $"<color=#FFD66D>피아니스트</color> : 네가 음악을 통해 내게 행복이란 감정을 가르쳐줘\n" +
            $"<color=#19C2A3>상호</color> : 음악을 배워본 적이 없다니까...",
            $"<color=#FFD66D>피아니스트</color> : 음... 먼저 너가 행복했던 기억을 떠올려봐... 구체적일수록 좋아\n" +
            $"<color=#19C2A3>상호</color> : 행복했던 기억...",
            $"<color=#FFD66D>피아니스트</color> : 그 기억이 너의 작곡에 도움이 될꺼야\n"+
            $"<color=#19C2A3>상호</color> : 작곡이랑 무슨 상관인데?",
            $"<color=#FFD66D>피아니스트</color> : 난 감정을 연주하는 피아니스트거든.\n" +
            $"<color=#19C2A3>상호</color> : 감정을 연기하는 피아니스트...?",
            $"<color=#FFD66D>피아니스트</color> : 내 피아노에 감정을 전달하면, 난 그 감정을 읽어내어 피아노를 칠꺼야",
            $"<color=#19C2A3>상호</color> : 그렇구나... 음... 흐릿한 기억이긴 한데...\n" +
            $"내가 아주 어렸을때 부모님과 함께 놀이동산에 가서 회전목마를 탄 기억이 나",
            $"<color=#FFD66D>피아니스트</color> : 좋아 그 정도면 충분해."};
    string[] Scripts_2 = {"",
            $"<color=#FFD66D>피아니스트</color> : 연주를 시작해볼까?\n" +
            $"<color=#19C2A3>상호</color> : 악보도 없이?",
            $"<color=#FFD66D>피아니스트</color> : 네가 있잖아",
            $"<color=#FFD66D>피아니스트</color> : 여기 피아노 옆으로 와줄래?",
            $"<color=#FFD66D>피아니스트</color> : 자 이제 아까 말했던 장면을 떠올려봐.",
            $"<color=#FFD66D>피아니스트</color> : 좋아... 이번 곡은 좋은 예감이 드는걸..."};
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
        ScriptList.Add(Scripts);
        ScriptList.Add(Scripts_1);
        ScriptList.Add(Scripts_2);
    }

    public void NextScript()
    {
        textBox.text = ScriptList[scriptIndex][index];
        index++;
        if (index.Equals(ScriptList[scriptIndex].Length))
        {
            scriptIndex++;
            index = 0;
        }
    }
}
