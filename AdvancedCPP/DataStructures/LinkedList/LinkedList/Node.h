#pragma once

template<class T>
class LinkedList
{
public:
	Node<T> * head;
	Node<T> * tail;

	LinkedList(const LinkedList & LL);

	LinkedList();
	LinkedList(Node<T> * newNode);
	~LinkedList();

	// TODO: static LinkedList<int> sumList(const LinkedList<int> & LL1, LinkedList<int> & LL2);

	void insertToTail(T val);
	void insertToHead(T val);
	void print();
	// TODO: void printBackwards();
};