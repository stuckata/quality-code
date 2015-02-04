package com.snake.game;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int coordinateX, coordinateY;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p) {
		this(p.coordinateX, p.coordinateY);
	}
	
	public Point(int x, int y) {
		this.coordinateX = x;
		this.coordinateY = y;
	}	
		
	public int getCoordinateX() {
		return coordinateX;
	}
	public void setCoordinateX(int x) {
		this.coordinateX = x;
	}
	public int getCoordinateY() {
		return coordinateY;
	}
	public void setCoordinateY(int y) {
		this.coordinateY = y;
	}
	
	public void draw(Graphics graphics, Color color) {
		graphics.setColor(Color.BLACK);
		graphics.fillRect(coordinateX, coordinateY, WIDTH, HEIGHT);
		graphics.setColor(color);
		graphics.fillRect(coordinateX+1, coordinateY+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + coordinateX + ",y=" + coordinateY + "]";
	}
	
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point)object;
            return (coordinateX == point.coordinateX) && (coordinateY == point.coordinateY);
        }
        return false;
    }
}
