using System;
using SS14.Client.Graphics;

namespace SS14.Client.Interfaces.Graphics
{
    public interface IFontManager
    {

    }

    internal interface IFontManagerInternal : IFontManager
    {
        IFontFaceHandle Load(ReadOnlySpan<byte> data);
        IFontInstanceHandle MakeInstance(IFontFaceHandle handle, int size);
        void Initialize();
    }

    internal interface IFontFaceHandle
    {

    }

    internal interface IFontInstanceHandle
    {
        Texture GetCharTexture(char chr);
        CharMetrics? GetCharMetrics(char chr);
        int Ascent { get; }
        int Descent { get; }
        int Height { get; }
        int LineHeight { get; }
    }

    /// <summary>
    ///     Metrics for a single glyph in a font.
    ///     Refer to https://www.freetype.org/freetype2/docs/glyphs/glyphs-3.html for more information.
    /// </summary>
    public readonly struct CharMetrics
    {
        /// <summary>
        ///     The horizontal distance between the origin and the left of the drawn glyph.
        /// </summary>
        public readonly int BearingX;

        /// <summary>
        ///     The vertical distance between the origin and the top of the drawn glyph.
        /// </summary>
        public readonly int BearingY;

        /// <summary>
        ///     How much to advance the origin after drawing the glyph.
        /// </summary>
        public readonly int Advance;

        /// <summary>
        ///     The width of the drawn glyph.
        /// </summary>
        public readonly int Width;

        /// <summary>
        ///     The height of the drawn glyph.
        /// </summary>
        public readonly int Height;

        public CharMetrics(int bearingX, int bearingY, int advance, int width, int height)
        {
            BearingX = bearingX;
            BearingY = bearingY;
            Advance = advance;
            Width = width;
            Height = height;
        }
    }
}
