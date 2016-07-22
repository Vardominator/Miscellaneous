#pragma once

template <typename T>
class Single_List
{
public:
	Single_List();

	int size() const;
	bool empty() const;
	T front() const;
	T back() const;
	Single_Node<T> *head() const;
	Single_Node<T> *tail() const;

	/*
		We restrict ourselves to the following functions because 
		inserting and removing to and from the front is O(1) in
		a singly linked list;
	*/
	void push_front(const T &);
	void push_back(const T &);
	T pop_front();
	int erase(const T &);

private:
	int size;
	T front;
	T back;
	Single_Node<T> *head;
	Single_Node<T> *tail;

};
