#include <iostream>


template<class T>
class Node
{
public:
	T data;
	Node<T> * next;

	/*
	Constructor using a Member Initialization List

	From stack overflow post regarding member initialization:
	When you INITIALIZE fields this way, the constructors
	will be called once and the object will be constructed
	and initlialized in one operation.

	When you used ASSIGNMENT then the fields will first be
	initialized with default constructors and then reassigned
	with actual values.

	In this case data is initialized with 'd' and next with null.

	*/
	Node<T>(const T& d) : data(d), next() {}
	Node<T>(const Node<T>& copyNode) : data(copyNode->data), next() {}

private:


};






template<class T>
class LinkedList
{
public:
	Node<T> * head;
	Node<T> * tail;

	LinkedList(const LinkedList & LL);

	LinkedList() : head(NULL), tail(NULL) {}
	LinkedList(Node<T> * newNode) : head(newNode), tail(newNode) {}
	~LinkedList();

	// TODO: static LinkedList<int> sumList(const LinkedList<int> & LL1, LinkedList<int> & LL2);

	void insertToTail(T val);
	void insertToHead(T val);
	void print();
	// TODO: void printBackwards();

};


template<class T>
LinkedList<T>::LinkedList(const LinkedList<T> & LL) : head(NULL), tail(NULL)
{
	const Node<T> * curr = LL.head;

	if (!head && curr)
	{
		head = new Node<T>(curr->data);
		tail = head;
		curr = curr->next;
	}

	while (curr)
	{
		Node<T> * newNode = new Node<T>(curr->data);
		tail->next = newNode;
		tail = newNode;
		curr = curr->next;
	}

}

template<class T>
LinkedList<T>::~LinkedList()
{
	Node<T> * curr = head;
	while (head)
	{
		head = head->next;
		delete curr;
		curr = head;
	}
}


template<class T>
void LinkedList<T>::insertToTail(T val)
{

	Node<T> * newNode = new Node<T>(val);

	if (tail == NULL)
	{
		newNode->next = tail;
		tail = newNode;
		head = newNode;
		return;
	}

	tail->next = newNode;
	tail = tail->next;
}

template<class T>
void LinkedList<T>::insertToHead(T val)
{
	Node<T> * newNode = new Node<T>(val);

	newNode->next = head;
	head = newNode;

	if (head->next == NULL)
	{
		tail = newNode;
	}

}

template<class T>
void LinkedList<T>::print()
{
	Node<T> * current = head;

	while (current)
	{
		std::cout << current->data << " -- > ";
		current = current->next;
	}

	std::cout << "NULL" << std::endl;
}





int main()
{

	LinkedList<int> * list1 = new LinkedList<int>(new Node<int>(7));

	list1->insertToHead(10);
	list1->insertToHead(15);
	list1->insertToTail(900);

	list1->print();

	return 0;
}