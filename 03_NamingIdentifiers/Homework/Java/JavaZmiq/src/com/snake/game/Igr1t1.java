package com.snake.game;
import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
public class Igr1t1 extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int score;
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension windowSize = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;
	
	public void paint(Graphics graphics){
		this.setPreferredSize(windowSize);
		globalGraphics = graphics.create();
		score = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void run(){
		while(gameRunning){
			snake.moveSnake();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
			}
		}
	}
	
	public Igr1t1(){	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	public void render(Graphics graphics){
		graphics.clearRect(0, 0, WIDTH, HEIGHT+25);
		
		graphics.drawRect(0, 0, WIDTH, HEIGHT);			
		snake.drawSnake(graphics);
		apple.drawApple(graphics);
		graphics.drawString("score= " + score, 10, HEIGHT + 25);		
	}
}

