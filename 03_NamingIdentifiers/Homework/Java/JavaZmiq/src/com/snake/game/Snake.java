package com.snake.game;
import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake {
	private LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX;
	private int velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100)); 
		snakeBody.add(new Point(280, 100)); 
		snakeBody.add(new Point(260, 100)); 
		snakeBody.add(new Point(240, 100)); 
		snakeBody.add(new Point(220, 100)); 
		snakeBody.add(new Point(200, 100)); 
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void drawSnake(Graphics graphics) {		
		for (Point point : this.snakeBody) {
			point.draw(graphics, snakeColor);
		}
	}
	
	public LinkedList<Point> getSnakeBody() {
		return snakeBody;
	}

	public int getVelX() {
		return velocityX;
	}

	public int getVelY() {
		return velocityY;
	}

	public void moveSnake() {
		Point newSnakePosition = new Point((snakeBody.get(0).getCoordinateX() + velocityX), (snakeBody.get(0).getCoordinateY() + velocityY));
		
		if (newSnakePosition.getCoordinateX() > GameEngine.WIDTH - 20) {
		 	GameEngine.gameRunning = false;
		} else if (newSnakePosition.getCoordinateX() < 0) {
			GameEngine.gameRunning = false;
		} else if (newSnakePosition.getCoordinateY() < 0) {
			GameEngine.gameRunning = false;
		} else if (newSnakePosition.getCoordinateY() > GameEngine.HEIGHT - 20) {
			GameEngine.gameRunning = false;
		} else if (GameEngine.apple.getApplePosition().equals(newSnakePosition)) {
			snakeBody.add(GameEngine.apple.getApplePosition());
			GameEngine.apple = new Apple(this);
			GameEngine.score += 50;
		} else if (snakeBody.contains(newSnakePosition)) {
			GameEngine.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, newSnakePosition);
	}

	public void setVelX(int velX) {
		this.velocityX = velX;
	}

	public void setVelY(int velY) {
		this.velocityY = velY;
	}
	
	
}
