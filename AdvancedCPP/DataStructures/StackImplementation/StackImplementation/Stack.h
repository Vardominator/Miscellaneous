#pragma once

template<typename T>
class Stack
{
public:
	bool empty() const;
	T top() const;

	void push(const T &);
	T pop();

private:
	Single_List<T> list;

};
