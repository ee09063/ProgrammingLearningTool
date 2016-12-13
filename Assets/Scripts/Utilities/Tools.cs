namespace Utilities
{
    using UnityEngine;

    public static class PanelHelper
    {
        public enum WindowPositions
        {
            Center,
            Right,
            Up,
            Down,
            Left
        }

        public static void GetAnchorsForWindowPosition(WindowPositions targetPosition, out Vector2 anchorMin, out Vector2 anchorMax)
        {
            switch (targetPosition)
            {
                case WindowPositions.Right:
                    anchorMin = Vector2.right;
                    anchorMax = new Vector2(1.2f, 1);
                    break;

                case WindowPositions.Up:
                    anchorMin = Vector2.up;
                    anchorMax = new Vector2(1, 2);
                    break;

                case WindowPositions.Down:
                    anchorMin = new Vector2(0, -1);
                    anchorMax = Vector2.right;
                    break;

                case WindowPositions.Left:
                    anchorMin = new Vector2(-0.2f, 0.86f);
                    anchorMax = new Vector2(0, 1);
                    break;

                default:
                    anchorMin = new Vector2(0, 0.86f);
                    anchorMax = new Vector2(0.2f, 1);
                    break;
            }
        }

        public static void LerpRectTransformAnchors(RectTransform rectTransform, Vector2 targetMin, Vector2 targetMax, float speed)
        {
            rectTransform.anchorMin = Vector2.Lerp(rectTransform.anchorMin, targetMin, speed);
            rectTransform.anchorMax = Vector2.Lerp(rectTransform.anchorMax, targetMax, speed);
        }
    }
}
