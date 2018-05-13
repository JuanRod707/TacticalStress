using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class DynamicText : MonoBehaviour
    {
        public string DynamicFormat;
        public Text TargetText;

        public void SetDynamicText(object parameter)
        {
            TargetText.text = string.Format(DynamicFormat, parameter);
        }

        public void SetDynamicText(object[] parameters)
        {
            TargetText.text = string.Format(DynamicFormat, parameters);
        }
    }
}
