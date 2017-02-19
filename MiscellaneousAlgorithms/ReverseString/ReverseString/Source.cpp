#include <iostream>
#include <stdio.h>

using namespace std;

void reverseWords(char * s);

void reverse(char *str);

void reverse(char *begin, char *end);


int main()
{

	char str[] = "i really like apples";

	char * temp = str;

	reverseWords(temp);

	return 0;
}

void reverseWords(char *s)
{
	char *wordBegin = s;
	char *temp = s;

	// pointing to char in string
	while (*temp)
	{
		temp++;
		// if char whose numeric value is 0
		if (*temp == '\0')
		{
			reverse(wordBegin, temp - 1);
		}
		// if pointing to empty space
		else if (*temp == ' ')
		{
			reverse(wordBegin, temp - 1);
			wordBegin = temp + 1;
		}
	}

	reverse(s, temp - 1);

}

void reverse(char *str)
{
	char *end = str;
	char tmp = 0;

	if (str)
	{

		while (*end)
		{
			++end;
		}
		--end;

		while (str < end)
		{
			tmp = *str;
			*str = *end;
			*str++;
			//*str++ = *end;
			*end = tmp;
			*end--;
			//*end-- = tmp
			
		}

	}
}

void reverse(char *begin, char *end)
{
	char temp;
	while (begin < end)
	{

		temp = *begin;
		*begin = *end;
		*begin++;
		*end = temp;
		*end--;
		
	}
}
