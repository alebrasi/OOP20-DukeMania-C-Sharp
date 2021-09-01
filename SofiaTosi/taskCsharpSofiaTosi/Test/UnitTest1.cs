using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using taskCsharpSofiaTosi;
using static taskCsharpSofiaTosi.LibgdxGraphics;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //texture
            AssetsManager am = AssetsManager.GetInstance();
            Texture _textureNote = am.GetTexture("note.png");
            Assert.IsTrue(_textureNote.Str == "note.png");
            Texture _textureButtons = am.GetTexture("pinkAndBluButtons.png");
            Assert.IsTrue(_textureButtons.Str == "pinkAndBluButtons.png");
            Texture _textureBackground = am.GetTexture("background.png");
            Assert.IsTrue(_textureBackground.Str == "background.png");
            Texture _textureDukeMania = am.GetTexture("DukeMania.png");
            Assert.IsTrue(_textureDukeMania.Str == "DukeMania.png");
            Texture _textureBlueBackground = am.GetTexture("blueBackground.png");
            Assert.IsTrue(_textureBlueBackground.Str == "blueBackground.png");
            Texture _textureSpark = am.GetTexture("blueSpark.png");
            Assert.IsTrue(_textureSpark.Str == "blueSpark.png");
            try
            {
                Texture _textureFake = am.GetTexture("DukeManiaFake.png");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }

            //textureAtlas
            TextureAtlas _atlasQuantum = am.GetTextureAtlas("quantum-horizon-ui.atlas");
            Assert.IsTrue(_atlasQuantum.Str == "quantum-horizon-ui.atlas");
            TextureAtlas _atlasButtons= am.GetTextureAtlas("pinkAndBluButtons.atlas");
            Assert.IsTrue(_atlasButtons.Str == "pinkAndBluButtons.atlas");
            try
            {
                TextureAtlas _atlasFake = am.GetTextureAtlas("atlasFake.atlas");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }

            //json
            Json _jsonQuantum = am.GetJson("quantum-horizon-ui.json");
            Assert.IsTrue(_jsonQuantum.Str == "quantum-horizon-ui.json");
            try
            {
                Json _jsonFake = am.GetJson("jsonFake.json");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }

            //font
            Font _fontScoreboard = am.GetBitmapFont("scoreboard_font.TTF");
            Assert.IsTrue(_fontScoreboard.Str == "scoreboard_font.TTF");
            Font _fontMenu = am.GetBitmapFont("agency-fb.ttf");
            Assert.IsTrue(_fontMenu.Str == "agency-fb.ttf");
            try
            {
                Font _fontFake = am.GetBitmapFont("fontFake.ttf");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }
        }
    }
}
