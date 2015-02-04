package com.snake.game;
import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random generateRandomNumber;
	private Point applePosition;
	private Color appleColor;
	
	public Apple(Snake snake) {
		applePosition = generateApple(snake);
		appleColor = Color.RED;		
	}
	
	private Point generateApple(Snake snake) {
		generateRandomNumber = new Random();
		int x = generateRandomNumber.nextInt(30) * 20; 
		int y = generateRandomNumber.nextInt(30) * 20;
		for (Point snakePoint : snake.snakeBody) {
			if (x == snakePoint.getCoordinateX() || y == snakePoint.getCoordinateY()) {
				return generateApple(snake);				
			}
		}
		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
		applePosition.draw(g, appleColor);
	}	
	
	public Point daiTo4ka(){
		return applePosition;
	}
}
