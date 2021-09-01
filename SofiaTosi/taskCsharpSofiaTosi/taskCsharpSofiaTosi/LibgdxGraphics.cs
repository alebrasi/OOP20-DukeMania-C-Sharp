using System;
using System.Collections.Generic;
using System.Text;

namespace taskCsharpSofiaTosi
{
    public class LibgdxGraphics
    {

        public class Texture
        {
            string _str;
            public Texture(string value)
            {
                _str = value;
            }

            public string Str { get => _str; set => _str = value; }

            //dummy method
            public void Dispose()
            {

            }
        }

        public class Skin
        {



            //dummy method
            public void Add(string str, Font font)
            {

            }

            //dummy method
            public void AddRegions(TextureAtlas ta)
            {

            }

            //dummy method
            public void Load(Json json)
            {

            }
        }
        public class TextureAtlas
        {
            string _str;
            public string Str { get => _str; set => _str = value; }
            public TextureAtlas(string value)
            {
                _str = value;
            }


            //dummy method
            public void Dispose()
            {

            }

        }
        public class Font
        {
            string _str;

            public string Str { get => _str; set => _str = value; }

            public Font(string value)
            {
                _str = value;
            }

            //dummy method
            public void GetRegion()
            {

            }

            //dummy method
            public void Dispose()
            {

            }

            //dummy method
            public void SetLinearFilter()
            {

            }

            //dummy method
            public Font GenerateFont(FreeTypeFontParameter parameter)
            {
                return new Font(_str);
            }

        }
        public class Json
        {
            string _str;
            public string Str { get => _str; set => _str = value; }
            public Json(string value)
            {
                _str = value;
            }

        }
        public class FreeTypeFontParameter
        {
            int _size;
            float _borderWidth;
            ConsoleColor _color;
            ConsoleColor _shadowColor;
            int _shadowOffsetX;

            public int Size { get => _size; set => _size = value; }
            public float BorderWidth { get => _borderWidth; set => _borderWidth = value; }
            public ConsoleColor Color { get => _color; set => _color = value; }
            public ConsoleColor ShadowColor { get => _shadowColor; set => _shadowColor = value; }
            public int ShadowOffsetX { get => _shadowOffsetX; set => _shadowOffsetX = value; }
        }


    }
}
