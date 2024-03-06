using UnityEngine;
using UnityEngine.Serialization;

namespace Plugins.AAA.Core.Runtime.UI
{
    //Copy pasted from https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html
    public class SpriteStretch : MonoBehaviour
    {
        [SerializeField] private bool keepAspectRatio;

        private void Start()
        {
            var mainCam = Camera.main;
            if (mainCam == null)
                return;
            
            var topRightCorner = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));

            var worldSpaceWidth = topRightCorner.x * 2;
            var worldSpaceHeight = topRightCorner.y * 2;

            var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

            transform.localScale = Vector3.one;
            var scaleFactorX = worldSpaceWidth / spriteSize.x;
            var scaleFactorY = worldSpaceHeight / spriteSize.y;

            // if (keepAspectRatio)
            // {
            //     if (scaleFactorX > scaleFactorY)
            //     {
            //         scaleFactorY = scaleFactorX;
            //     }
            //     else
            //     {
            //         scaleFactorX = scaleFactorY;
            //     }
            // }

            gameObject.transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
        }
    }
}