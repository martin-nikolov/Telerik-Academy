/**
*	http://trekto.info/asd
*	Версия за мобилни телефони: http://trekto.info/f/SudokuSolver.jar
*/

#include <iostream>
#include <fstream>
#include <cstdlib>
#include <cmath>
#include "stopwatch.h"

#define INPUT 0
#define OUTPUT 1

// Под думата 'поле' в коментарите се има предвид игралното поле.
// Под 'квадрат' се има предвид големите квадрати с размер sqrt(n), от които е изградено поле.
// Под 'квадратче' се има предвид клетката, в която се поставя цифра.

using namespace std;

class Sudoku {
private:
	int n;							// размер на полето
	int littleN;						// размер на квадратите = sqrt(n)
	int** input;						// входното поле
								// input е указател към указател към int
								// за да имитираме двумерен динамичен масив
								// ще използваме динамичен масив
								// от указатели към динамични масиви от int
	int** current;						// полето в момента
	int currI;						// текущ ред
	int currJ;						// текущ стълб
	unsigned numberOfBacktracks;				// брой направени връщания назад
	unsigned startTime;					// време преди започване на решаването
	unsigned endTime;					// време след прекратяване на решаването
	char contin;						// знак определящ прекратяване на програмата
	char all;						// знак определящ намирането на още решения
	unsigned numberOfSolutions;				// брой намерени решения
	bool isPosible(int number, int i, int j);		// проверява дали е възможно цифрата number
								// да бъде поставена на позиция [i][j]
	bool moveForward();					// преминава към следващото празно квадратче
	bool moveBackward();					// връща се назад към предишното квадратче
	bool checkCorrectness(int checkType);			// проверява коректността на входните данни
								// и на намереното решение
	void checkTime();					// проверява колко време е изминало

public:
	Sudoku();						// конструктор
	~Sudoku();						// деструктор
	void readFile(const char* fileName);			// прочита входното поле от файл
	bool solve();						// решава играта
	void print();						// отпечатва полето
	unsigned getNumberOfBacktracks();			// връща броя направени връщания назад
	unsigned getNumberOfSolutions();			// връща броя намерени решения
	void printTime();					// отпечатва времето за изпълнение
};

Sudoku:: Sudoku() {						// конструктор
	n = littleN = currI = currJ = numberOfBacktracks = startTime = endTime = numberOfSolutions = 0;
	input = current = NULL;
 	contin = 'n';
 	all = 'n';
}

Sudoku:: ~Sudoku() {						// деструктор
	for(int i = 0; i < n; i++) {				// един по един изтриваме всички
		delete[] input[i];				// динамични масиви
		delete[] current[i];
	}
}

bool Sudoku:: solve() {						// решава играта
	startTime = clock();					// засичаме времето

	if(current[0][0])					// ако първата клетка е зададена по условие
		moveForward();					// преминаване към първата празна клетка

	do {
		do {
			int i;					// i е цифрата, която ще поставим
			do {					// в текущото квадратче
				i = current[currI][currJ] + 1;	// първоначално тя става с 1 по-голяма от
								// цифрата, която в момента е в квадратчето.
								// Ако квадратчето е празно то съдържа 0,
								// или цифра 1..n ако сме направили връщане

				while(i <= n) {			// докато стойността на i е по малка от n
					if(isPosible(i, currI, currJ)) {// ако е възможно в текущото
									// квадратче да поставим цифрата i
						current[currI][currJ] = i; // го правим
						break;		// и прекратяваме цикъла
					}
					i++;			// вземаме следващата цифра
				}

				if(i > n)			// ако сме изчерпали всички цифри и
								// никоя от тях не може да се постави
								// в текущото квадратче
					if(!moveBackward()) {	// опитваме да направим връщане назад
								// ако не успеем значи няма решение
						endTime = clock();// засичаме времето за изпълнение
						return false;	// и прекратяваме търсенето на решение
					}

			} while(i > n);				// ако i е по-голямо от n значи
								// сме направили връщане и трябва да
								// повторим горните редове код

			checkTime();				// проверяваме колко време е минало
		} while(moveForward());				// ако сме стигнали до тук значи, че
								// успешно сме поставили цифрата i
								// в текущото квадратче, затова преминаваме
								// към следващото, докато стигнем до края

		if(!checkCorrectness(OUTPUT)) { cerr << "\nТоку що открихте буболечка.\n"; exit(5); }
		numberOfSolutions++;				// увеличаваме броя намерени решения
		cout << "Решение: " << numberOfSolutions << endl;
		print();					// отпечатваме решението
		cout << "\nЖелаете ли да намерите още решения? y/n: ";
		cin >> all;
		if(all != 'y') break;				// спираме търсенето на други решения
		cout << "\n";

	} while(moveBackward());				// връщаме се назад докато това е възможно
								// за да намерим всички решения

	endTime = clock();					// засичаме времето за изпълнение
	return true;						// връщаме true
}

bool Sudoku:: isPosible(int number, int row, int col) {		// проверява дали е възможно цифрата number
								// да бъде поставена на позиция [row][col]

	for(int j = 0; j < n; j++)				// проверяваме дали цифрата в някое от
		if(current[row][j] == number) return false;	// квадратчетата в ред row е равна на number

	for(int i = 0; i < n; i++)				// проверяваме дали цифрата в някое от
		if(current[i][col] == number) return false;	// квадратчет. в стълб col е равна на number

	int shiftRow = littleN * (row / littleN);		// намираме отместването на квадрата
	int shiftCol = littleN * (col / littleN);		// в който искаме да поставим number

	for(int i = shiftRow; i < shiftRow + littleN; i++)	// за всеки ред
		for(int j = shiftCol; j < shiftCol + littleN; j++)	// и стълб в квадрата
			if(current[i][j] == number) return false;	// проверяваме дали number я има

	return true;						// ако цифрата number я няма в реда, стълба
								// и квадрата, в който се намира
								// квадратчето [row][col], значи можем
								// да я поставим там
}

bool Sudoku:: moveForward() {					// преминава към следващото празно квадратче
	unsigned tempI, tempJ;					// запомняме текущата позиция
	tempI = currI;						// това е нужно само при намирането
	tempJ = currJ;						// на всички решения
	do {
		if(currI == n-1 && currJ == n-1) {		// ако сме стигнали до края на полето
			currI = tempI;				// възстановяваме позицията
			currJ = tempJ;
			return false;				// връщаме false
		}

		if(currJ < n-1)					// ако не сме на последното квадратче на
			currJ++;				// реда преминаваме на следващото
		else {						// в противен случай
			currJ = 0;				// преминаваме на първото квадратче
			currI++;				// на следващия ред
		}
	} while(input[currI][currJ]);				// повтаряме горните действия докато
								// стигнем до празно квадратче

	return true;						// тук сме преминали към следващото
								// празно квадратче и връщаме true
}

bool Sudoku:: moveBackward() {					// връща се назад към предишното квадратче
	numberOfBacktracks++;					// броим колко пъти сме се върнали назад
	current[currI][currJ] = 0;				// премахваме текущата цифра
	do {
		if(currI == 0 && currJ == 0)			// ако се опитваме да се върнем
			return false;				// преди началото връщаме false

		if(currJ > 0)					// ако не сме в началото на някой ред
			 currJ--;				// се връщаме едно квадратче назад
		else {						// в противен случай
			currJ = n-1;				// преминаваме към последното квадратче
			currI--;				// на предишния ред
		}
	} while(input[currI][currJ]);				// повтаряме горните действия докато
								// стигнем до празно квадратче

	return true;						// върнали сме се към предишното
								// квадратче и връщаме true
}

void Sudoku:: readFile(const char* fileName) {			// прочита входното поле от файл
	ifstream inputFile(fileName);
	if(!inputFile) {
		cerr << "\nВъзникна входно/изходна грешка!\n";
		exit(6);
	}

	inputFile >> n;						// прочитаме размера на полето
	littleN = sqrt(n);
	if(n > 9 || littleN * littleN != n) {			// ако той е по-голям от 9 или не е квадрат
		cerr << "\nГрешен размер на полето!\n";
		exit(2);
	}

	input = new int*[n];					// заделяме памет за масив от указатели към
	current = new int*[n];					// други масиви
	for(int i = 0; i < n; i++) {				// създаваме n на брой динамични масива
		input[i] = new int[n];				// и насочваме input[i] към първия им ел.
		current[i] = new int[n];
	}

	for(int i = 0; i < n; i++)				// прочитаме входното поле
		for(int j = 0; j < n; j++) {
			inputFile >> input[i][j];
			current[i][j] = input[i][j];
			if (!inputFile) {
				cerr << "\nГрешка по време на четене!\n";
				exit(3);
			}
		}

	inputFile.close();

	if(!checkCorrectness(INPUT)) {				// проверяваме дали данните не са некоректни
		cerr << "\nНекоректни входни данни!\n";
		exit(4);
	}
}

void Sudoku:: print() {						// отпечатва полето
	for(int i = 0; i < n; i++) {
		for(int j = 0; j < n; j++)
			cout << current[i][j] << ' ';
		cout << '\n';
	}
}

bool Sudoku:: checkCorrectness(int checkType) {			// проверява коректността на входните данни
								// и на намереното решение

	// Ако подаденият параметър е INPUT проверяваме дали има повтарящи се цифри в някой ред, стълб или
	// квадрат на входното поле. Ако параметърът е OUTPUT, проверяваме и това дали не сме оставили
	// празно квадратче в изходното поле (решението).

	// проверка за празни квадратчета в решението
	if(checkType == OUTPUT)
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
				if(!current[i][j]) return false;

	int* a = new int[n+1];					// в този масив пазим колко пъти се среща
								// дадена цифра

	// проверка за дублиращи се цифри в някой ред
	for(int i = 0; i < n; i++) {				// за всеки ред
		for(int j = 1; j <= n; j++) a[j] = 0;		// зануляваме масива с броя срещания
		for(int j = 0; j < n; j++)			// и всяко квадратче в него
			if(current[i][j] && a[current[i][j]])	// ако не е празно и цифрата в него вече
				return false;			// се среща някъде връщаме false
			else a[current[i][j]]++;		// иначе отбелязваме, че цифрата се среща
	}

	// проверка за дублиращи се цифри в някой стълб
	for(int j = 0; j < n; j++) {
		for(int i = 1; i <= n; i++) a[i] = 0;
		for(int i = 0; i < n; i++)
			if(current[i][j] && a[current[i][j]]) return false;
			else a[current[i][j]]++;
	}

	// проверка за дублиращи се цифри в някой квадрат
	for(int row = 0; row < n; row += littleN)		// обхождаме квадратите
		for(int col = 0; col < n; col += littleN) {
			for(int i = row; i < row + littleN; i++) {	// и техните квадратчета
				for(int j = 1; j <= n; j++) a[j] = 0;
				for(int j = col; j < col + littleN; j++)
					if(current[i][j] && a[current[i][j]]) return false;
					else a[current[i][j]]++;
			}
		}

	delete[] a;						// не забравяме да освободим паметта
	return true;						// не сме открили грешка
}

unsigned Sudoku:: getNumberOfBacktracks() {			// връща броя направени връщания назад
	return numberOfBacktracks;
}

unsigned Sudoku:: getNumberOfSolutions() {			// връща броя намерени решения
	return numberOfSolutions;
}

void Sudoku:: checkTime() {					// проверява колко време е изминало
	if(contin == 'n' && (clock() - startTime) / CLOCKS_PER_SEC > 2) {
		cout << "Програмата работи вече 2 секунди и е направила " << numberOfBacktracks << " връщания назад без да намери решение. Вероятно няма такова. Ако искате да прекратите изпълнението, въведете 'n'. Ако искате програмата да продължи, пробвайки всички възможности въведете 'y'. y/n: ";
		cin >> contin;
		cout << '\n';
		if(contin == 'n') exit(0);
	}
}

void Sudoku:: printTime() {					// отпечатва времето за изпълнение
	stopwatchCalculateTime(endTime - startTime);
}

int main(int argc, char **argv) {				// приема като параметър името на файла
								// с входните данни

	if (argc < 2) {						// ако не е зададен файл
		cerr<<"\nТрябва да зададете входен файл: programname <filename>\n";
		exit(1);
	}

	Sudoku sudoku;						// създаваме обект от тип Sudoku
	sudoku.readFile(argv[1]);				// прочитаме входните данни
	cout << "\nВходното поле:\n";
	sudoku.print();						// отпечатваме ги
	cout << "\n";

	if(sudoku.solve()) {					// опитваме се да решим играта
		cout << "Решението:\n";
		sudoku.print();					// ако намерим решение го отпечатваме
	} else {
		cout << "\nИграта няма " << (sudoku.getNumberOfSolutions() ? "повече решения" : "решение") << "!\n";
	}

	cout << "\nНаправени са общо " << sudoku.getNumberOfBacktracks() << " връщания назад, за време: ";
	sudoku.printTime();					// отпечатваме времето за изпълнение
	cout << "\n";

	return 0;
}