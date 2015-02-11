package com.snake.game;

import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * The engine of the game. The engine is responsible for refreshing the game
 * field and drawing the game objects.
 * 
 * @author stu
 */
@SuppressWarnings("serial")
public class GameEngine extends Canvas implements Runnable {
	/** The height of the game field */
	public static final int HEIGHT = 600;
	/** The width of the game field */
	public static final int WIDTH = 600;

	/** {@link Apple} */
	public static Apple apple;
	/** This flag indicates if the game is running */
	public static boolean gameRunning = false;
	/** Keeps the player's score */
	public static int score;
	/** {@link Snake} */
	public static Snake snake;

	static {
		snake = new Snake();
		apple = new Apple(snake);
	}
	/** The dimensions of the game field */
	private static final Dimension WINDOW_SIZE = new Dimension(WIDTH, HEIGHT);

	/** {@link Graphics} */
	private Graphics globalGraphics;
	/** The thread which runs the game */
	private Thread runThread;

	/**
	 * Paints the game field
	 * 
	 * @see Canvas#paint(Graphics)
	 */
	@Override
	public void paint(Graphics graphics) {
		this.setPreferredSize(WINDOW_SIZE);
		globalGraphics = graphics.create();
		score = 0;

		if (runThread == null) {
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}

	/**
	 * Renders the game field
	 * 
	 * @param graphics
	 */
	public void render(Graphics graphics) {
		graphics.clearRect(0, 0, WIDTH, HEIGHT + 25);

		graphics.drawRect(0, 0, WIDTH, HEIGHT);
		snake.drawSnake(graphics);
		apple.drawApple(graphics);
		graphics.drawString("score= " + score, 10, HEIGHT + 25);
	}

	/**
	 * Refreshes the game field if the game is currently running
	 */
	@Override
	public void run() {
		while (gameRunning) {
			snake.moveSnake();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
				e.printStackTrace();
			}
		}
	}
}
