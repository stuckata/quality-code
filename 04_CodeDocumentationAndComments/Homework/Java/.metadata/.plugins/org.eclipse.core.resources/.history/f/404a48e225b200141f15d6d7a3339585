package com.snake.game;
import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static final Random RANDOM_NUMBER_GENERATOR = new Random();
	private Color appleColor;
	private Point applePosition;
	
	public Apple(Snake snake) {
		applePosition = generateApple(snake);
		appleColor = Color.RED;		
	}
	
	public void drawApple(Graphics g){
		applePosition.draw(g, appleColor);
	}
	
	private Point generateApple(Snake snake) {
		int x = RANDOM_NUMBER_GENERATOR.nextInt(30) * 20; 
		int y = RANDOM_NUMBER_GENERATOR.nextInt(30) * 20;
		for (Point snakePoint : snake.getSnakeBody()) {
			if (x == snakePoint.getCoordinateX() || y == snakePoint.getCoordinateY()) {
				return generateApple(snake);				
			}
		}
		return new Point(x, y);
	}	
	
	public Point getApplePosition(){
		return applePosition;
	}
}
