/**
 * This project implements the four-square cipher, allowing for
 * encryption and decryption.
 *
 * Trey Moddelmog - Section B
*/

public class Proj7 {
	public static void main(String[] args) {

// Complete the MAIN method
	// Get the KEYS and MESSAGE using IO class
		
		IO io = new IO();

		Square square = new Square();

		String firstKey = io.firstKey();
		String secondKey = io.secondKey();
		String message = "";

		Cipher cipher = new Cipher(firstKey, secondKey);

		if (square.strContains(firstKey, 'Q') || square.strContains(secondKey, 'Q')) {
			io.printError("Key cannot contain a Q.");
		}

		if (io.encryptOrDecrypt() == 'd') {

			message = io.message(false);

			if (square.strContains(message, 'Q')) {
				io.printError("Message cannot contain Q.");
			}
			
			if ((message.length() % 2) > 0) {
				io.printError("Cannot be odd number of characters");
			}

			io.printResults(cipher.decrypt(message), false);

		}

		else {
			
			message = io.message(true);

			if (square.strContains(message, 'Q')) {
				io.printError("Message cannot contain Q.");
			}
			
			if ((message.length() % 2) > 0) {
				io.printError("Message cannot be odd number of characters");
			}

			io.printResults(cipher.encrypt(message), true);
		}

 } // end main
} // end class