/*
 * Author: Varderes Barsegyan
 * 
 * Title: Java Trie Implementation
 * 
 * Description: Simple trie data structure implementation.
 * 
 */

import java.util.*;

class TrieNode {
	
	char c;
	HashMap<Character, TrieNode> children = new HashMap<Character, TrieNode> ();
	boolean isLeaf;
	
	public TrieNode() {
		
	}
	
	public TrieNode(char c) {
		this.c = c;
	}
	
}










