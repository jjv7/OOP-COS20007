using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        private bool _selected;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public bool Selected
        {
            get 
            { 
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public Shape()
        {
            _color = Color.Green;
            _x = 0.0f;
            _y = 0.0f;
            _width = 100;
            _height = 100;
        }

        public void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            if ((pt.X >= X) && (pt.X <= _x + _width) && (pt.Y >= _y) && (pt.Y <= _y + _height))
            {
                return true;
            } 
            else 
            { 
                return false;
            }
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }
    }
}
