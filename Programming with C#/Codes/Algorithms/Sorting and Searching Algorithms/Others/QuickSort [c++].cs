/*	Бързо сортиране (сортиране по дялове)


	Програмата по-долу прилага класическата
	рекурсивна реализация на метода quicksort.


	В езика C++ съществува и стандартна функция
	qsort (декларирана в stdlib.h), която би 
	могла да се ползва по следния начин:

	Дефинираме помощна функция за сравняване 
	на два елемента:

	int intcmp( const void * a, const void * b )
	{
		int A = *((int *) a), B = *((int *) b);

		if ( A < B ) return -1;
		if ( A > B ) return 1;

		return 0;
	}

	Подаваме на qsort():
		- начало на масива
		- брой елементи, големина на един елемент (в байтове)
		- сравняваща функция (компаратор)

	qsort( a, n, sizeof(int), intcmp );
*/

#include <iostream.h>

// За генериране на случайни числа с rand()
#include <stdlib.h>
#include <time.h>

#define MAX_N 100

int a[MAX_N];
int n;

void quicksort( int a[], int left, int right )
{
	int x, t;
	int i, j;

	// Няма какво да се сортира -> изход
	if ( left >= right ) return;

	// Водеща стойност
	// (граница между долната и горната област)
	x = a[(left + right)/2];

	// В началото долната и горната област са празни
	i = left; j = right;

	do
	{
		while ( a[i] < x ) ++i;
		while ( a[j] > x ) --j;

		// Намерили сме двойка елементи a[i] >= x >= a[j].
		// Разменяме ги за да си отидат в съответната област
		if ( i <= j )
		{
			t = a[i];
			a[i] = a[j];
			a[j] = t;
			++i; --j;
		}
	} while ( i <= j );
	
	// Сортиране на долната област
	if ( j > left ) quicksort( a, left, j );

	// Сортиране на горната област
	if ( i < right ) quicksort( a, i, right );
}

int main( void )
{
	int i;

	// Инициализиране на генератора на случайни числа
	srand( time( NULL ) );

	// Генериране на n числа а[i], 0 <= a[i] <= 999.
	n = 20;
	for ( i = 0; i < n; i++ )
		a[i] = rand() % 1000;

	// Печат на масива
	cout << n << " random numbers:";
	for ( i = 0; i < n; i++ )
		cout << ' ' << a[i];
	cout << endl;

	// Сортиране с рекурсивната процедура.
	// Можете да замените с извикване на qsort(),
	// както е описано по-горе.
	quicksort( a, 0, n - 1 );

	// Печат на масива
	cout << "sorted:";
	for ( i = 0; i < n; i++ )
		cout << ' ' << a[i];
	cout << endl;

	return 0;
}