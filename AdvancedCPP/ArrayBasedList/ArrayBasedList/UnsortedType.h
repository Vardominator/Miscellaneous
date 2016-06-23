#pragma once

class UnsortedType
{
public: 
	UnsortedType();
	void MakeEmpty();
	bool IsFull() const;
	int GetLength() const;
	void InsertItem(int item);
	void DeleteItem(int item);
	void Show();
private:
	int length;
	int info[10];
};