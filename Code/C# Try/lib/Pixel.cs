using System;
using System.Drawing;

public class Pixel {
	public Color colorc = Color.FromArgb(255,255,0,0);
    public vec3 colorv = new vec3(0,0,0);
    public vec2 id = new vec2(0, 0);

    public Pixel(vec3 col ,vec2 id) {
        this.colorc = Color.FromArgb(255,(int)col.x,(int)col.y,(int)col.z);
        this.colorv = col;
        this.id = id;
    }

    public Color color(){
        this.colorc = Color.FromArgb(255,(int)this.colorv.x,(int)this.colorv.y,(int)this.colorv.z);
        return this.colorc;
    }
};