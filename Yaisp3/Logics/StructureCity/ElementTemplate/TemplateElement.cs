using System;

namespace Yaisp3
{
    /// <summary>
    /// Класс базового элемента города.
    /// </summary>
    public class TemplateElement
    {
        #region Поля

        protected int elementRowPos;
        protected int elementColPos;


        /// <summary>
        /// Ширина элемента.
        /// </summary>
        protected int elementWidth;

        /// <summary>
        /// Высота элемента.
        /// </summary>
        protected int elementHeight;

        protected System.Drawing.Color elementColor;

        #endregion

        #region Методы

        public System.Drawing.Color GetDrawingColor()
        {
            return elementColor;
        }

        public Tuple<int, int> GetPosition()
        {
            return Tuple.Create(elementRowPos, elementColPos);
        }

        public void SetPosition(int Row, int Col)
        {
            elementRowPos = Row;
            elementColPos = Col;
        }

        public Tuple<int, int> GetElementSize()
        {
            return Tuple.Create(elementWidth, elementHeight);
        }
        
        public bool ContainsPosition(int Row, int Col, int Width, int Height)
        {
            if (elementHeight == 1 && elementWidth == 1)
            {
                if (Width == 1 && Height == 1)
                    return Row == elementRowPos && Col == elementColPos;
                else
                    return elementRowPos <= Row + Height && elementRowPos >= Row &&
                        elementColPos <= Col + Width && elementColPos >= Col;
            }
            else
            {
                if (Width == 1 && Height == 1)
                    return elementRowPos + elementHeight >= Row && elementRowPos <= Row &&
                        elementColPos + elementWidth >= Col && elementColPos <= Col;
                else
                    return Row < elementRowPos && elementRowPos + elementHeight > Row + Height &&
                        Col < elementColPos && elementColPos + elementWidth > Col + Width;
            }
        }

        #endregion
    }
}
