package com.snake.game;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyEventListener implements KeyListener {

	@Override
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		Snake snake = GameEngine.snake;

		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if (snake.getVelY() != 20) {
				snake.setVelX(0);
				snake.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if (snake.getVelY() != -20) {
				snake.setVelX(0);
				snake.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if (snake.getVelX() != -20) {
				snake.setVelX(20);
				snake.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if (snake.getVelX() != 20) {
				snake.setVelX(-20);
				snake.setVelY(0);
			}
		}
		// Other controls
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {
	}

	@Override
	public void keyTyped(KeyEvent e) {

	}

}
