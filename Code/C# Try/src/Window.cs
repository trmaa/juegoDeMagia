using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

public class Window : Form {
    public vec2 viewport;
    public vec2 aspectratio;

    public vec2 scale = new vec2(0,0);

    private readonly object graphicsLock = new object();
    private SolidBrush brush = new SolidBrush(Color.Black);

    public Window(String title, vec2 size){
        this.Text = title;
        this.Size = new Size((int)size.x, (int)size.y);

        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;

        this.scale.x = (float)Screen.PrimaryScreen.Bounds.Width / size.x;
        this.scale.y = (float)Screen.PrimaryScreen.Bounds.Height / size.y;

        this.viewport = size;
        this.aspectratio = new vec2(this.ClientSize.Width, this.ClientSize.Height) / this.viewport;

        this.Paint += (sender, e) => repaint(e.Graphics);

        this.DoubleBuffered = true;
    }

    public void print(Graphics g, Color col, vec2 p, vec2 size){
        lock (brush) {
            brush.Color = col;
            g.FillRectangle(brush, (p.x-1)*this.scale.x, (p.y-1)*this.scale.y, size.x*this.scale.x, size.y*this.scale.y);
        }
    }

    public void println(Graphics g, vec2 pointo, vec2 pointf, float thich, Color color){
        Pen pen = new Pen(color, thich);
        g.DrawLine(pen, (int)(pointo.x)*this.scale.x, (int)(pointo.y)*this.scale.y, (int)(pointf.x)*this.scale.x, (int)(pointf.y)*this.scale.y);
    }

    public void repaint(Graphics g) {
        vec2 size = new vec2(this.ClientSize.Width, this.ClientSize.Height);
        this.aspectratio = size / this.viewport;
    }
}