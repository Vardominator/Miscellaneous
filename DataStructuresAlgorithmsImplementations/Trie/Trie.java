/*
 * Author: Varderes Barsegyan
 * 
 * Title: Java Trie Implementation
 * 
 * Description: Simple trie data structure implementation.
 * 
 */

import java.util.*;


public class Trie {
	
	// Root node of the prefix tree
	private TrieNode root;
	
	// Constructor
	public Trie() {
		
		root = new TrieNode();
		
	}
	
	// Inserts a word into the trie
	public void insert (String word) {
		
		word = word.toLowerCase();
		
		// The initial hashmap contains the children of the root
		HashMap<Character, TrieNode> children = root.children;
		
		for (int i = 0; i < word.length(); i++) {

			char c = word.charAt(i);
			
			// Temporary trie node
			TrieNode t;
			
			// If one of the temporary trie node's children contain the key c
			if (children.containsKey(c)) {
				
				// Then get the children of that node
				t = children.get(c);
				
			}
			
			// If they do not
			else {
				
				// Then instantiate a new trie node setting the temporary node the newly instantiated node
				t = new TrieNode(c);
				
				children.put(c,  t);
				
			}
			
			// The children of interest is now the 
			children = t.children;
			
			// If we have reached the end of the loop
			if (i == word.length() - 1) {
				
				//That means the node that we are on is a leaf (has no children)
				t.isLeaf = true;
			}
			
		}
		
	}
	
	
	// Returns if the word is in the trie
	public boolean search(String word) {
		TrieNode t = searchNode(word);
		
		if(t != null && t.isLeaf) {
			return true;
		}
		else {
			return false;
		}
	}
	
	
	// Returns if there is any word in the trie that starts with the given prefix
	public boolean startsWith(String prefix) {
		
		if(searchNode(prefix) == null) {
			
			return false;
			
		}
		else {
			
			return true;
			
		}
		
	}
	
	
	public TrieNode searchNode(String str) {
		
		Map<Character, TrieNode> children = root.children;
		TrieNode t = null;
		
		for (int i = 0; i <str.length(); i++) {
			
			char c = str.charAt(i);
			
			if (children.containsKey(c)) {
				
				t = children.get(c);
				children = t.children;
				
			}
			else {
				
				return null;
				
			}
			
		}
		
		return t;
		
	}
	
}










