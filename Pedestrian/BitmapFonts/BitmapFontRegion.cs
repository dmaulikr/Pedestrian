using Pedestrian.TextureAtlases;

namespace Pedestrian.BitmapFonts
{
    public class BitmapFontRegion
    {
        public BitmapFontRegion(TextureRegion2D textureRegion, int character, int xOffset, int yOffset, int xAdvance)
        {
            TextureRegion = textureRegion;
            Character = character;
            XOffset = xOffset;
            YOffset = yOffset;
            XAdvance = xAdvance;
        }

        public int Character { get; set; }
        public TextureRegion2D TextureRegion { get; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public int XAdvance { get; set; }

        public int Width => TextureRegion.Width;

        public int Height => TextureRegion.Height;
    }
}