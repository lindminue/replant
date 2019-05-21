using UnityEngine;
using UnityEngine.UI;

namespace SnapScroll
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] SnapScrollView scrollView;
        [SerializeField] Image[] indicators;

        void Start()
        {
            Application.targetFrameRate = 60;
            
            scrollView.OnPageChanged += OnIndicatorUpdate;
            scrollView.RefreshPage();
        }
        
        void OnIndicatorUpdate()
        {
            for(var i = 0; i < indicators.Length; i++)
            {
                var a = (i == scrollView.Page) ? 1 : 0.5f;
                indicators[i].color = new Color(0, 0, 0, a);
            }
        }
        
    }
}