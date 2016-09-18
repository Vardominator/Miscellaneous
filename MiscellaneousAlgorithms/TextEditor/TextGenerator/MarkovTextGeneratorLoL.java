package textgen;

import java.util.LinkedList;
import java.util.List;
import java.util.ListIterator;
import java.util.Random;

/** 
 * An implementation of the MTG interface that uses a list of lists.
 * @author UC San Diego Intermediate Programming MOOC team 
 * 
 * Methods implemented by Varderes Barsegyan
 * 
 */
public class MarkovTextGeneratorLoL implements MarkovTextGenerator {

	// The list of words with their next words
	private List<ListNode> wordList; 
	
	// The starting "word"
	private String starter;
	
	// The random number generator
	private Random rnGenerator;
	
	public MarkovTextGeneratorLoL(Random generator)
	{
		wordList = new LinkedList<ListNode>();
		starter = "";
		rnGenerator = generator;
	}
	
	
	/** Train the generator by adding the sourceText */
	@Override
	public void train(String sourceText)
	{
		// TODO: Implement this method
		//System.out.println(sourceText);
		if("".equals(sourceText)) {
			System.out.println("No words in text");
		}
		
		else {
			
			String[] words = sourceText.split("[\\s]+");
			
			starter = words[0];
			//ListNode prevNode = new ListNode(starter);
			String prevWord = starter;
			//wordList.add(prevNode);
			ListNode prevNode = new ListNode(prevWord);
	
			int j = 0;
			
			int k = 0;
			
			boolean c = false;
	
			// starting from the second word
			for (int i = 1; i < words.length; i++) {
				
				for (j = 0; j < wordList.size(); j++) {
					if (wordList.get(j).getWord().equals(prevWord)) {
						c = true;	
						break;
					}
					else {
						c = false;	
					}
					k++;
				}
				
				if (c == true) {
					
					ListNode oldNode = wordList.get(k);
					oldNode.addNextWord(words[i]);
					
					if(k == wordList.size()-1) {
						oldNode.addNextWord(starter);
					}
				}
				
				else {
					ListNode newNode = new ListNode(prevWord);
					wordList.add(newNode);
					newNode.addNextWord(words[i]);
					
				}
			
				k = 0;
				prevWord = words[i];
				//System.out.println(prevWord);
	
			}
	
			for (int i = 0; i < wordList.size(); i++) {
				if (wordList.get(i).getWord().equals(words[words.length - 1])){
					wordList.get(i).addNextWord(starter);
					break;
				}
				else if (i == wordList.size() - 1) {
					ListNode lastNode = new ListNode(words[words.length-1]);
					wordList.add(lastNode);
					lastNode.addNextWord(starter);
					break;
					
				}
				
			}
			
		}
		
		
	}
	
	/** 
	 * Generate the number of words requested.
	 */
	@Override
	public String generateText(int numWords) {
	    // TODO: Implement this method

		if (wordList.isEmpty()) {
			return "No trained data";
		}
		if (numWords < 1) {
			return "";
		}
		
		else {
			System.out.println(wordList.size());
			ListNode currentNode = wordList.get(0);
	
			String currentWord = currentNode.getWord();
			String out = "";
			int index = 0;
			int check = 0;
			
			while (check < numWords){
			
				for (int i = 0; i < wordList.size(); i++) {
					
					if(currentWord.equals(wordList.get(i).getWord())){
						
						currentNode = wordList.get(i);
						index = i;
						break;
						
					}
					
				}
				
				currentNode = wordList.get(index);
				
				currentWord = currentNode.getRandomNextWord(rnGenerator);
				currentWord = currentWord.trim();
				out = out + currentWord + " ";
	
				//out = out.replaceAll("\\s+", " ");
				if (!currentWord.equals("")) {
					check++;
				}
				
			}
			String finalOut = out.trim().replaceAll(" +", " ");
			String[] eachWord = finalOut.split("\\s+");
			System.out.println(eachWord.length);
			return finalOut;
			
		}
	}
	
	
	// Can be helpful for debugging
	@Override
	public String toString()
	{
		String toReturn = "";
		for (ListNode n : wordList)
		{
			toReturn += n.toString();
		}
		return toReturn;
	}
	
	/** Retrain the generator from scratch on the source text */
	@Override
	public void retrain(String sourceText)
	{
		// TODO: Implement this method.
		
		wordList.clear();
		starter = "";
		
		if("".equals(sourceText)) {
			System.out.println("No words in text");
		}
		
		else {
			
			String[] words = sourceText.split("[\\s]+");
			
			starter = words[0];
			//ListNode prevNode = new ListNode(starter);
			String prevWord = starter;
			//wordList.add(prevNode);
	
			int j = 0;
			
			int k = 0;
			
			boolean c = false;
	
			// starting from the second word
			for (int i = 1; i < words.length; i++) {
				
				for (j = 0; j < wordList.size(); j++) {
					if (wordList.get(j).getWord().equals(prevWord)) {
						c = true;	
						break;
					}
					else {
						c = false;	
					}
					k++;
				}
				
				if (c == true) {
					
					ListNode oldNode = wordList.get(k);
					oldNode.addNextWord(words[i]);
					
					if(k == wordList.size()-1) {
						oldNode.addNextWord(starter);
					}
				}
				
				else {
					ListNode newNode = new ListNode(prevWord);
					wordList.add(newNode);
					newNode.addNextWord(words[i]);
					
				}
			
				k = 0;
				prevWord = words[i];
	
			}
	
			for (int i = 0; i < wordList.size(); i++) {
				if (wordList.get(i).getWord().equals(words[words.length - 1])){
					wordList.get(i).addNextWord(starter);
					break;
				}
				else if (i == wordList.size() - 1) {
					ListNode lastNode = new ListNode(words[words.length-1]);
					wordList.add(lastNode);
					lastNode.addNextWord(starter);
					break;
					
				}
				
			}
			
		}
		
	}
	
	// TODO: Add any private helper methods you need here.
	
	
	/**
	 * This is a minimal set of tests.  Note that it can be difficult
	 * to test methods/classes with randomized behavior.   
	 * @param args
	 */
	public static void main(String[] args)
	{
		// feed the generator a fixed random value for repeatable behavior
		MarkovTextGeneratorLoL gen = new MarkovTextGeneratorLoL(new Random(42));
		String textString = "Hello.  Hello there.  This is a test.  Hello there.  Hello Bob.  Test again.";
		System.out.println(textString);
		
		gen.train(textString);
		System.out.println(gen);
		System.out.println(gen.generateText(10));
		String textString2 = "You say yes, I say no, "+
				"You say stop, and I say go, go, go, "+
				"Oh no. You say goodbye and I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello. "+
				"I say high, you say low, "+
				"You say why, and I say I don't know. "+
				"Oh no. "+
				"You say goodbye and I say hello, hello, hello. "+
				"I don't know why you say goodbye, I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello. "+
				"Why, why, why, why, why, why, "+
				"Do you say goodbye. "+
				"Oh no. "+
				"You say goodbye and I say hello, hello, hello. "+
				"I don't know why you say goodbye, I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello. "+
				"You say yes, I say no, "+
				"You say stop and I say go, go, go. "+
				"Oh, oh no. "+
				"You say goodbye and I say hello, hello, hello. "+
				"I don't know why you say goodbye, I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello, hello, hello, "+
				"I don't know why you say goodbye, I say hello, hello, hello,";
		
		
		System.out.println(textString2);
		gen.retrain(textString2);
		System.out.println(gen);
		System.out.println(gen.generateText(500));
	}

}

/** Links a word to the next words in the list 
 * You should use this class in your implementation. */
class ListNode
{
    // The word that is linking to the next words
	private String word;
	
	// The next words that could follow it
	protected List<String> nextWords;
	
	ListNode(String word)
	{
		this.word = word;
		nextWords = new LinkedList<String>();
	}
	
	public String getWord()
	{
		return word;
	}

	public void addNextWord(String nextWord)
	{
		nextWords.add(nextWord);
	}
	
	public String getRandomNextWord(Random generator)
	{
		// TODO: Implement this method
	    // The random number generator should be passed from 
	    // the MarkovTextGeneratorLoL class
		int randInt = generator.nextInt((nextWords.size() - 0) + 1);
		
		//System.out.println("Random number: " + randInt);
		//System.out.println("nextWords size: " + nextWords.size());
		String randWord = "";
		
		for (int i = 0; i < randInt; i++) {
			randWord = nextWords.get(i);
			
		}
		
	    return randWord;
	}

	
	public void clearWordList() {
		nextWords.clear();
		System.out.println(nextWords.size());
	}
	
	public String toString()
	{
		
		String toReturn = word + ": ";
		for (String s : nextWords) {
			toReturn += s + "->";
		}
		toReturn += "\n";
		return toReturn;
	}
	
}


