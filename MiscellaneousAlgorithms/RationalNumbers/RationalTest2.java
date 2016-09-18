/*
 * Varderes Barsegyan
 * Project 15: Problem 2
 * Due: 8_10_15
 */

public class RationalTest2 {
	
	public static void main(String args[]) {
		
		int n = 9;
		Rational result = new Rational();
		Rational summation;
		
		// I put the first iteration here so that there
		// would not be an extra plus sign at the end.
		summation = new Rational(1, 1);
		System.out.print(summation);
		result = summation;
		
		for(int i = 2; i <= n; i++) {
			
			summation = new Rational(1,i);
			result = result.add(summation);
			System.out.print(" + " + summation);
		}
		
		System.out.println(" = " + result);
	}
}



// Rationaal Class
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
