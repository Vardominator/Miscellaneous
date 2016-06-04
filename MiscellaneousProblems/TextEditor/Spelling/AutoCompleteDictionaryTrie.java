package spelling;

import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Set;
import java.util.Collection;
import java.util.HashMap;
import java.util.LinkedList;

/** 
 * An trie data structure that implements the Dictionary and the AutoComplete ADT
 * @author You
 *
 */
public class AutoCompleteDictionaryTrie implements  Dictionary, AutoComplete {

    private TrieNode root;
    private int size;
    
    private LinkedList<String> dict = new LinkedList<String> ();
    
    public AutoCompleteDictionaryTrie()
	{
		root = new TrieNode();
	}
	
	/** Insert a word into the trie.
	 * For the basic part of the assignment (part 2), you should ignore the word's case.
	 * That is, you should convert the string to all lower case as you insert it. */
	public boolean addWord(String word)
	{
	    //TODO: Implement this method.
		word = word.toLowerCase();
		
    	if (dict.contains(word)){
    		return false;
    	}

		dict.add(word);
		
		TrieNode t = root;
		
		int i = 0;
			
		if (word != null) {

			for (i = 0; i < word.length(); i++) {

				char ch = word.charAt(i);
				
				t.insert(ch);
				
				//if (i == word.length()-1) {
					
					//t.setEndsWord(true);

				//}		
				
				t = t.getChild(ch);
				if (t.insert(ch) == null) {
					t.setEndsWord(true);
					System.out.println("hello");
				}
				
			}		
		}
		
		return false;
		
	}
	
	/** 
	 * Return the number of words in the dictionary.  This is NOT necessarily the same
	 * as the number of TrieNodes in the trie.
	 */
	public int size()
	{
	    //TODO: Implement this method
    	if (dict.isEmpty()) {
    		//System.out.println("Size: " + dict.size());
    		return 0;
    	}
    	else {
    		//System.out.println("Size: " + dict.size());
    		return dict.size();
    	}

	}
	
	
	/** Returns whether the string is a word in the trie */
	@Override
	public boolean isWord(String s) 
	{
	    // TODO: Implement this method
		s = s.toLowerCase();
		//System.out.println(s);
		TrieNode t = searchNode(s);
		
		boolean contains = dict.contains(s);
		
		if (s.equals("")){
			return false;
		}
		
		if(contains == true) {
			return true;
		}
		else {
			return false;
		}
		
	}

	public TrieNode searchNode(String str) {
		
		str = str.toLowerCase();
		TrieNode t = null;
		Map<Character, TrieNode> children = root.children;
		
		if (str == "") {
			return root;
		}
		
		for (int i = 0; i < str.length(); i++) {
			char c = str.charAt(i);
			
			// If the children contains the character key c
			if(children.containsKey(c)) {
				
				// Then set the current node to that child 
				t = children.get(c);	
				// Set the children equal to the current node's children
				children = t.children;
			}
			
			else {
				return null;
			}
			
		}
		
		return t;

	}
	
	
	/** 
	 *  * Returns up to the n "best" predictions, including the word itself,
     * in terms of length
     * If this string is not in the trie, it returns null.
     * @param text The text to use at the word stem
     * @param n The maximum number of predictions desired.
     * @return A list containing the up to n best predictions
     */@Override
     public List<String> predictCompletions(String prefix, int numCompletions) 
     {
    	 // This method should implement the following algorithm:
    	 // 1. Find the stem in the trie.  If the stem does not appear in the trie, return an
    	 //    empty list
    	 // 2. Once the stem is found, perform a breadth first search to generate completions
    	 //    using the following algorithm:
    	 //    Create a queue (LinkedList) and add the node that completes the stem to the back
    	 //       of the list.
    	 //    Create a list of completions to return (initially empty)
    	 //    While the queue is not empty and you don't have enough completions:
    	 //       remove the first Node from the queue
    	 //       If it is a word, add it to the completions list
    	 //       Add all of its child nodes to the back of the queue
    	 // Return the list of completions
    	 prefix = prefix.toLowerCase();
    	 
    	 //System.out.println(prefix);
    	 int num = 0; 	 
    	 List<String> completions = new LinkedList<String> ();   	 
    	 TrieNode stem = searchNode(prefix);
    	 
    	 if (stem == null) {
    		 return completions;
    	 }
    	 else {
    		 
    		 Queue <TrieNode> q = new LinkedList <TrieNode> ();
    		 q.add(stem);
    		 
    		 while (!q.isEmpty() && num < numCompletions) {
    			 
    			 TrieNode removedNode = q.remove();
    			 //System.out.println(removedNode.getText());
    			 if (dict.contains(removedNode.getText())){
    			
    		
    				 //System.out.println(removedNode.getText());
    				 completions.add(removedNode.getText());
    				 num++;
    				 
    			 }
    			 
    			 for (TrieNode child: removedNode.children.values()){
    				 q.add(child);
    			 }    			 
    			 
    		 }   		 
    		 
    	 }
    	 
         return completions;
     }

 	// For debugging
 	public void printTree()
 	{
 		printNode(root);
 	}
 	
 	/** Do a pre-order traversal from this node down */
 	public void printNode(TrieNode curr)
 	{
 		if (curr == null) 
 			return;
 		
 		System.out.println(curr.getText());
 		
 		TrieNode next = null;
 		for (Character c : curr.getValidNextCharacters()) {
 			next = curr.getChild(c);
 			printNode(next);
 		}
 	}
 	
 	

}





