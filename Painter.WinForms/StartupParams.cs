using System;
using System.Collections.Generic;
using System.Drawing;
using Painter.WinForms.Tools.DrawingTools;
using Rectangle = Painter.WinForms.Tools.DrawingTools.Rectangle;

namespace Painter.WinForms
{
    public class StartupParams
    {
        private static readonly Lazy<StartupParams> _instance = new Lazy<StartupParams>(() => new StartupParams());
        public static StartupParams Instance() => _instance.Value;

        public Color CurrentBorderColor { get; set; } = Color.Black;
        public Color CurrentBackgroundColor { get; set; } = Color.AliceBlue;
        public ToolsBase CurrentTool { get; set; }
        public IEnumerable<ToolsBase> Tools { get; } = new List<ToolsBase> { new Pencil(), new Line(), new Rectangle(), new Circle() };
    }
}
