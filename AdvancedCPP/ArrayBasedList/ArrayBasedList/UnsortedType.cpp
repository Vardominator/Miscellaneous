#include "UnsortedType.h"
#include <iostream>


UnsortedType::UnsortedType()
{
	length = 0;
}

// O(1)
void UnsortedType::InsertItem(int item)
{
	if (IsFull())
	{
		return;
	}
	info[length] = item;
	length++;
}

// O(1)
bool UnsortedType::IsFull() const
{
	return (length == 10);
}

// O(1)
void UnsortedType::MakeEmpty()
{
	// If it's empty to the user, then it is empty.
	length = 0;
}

// O(n)
void UnsortedType::DeleteItem(int item)
{
	for (int i = 0; i < length; i++)
	{
		if (info[i] == item)
		{
			// Move the last element into the spot of the deleted item
			info[i] = info[length - 1];
			length--;
		}
	}
}

// O(n)
void UnsortedType::Show()
{
	for (int i = 0; i < length; i++)
	{
		std::cout << info[i] << " " << std::endl;
	}
}

int UnsortedType::GetLength() const
{
	return length;
}