using System;
using System.Collections.Generic;
using System.Linq;
using static taskCsharpSofiaTosi.LibgdxGraphics;

namespace taskCsharpSofiaTosi
{

    public class AssetsManager
    {
        public static void Main(string[] args) { }
        static AssetsManager instance;
        Boolean areLoaded = false;
        readonly IDictionary<string, Texture> textureAssociations = new Dictionary<string, Texture>();
        IDictionary<string, Skin> skinAssociations = new Dictionary<string, Skin>();
        IDictionary<string, Font> fontAssociations = new Dictionary<string, Font>();
        IDictionary<string, TextureAtlas> textureAtlasAssociations = new Dictionary<string, TextureAtlas>();
        IDictionary<string, Json> jsonAssociations = new Dictionary<string, Json>();
        const int FONT_SIZE_MENU = 50;
        const float fontBorderWidth = 0.5f;
        readonly ConsoleColor FONT_COLOR = ConsoleColor.Black;
        static Font generator;
        const int FONT_SIZE = 40;

        private AssetsManager() => LoadAll();

        /// <summary>
        /// return the current instance of the AssetsManager
        /// </summary>
        /// <returns></returns>
        public static AssetsManager GetInstance()
        {
            if (instance == null)
            {
                instance = new AssetsManager();
            }
            return instance;
        }

        /// <summary>
        /// return a specific texture
        /// </summary>
        /// <param name="textureStr"></param>
        /// <returns></returns>
        public Texture GetTexture(string textureStr)
        {
            Texture texture;
            if (textureAssociations.TryGetValue(textureStr, out texture) == false)
            {
                throw new System.ArgumentNullException();
            }
            return texture;
        }

        /// <summary>
        /// load all the textures
        /// </summary>
        void LoadTexture()
        {
            textureAssociations.Add("pinkAndBluButtons.png", new Texture("pinkAndBluButtons.png"));
            textureAssociations.Add("background.png", new Texture("background.png"));
            textureAssociations.Add("blueBackground.png", new Texture("blueBackground.png"));
            textureAssociations.Add("blueSpark.png", new Texture("blueSpark.png"));
            textureAssociations.Add("DukeMania.png", new Texture("DukeMania.png"));
            textureAssociations.Add("note.png", new Texture("note.png"));
            textureAssociations.Add("scoreboard.png", new Texture("scoreboard.png"));
        }

        /// <summary>
        /// return a specific Skin
        /// </summary>
        /// <param name="skinStr"></param>
        /// <returns></returns>
        public Skin GetSkin(string skinStr)
        {
            Skin skin;
            if (skinAssociations.TryGetValue(skinStr, out skin) == false)
            {
                throw new System.ArgumentNullException();
            }
            return skin;
        }

        /// <summary>
        /// load all the skins
        /// </summary>
        void LoadSkin()
        {
            skinAssociations.Add("skin_menu", GenerateSkinMenu());

        }

        /// <summary>
        /// return a specific font
        /// </summary>
        /// <param name="fontStr"></param>
        /// <returns></returns>
        public Font GetBitmapFont(string fontStr)
        {
            Font font;
            if (fontAssociations.TryGetValue(fontStr, out font) == false)
            {
                throw new System.ArgumentNullException();
            }
            return font;
        }
        /// <summary>
        /// load all the fonts
        /// </summary>
        void LoadBitmapFont()
        {
            fontAssociations.Add("scoreboard_font.TTF", new Font("scoreboard_font.TTF"));
            fontAssociations.Add("agency-fb.ttf", new Font("agency-fb.ttf"));

        }

        /// <summary>
        /// return a specific textureAtlas
        /// </summary>
        /// <param name="textureAtlasStr"></param>
        /// <returns></returns>
        public TextureAtlas GetTextureAtlas(string textureAtlasStr)
        {
            TextureAtlas textureAtlas;
            if (textureAtlasAssociations.TryGetValue(textureAtlasStr, out textureAtlas) == false)
            {
                throw new System.ArgumentNullException();
            }
            return textureAtlas;
        }

        /// <summary>
        /// load all the textureatlas
        /// </summary>
        void LoadTextureAtlas()
        {
            textureAtlasAssociations.Add("pinkAndBluButtons.atlas", new TextureAtlas("pinkAndBluButtons.atlas"));
            textureAtlasAssociations.Add("quantum-horizon-ui.atlas", new TextureAtlas("quantum-horizon-ui.atlas"));

        }

        /// <summary>
        /// return a specific json
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public Json GetJson(string jsonStr)
        {
            Json json;
            if (jsonAssociations.TryGetValue(jsonStr, out json) == false)
            {
                throw new System.ArgumentNullException();
            }
            return json;
        }

        /// <summary>
        /// load all the json
        /// </summary>
        void LoadJson()
        {
            jsonAssociations.Add("quantum-horizon-ui.json", new Json("quantum-horizon-ui.json"));

        }

        Font GenerateFontMenu()
        {
            generator = GetBitmapFont("agency-fb.ttf");
            FreeTypeFontParameter parameter = new FreeTypeFontParameter();
            parameter.Size = FONT_SIZE_MENU;
            parameter.BorderWidth = fontBorderWidth;
            parameter.Color = FONT_COLOR;
            Font font = generator.GenerateFont(parameter);
            font.SetLinearFilter();
            return font;
        }

        /// <summary>
        /// create the font for the scoreboard
        /// </summary>
        /// <returns></returns>
        public Font GenerateFontScoreboard()
        {
            generator = GetBitmapFont("scoreboard_font.TTF");
            FreeTypeFontParameter parameter = new FreeTypeFontParameter();
            parameter.Size = FONT_SIZE;
            parameter.Color = ConsoleColor.White;
            parameter.ShadowColor = ConsoleColor.Black;
            parameter.ShadowOffsetX = 2;
            Font fontScoreboard = generator.GenerateFont(parameter);
            fontScoreboard.SetLinearFilter();
            return fontScoreboard;
        }

        Skin GenerateSkinMenu()
        {
            Skin s1 = new Skin();
            Font font = GenerateFontMenu();
            s1.Add("font", font);
            s1.Add("title", font);
            s1.AddRegions(GetTextureAtlas("quantum-horizon-ui.atlas"));
            s1.Load(GetJson("quantum-horizon-ui.json"));
            return s1;
        }

        /// <summary>
        /// load all the resources
        /// </summary>
        public void LoadAll()
        {
            if (!areLoaded)
            {
                LoadTexture();
                LoadTextureAtlas();
                LoadBitmapFont();
                LoadJson();
                LoadSkin();
                areLoaded = true;
            }
        }

        /// <summary>
        /// release all the resources
        /// </summary>
        public void dispose()
        {
            if (areLoaded)
            {
                new List<Texture>(textureAssociations.Values.ToList()).ForEach(i => i.Dispose());
                new List<TextureAtlas>(textureAtlasAssociations.Values.ToList()).ForEach(i => i.Dispose());
                new List<Font>(fontAssociations.Values.ToList()).ForEach(i => i.Dispose());
                areLoaded = false;
            }
        }

    }
}
