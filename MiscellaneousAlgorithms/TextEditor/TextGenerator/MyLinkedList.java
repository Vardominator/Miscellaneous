package textgen;

import java.util.AbstractList;


/** A class that implements a doubly linked list
 * 
 * @author UC San Diego Intermediate Programming MOOC team
 * 
 * Methods implemented by Varderes Barsegyan
 *
 * @param <E> The type of the elements stored in the list
 */
public class MyLinkedList<E> extends AbstractList<E> {
	
	LLNode<E> head;
	LLNode<E> tail;
	int size;
	//E data;

	/** Create a new empty LinkedList */
	public MyLinkedList() {
		// TODO: Implement this method
		
		size = 0;
		
		head = new LLNode<E>(null);
		tail = new LLNode<E>(null);
		
		head.next = tail;
		tail.prev = head;
		
	}

	/**
	 * Appends an element to the end of the list
	 * @param element The element to add
	 */
	public boolean add(E element) 
	{
		// TODO: Implement this method
		LLNode<E> current = tail.prev;
		
		if (element != null) {
				
			LLNode<E> newNode = new LLNode<E> (element);
			
			newNode.prev = current;
			current.next = newNode;
			
			newNode.next = tail;
			tail.prev = newNode;
			
			//System.out.println("Added: " + newNode.data);
			size++;
			return true;
			
		} else {
			
			throw new NullPointerException("Element is null");
			
		}
	}

	/** Get the element at position index 
	 * @throws IndexOutOfBoundsException if the index is out of bounds. */
	public E get(int index) 
	{
		// TODO: Implement this method.
		LLNode<E> getNode = head;
	
		if (index < 0 || index >= size) {
			throw new IndexOutOfBoundsException("Index does not exist.");
		}
		else {	
			for (int i = 0; i <= index; i++) {		
				getNode = getNode.next;	
			}
			return getNode.data;
		}			
	}

	/**
	 * Add an element to the list at the specified index
	 * @param The index where the element should be added
	 * @param element The element to add
	 */
	public void add(int index, E element ) 
	{
		// TODO: Implement this method
		size++;
		if (index < 0 || index >= size) {
			throw new IndexOutOfBoundsException("Index out of bounds son");
		}
		
		if (element == null) {
			throw new NullPointerException("Element is null");
		}
		
		else {			
			LLNode<E> nodeRight = null;
			LLNode<E> nodeLeft = head;
			LLNode<E> newNode = new LLNode<E> (element);	
			
			for (int i = 0; i < index; i++) {
				nodeLeft = nodeLeft.next;
			}
			nodeRight = nodeLeft.next;
		
			newNode.prev = nodeLeft;
			nodeLeft.next = newNode;
			
			newNode.next = nodeRight;
			nodeRight.prev = newNode;
		}		
	}

	/** Return the size of the list */
	public int size() 
	{
		// TODO: Implement this method
		return size;
	}

	/** Remove a node at the specified index and return its data element.
	 * @param index The index of the element to remove
	 * @return The data element removed 
	 */
	public E remove(int index) 
	{
		// TODO: Implement this method
		
		LLNode<E> nodeLeft = head;
		LLNode<E> nodeRight = head;
		LLNode<E> deletedNode = null;
		
		if (index < 0 || index >= size) {
			throw new IndexOutOfBoundsException("Index out of bounds son");
		}	
		else {
			size--;
			for (int i = 0; i < index; i++) {
				nodeLeft = nodeLeft.next;
			}
			nodeRight = nodeLeft.next;
			deletedNode = nodeRight;
			nodeRight = nodeRight.next;
			
			nodeLeft.next = nodeRight;
			nodeRight.prev = nodeLeft;

			return deletedNode.data;
		}
		
		
	}

	/**
	 * Set an index position in the list to a new element
	 * @param index The index of the element to change
	 * @param element The new element
	 * @return The element that was replaced
	 * @throws IndexOutOfBoundsException if the index is out of bounds.
	 */
	public E set(int index, E element) 
	{
		// TODO: Implement this method
		LLNode<E> nodeLeft = head;
		LLNode<E> nodeRight = head;
		
		if (index < 0 || index >= size) {
			throw new IndexOutOfBoundsException("Index out of bounds son");
		}
		
		if (element == null) {
			throw new NullPointerException("Element is null");
		}
		
		else {

			for (int i = 0; i <= index; i++) {
				nodeLeft = nodeLeft.next;
			}
			
			nodeLeft.data = element;

			return nodeLeft.data;
		}
		
	}   
}

class LLNode<E> 
{
	LLNode<E> prev;
	LLNode<E> next;
	E data;

	// TODO: Add any other methods you think are useful here
	// E.g. you might want to add another constructor

	public LLNode(E e) 
	{
		this.data = e;
		this.prev = null;
		this.next = null;
	}

}


