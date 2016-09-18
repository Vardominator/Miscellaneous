
public class TrieNodeTest {
	
	public static void main(String[] args) {
		
		Trie newTrie = new Trie();
		
		newTrie.insert("hell");
		newTrie.insert("hello");
		newTrie.insert("heLlo");
		newTrie.insert("what");
		
		System.out.println(newTrie.search("hello"));
		System.out.println(newTrie.search("yo"));
		
	}

}
