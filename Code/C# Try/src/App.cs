using System;
using System.Windows.Forms;
using System.Diagnostics;

public class App {
    public static Window window = new Window("Renderer",new vec2(800,600));

    public static Controler inputs = new Controler();

    public static float deltaTime;
    public static Stopwatch stopwatch = new Stopwatch();

    public static void Main() {
        Timer timer = new Timer();
        timer.Interval = 160;
        timer.Tick += (sender, e) => App.update();
        timer.Start();

        App.stopwatch.Start();
        Application.Run(App.window);
    }

    private static void update(){
        App.deltaTime = (float)App.stopwatch.Elapsed.TotalSeconds;
        App.stopwatch.Restart();

        App.window.Invalidate();
    }
};