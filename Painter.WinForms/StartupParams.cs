using System;
using System.Collections.Generic;
using System.Drawing;
using Painter.WinForms.Tools.DrawingTools;
using Rectangle = Painter.WinForms.Tools.DrawingTools.Rectangle;

namespace Painter.WinForms
{
    /// <summary>
    /// Represent application settings
    /// </summary>
    public class StartupParams
    {
        #region Singleton
        private static readonly Lazy<StartupParams> _instance = new Lazy<StartupParams>(() => new StartupParams());
        public static StartupParams Instance() => _instance.Value;
        #endregion

        /// <summary>
        /// Border figure color
        /// </summary>
        public Color CurrentBorderColor { get; set; } = Color.Black;

        /// <summary>
        /// Back figure color
        /// </summary>
        public Color CurrentBackgroundColor { get; set; } = Color.AliceBlue;

        /// <summary>
        /// Selected drawing tool
        /// </summary>
        public ToolsBase CurrentTool { get; set; }

        /// <summary>
        /// All <see cref="ToolsBase"/> tools
        /// </summary>
        public IEnumerable<ToolsBase> Tools { get; } = new List<ToolsBase> { new Pencil(), new Line(), new Rectangle(), new Circle() };
    }
}
