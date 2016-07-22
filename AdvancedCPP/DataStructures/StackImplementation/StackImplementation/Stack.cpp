#include "Stack.h"
#include <iostream>

template <typename T>
bool Stack<T>::empty() const
{
	return list.empty();
}

template <typename T>
void Stack<T>::push(const T &obj)
{
	list.push_front(obj);
}

template <typename T>
T Stack<T>::top() const
{
	if (empty())
	{
		throw UNDERFLOW();
	}

	return list.front();
}

template <typename T>
T Stack<T>::pop()
{
	if (empty())
	{
		throw UNDERFLOW();
	}
	return list.pop_front();
}
