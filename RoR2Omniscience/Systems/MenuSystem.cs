using UnityEngine;

namespace RoR2Omniscience
{
    public class MenuSystem : MonoBehaviour
    {
        private bool menuVisible = false;
        private GUIStyle buttonStyle;
        private GUIStyle panelStyle;

        private void Start()
        {
            InitializeStyles();
        }

        private void InitializeStyles()
        {
            buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                padding = new RectOffset(10, 10, 8, 8)
            };

            panelStyle = new GUIStyle(GUI.skin.box)
            {
                fontSize = 12,
                padding = new RectOffset(10, 10, 10, 10)
            };
        }

        private void Update()
        {
            // M: Toggle menu
            if (Input.GetKeyDown(KeyCode.M))
            {
                menuVisible = !menuVisible;
            }
        }

        private void OnGUI()
        {
            if (!menuVisible) return;

            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Omniscience Menu", panelStyle);

            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 120, 280, 30), "Press M to hide this menu");
            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 80, 280, 30), "F1 - Toggle Overlay");
            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 40, 280, 30), "F2 - Toggle Targeting");
            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2, 280, 30), "F3 - Toggle Aim Assist");
        }
    }
}
