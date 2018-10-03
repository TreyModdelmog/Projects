/**
 * @Original Author: Tony Gaddis
 * @Modified by: Dr. Lang
 * @version Project 8 
 * 
 * Textbook.java - Provided to the student
 * Class stores data about the textbook required for the course
 * which includes title, author and price
 *
 * Includes a regular constructor and a constructor used to make a copy 
 * of a created textbook object as well as a toString method
*/

import java.text.*;


public class TextBook
{
   private String title;    // Title of the book
   private String author;   // Author's last name
   private double price; 	// Wholesale cost of the book

   /**
      This constructor initializes the title,
      author, and price fields
      @param textTitle The book's title.
      @param auth The author's name.
      @param price Wholesale cost.
   */
   public TextBook(String t, String a,
                   double p)
   {
      title = t;
      author = a;
      price = p;
   }

   /**
      The copy constructor initializes the object
      as a copy of another TextBook object.
      @param object2 The object to copy.
   */
   public TextBook(TextBook object2)
   {
      title = object2.title;
      author = object2.author;
      price = object2.price;
   }

 
   /**
      toString method
      @return A string containing textbook information.
   */
   public String toString()
   {

      DecimalFormat df = new DecimalFormat("$##0.00");

      // Create a string representing the object.
      String str = "Title: " + title +
                   "\nAuthor: " + author +
                   "\nWhole Sale Price: " + df.format(price);

      // Return the string.
      return str;
   }
}