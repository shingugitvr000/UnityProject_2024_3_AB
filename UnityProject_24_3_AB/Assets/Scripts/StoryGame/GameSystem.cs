using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

namespace STORYGAME
{

#if UNITY_EDITOR                                //��ó���� ����Ƽ �����Ϳ����� ����
    [CustomEditor(typeof(GameSystem))]
    public class GameSysteEditor : Editor       //�����͸� ��ӹ޴� Ŭ���� ����
    {
        public override void OnInspectorGUI()           //����Ƽ�� �ν����� �Լ��� ������
        {
            base.OnInspectorGUI();                      //����Ƽ �ν����� �Լ� ������ ���� �Ѵ�. (Base)

            GameSystem gameSystem = (GameSystem)target;

            //Reset Story Models ��ư ����
            if (GUILayout.Button("Reset Story Models"))
            {
                gameSystem.ResetStroyModles();
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;              //������ �̱��� ȭ

        private void Awake()
        {
            instance = this;
        }

        public enum GAMESTATE
        {
            STORYSHOW,
            WAITSELECT,
            STORYEND,
            BATTLEMODE,
            BATTLEDONE,
            SHOPMODE,
            ENDMODE,
        }

        public GAMESTATE currentState;
        public StroyTableObject[] storyModels;
        public int currentStoryInex = 1;

#if UNITY_EDITOR
        [ContextMenu("Reset Story Models")]
        public void ResetStroyModles()
        {
            storyModels = Resources.LoadAll<StroyTableObject>(""); //Resources ���� �Ʒ� ��� StoryModel�� �ҷ� ���� 
        }
#endif
    }
}
