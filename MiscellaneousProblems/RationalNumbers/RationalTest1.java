/*
 * Varderes Barsegyan
 * Project 15: Problem 3
 * Due: 8_10_15 
 */
 
public class RationalTest1 {

	public static void main(String args[]) {
		
		Rational[] randRationalArray = new Rational[10];
		int randNum;
		int randDen;
		
		for (int i = 0; i < randRationalArray.length; i++) {
			
			randNum = 1 + (int)(Math.random()*100);
			randDen = 1 + (int)(Math.random()*100);
			
			randRationalArray[i] = new Rational(randNum, randDen);
			
		}
		
		printList(randRationalArray);
		sort(randRationalArray);
		
	}
	
	
	public static void printList(Rational[] randArray) {
		
		System.out.print("Random rational numbers: ");
		for(int i = 0; i < randArray.length; i++) {
			System.out.print(randArray[i] + " ");
		}
		System.out.println();
	
	}
	
	public static void sort(Rational[] randArray) {
		
		int minIndex;
		double num1;
		double den1;
		double num2;
		double den2;
		Rational temp;
		
		System.out.print("Sorted Rational Numbers: ");
		for(int i = 0; i < randArray.length; i++) {
			
			minIndex = i;
			for(int j = i + 1; j < randArray.length; j++) {	
				
				num1 = randArray[j].getNumerator();
				den1 = randArray[j].getDenominator();
				
				num2 = randArray[minIndex].getNumerator();
				den2 = randArray[minIndex].getDenominator();
				
				if(num1/den1 < num2/den2) {			
					minIndex = j;	
				}
			}
			
			if(minIndex != i) {			
				temp = randArray[minIndex];
				randArray[minIndex] = randArray[i];
				randArray[i] = temp;	
			}
			System.out.print(randArray[i] + " ");
		}
		
	}
	
}


class Rational {
	
	private int numerator;
	private int denominator;
	
	Rational() {
		
		numerator = 0;
		denominator = 1;
		
	}
	
	Rational(int n, int d) {
		
		numerator = n;
		denominator = d;
		
		int commonD;
		
		if (numerator != 0) {
			commonD = gcd(numerator, denominator);
			
			numerator = numerator/ commonD;
			denominator = denominator / commonD;
		}
		
	}
	
	private int gcd(int n, int d) {
		
		while(n != d) {
			if(n > d) {
				n = n - d;
			}
			else {
				d = d - n;
			}
		}
		return n;
	}
	
	public int getNumerator(){
		return numerator;
	}
	
	public int getDenominator(){
		return denominator;
	}
	
  	public void setNumerator(int n){
		numerator = n;
	}
	
	public void setDenominator(int d){
		denominator = d;
	}

	
	public Rational add(Rational r) {
		
		int newD = denominator * r.denominator;
		int newN1 = r.numerator * denominator;
		int newN2 = numerator * r.denominator;
		int newN = newN1 + newN2;
		
		return new Rational(newN, newD);
	}
	
	public Rational subtract(Rational r) {
		
		int newD = denominator * r.denominator;
		int newN1 = r.numerator * denominator;
		int newN2 = numerator * r.denominator;
		int newN = newN2 - newN1;
		
		return new Rational(newN, newD);
	}

	public Rational divide(Rational r) {
		
		int newN = numerator * r.denominator;
		int newD = denominator * r.numerator;
		return new Rational(newN, newD);
	}
	
	public Rational multiply(Rational r) {
		
		int newN = numerator * r.numerator;
		int newD = denominator * r.denominator;
		return new Rational(newN, newD);
	}
	
	public Boolean equals(Rational r) {
		return ((numerator/denominator) == (r.numerator/r.denominator));
	}
	
	public String toString(){
		
		if(denominator == 1) {
			return (numerator + "");
		}
		else {
			return (numerator + "" + "/" + denominator + "");
		}
	}
		
}

