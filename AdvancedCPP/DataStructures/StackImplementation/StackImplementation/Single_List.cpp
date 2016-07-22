#include "Single_List.h"
#include "Single_Node.h"
#include <iostream>


template<typename T>
Single_List<T>::Single_List()
{
	size = 0;
}

template<typename T>
int Single_List<T>::size() const
{
	return size;
}

template<typename T>
bool Single_List<T>::empty() const
{
	return size == 0;
}

template<typename T>
T Single_List<T>::front() const
{
	return front;
}

template<typename T>
T Single_List<T>::back() const
{
	return back;
}

template<typename T>
Single_Node<T> Single_List<T>::head() const
{

}

template<typename T>
Single_Node<T> Single_List<T>::tail() const
{

}

template<typename T>
void Single_List<T>::push_front(T &obj)
{

}

template<typename T>
void Single_List<T>::push_back(T &obj)
{

}

template<typename T>
T Single_List<T>::pop_front()
{
	return nullptr;
}

template<typename T>
int Single_List<T>::erase(const T &obj)
{
	return -1;
}