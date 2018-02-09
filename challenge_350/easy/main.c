#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "headers/utility.h"
#include "headers/permute.h"
#include "headers/book.h"

int main(void) {

    char inputFile[] = "input1.txt";

    char **shelfInformation = readLines(inputFile, 1, 1);
    int shelves[countNumbers(shelfInformation[0])];
    toNumbers(shelfInformation[0], shelves);
    sortNumbers(shelves, sizeof(shelves) / sizeof(int));

    const int totalBooks = countLines(inputFile) - 1;
    char **bookInformation = readLines(inputFile, 2, totalBooks);
    struct book books[totalBooks];
    createBooks(bookInformation, books, totalBooks);

    int *range = getRange(0, totalBooks);
    int permutation[factorial(totalBooks)][totalBooks];
    permute((int *)permutation, range, totalBooks);

    freeLines(shelfInformation, 1);
    freeLines(bookInformation, totalBooks);
    freeBooks(books, totalBooks);
    free(range);

    return 0;
}