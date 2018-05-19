using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class DynamicText : MonoBehaviour
    {
        public string DynamicFormat;
        public Text TargetText;

        void Start()
        {
            if (TargetText == null)
                TargetText = GetComponent<Text>();
        }

        public void SetDynamicText(object parameter)
        {
            TargetText.text = string.Format(DynamicFormat, parameter);
        }

        public void SetDynamicText(params object[] parameters)
        {
            TargetText.text = string.Format(DynamicFormat, parameters);
        }
    }
}
 