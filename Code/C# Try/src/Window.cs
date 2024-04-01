using System;
using System.Drawing;
using System.Windows.Forms;

public class Window : Form {
    private const int VirtualWidth = 192*3;
    private const int VirtualHeight = 108*3;
    private float scaleX;
    private float scaleY;

    public Window(String title, vec2 size){
        this.Text = title;

        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;

        this.scaleX = (float)Screen.PrimaryScreen.Bounds.Width / VirtualWidth;
        this.scaleY = (float)Screen.PrimaryScreen.Bounds.Height / VirtualHeight;

        this.Paint += (sender, e) => repaint(e.Graphics);

        this.DoubleBuffered = true;
    }

    public void print(Graphics g, Color col, vec2 p, vec2 size){
        using (SolidBrush brush = new SolidBrush(col)) {
            g.FillRectangle(brush, p.x * scaleX, p.y * scaleY, size.x * scaleX, size.y * scaleY);
        }
    }

    public void println(Graphics g, vec2 pointo, vec2 pointf, float thich, Color color){
        using (Pen pen = new Pen(color, thich)) {
            g.DrawLine(pen, pointo.x * scaleX, pointo.y * scaleY, pointf.x * scaleX, pointf.y * scaleY);
        }
    }

    private void repaint(Graphics g) {
        this.print(g, Color.FromArgb(255, 0, 0, 0), new vec2(0, 0), new vec2(64, 64));
    }
}