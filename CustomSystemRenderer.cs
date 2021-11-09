namespace CustomBrowser
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// This custom renderer removes the white border that Microsoft doesn't let us control and controls various styling options for the toolbar.
    /// </summary>
    public class CustomSystemRenderer: ToolStripSystemRenderer
    {
        /// <summary>
        /// Simply overrides the ToolStripBorder
        /// </summary>
        /// <param name="e">Event Arguments</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                
                switch (e.Item.Name)
                {
                    case "CloseWindowButton":
                        e.Graphics.FillRectangle(Brushes.DarkOrchid, rectangle);
                        e.Graphics.DrawRectangle(Pens.DarkOrchid, rectangle);
                        break;
                    default:
                        e.Graphics.FillRectangle(Brushes.Green, rectangle);
                        e.Graphics.DrawRectangle(Pens.Olive, rectangle);
                        break;
                }
            }
        }
    }
}
