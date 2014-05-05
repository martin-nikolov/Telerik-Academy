/*
    10. Write a program that extracts from a given
    text all palindromes, e.g. "ABBA", "lamal", "exe".
*/

taskName = "10. Extract all palindromes";

function Main(bufferElement) {

    var text = 'ABBA, palindrome. LAMAL! EXE...bqlhlqb ,,! THIS IS NOT PALINDROME';

    var palindromes = extractPalindromes(text);

    WriteLine("All palindromes: " + palindromes.join(', '));
}

function extractPalindromes(text) {
    var palindromes = [];

    var currentWord = "";
    var regex = /\b\w+\b/g;

    while (currentWord = regex.exec(text)) { /* regex-exec -> Gets matches one-by-one*/
        if (isPalindrome(currentWord[0])) {
            palindromes.push(currentWord[0]);
        }
    }

    return palindromes;
}

function isPalindrome(word) {
    for (var i = 0; i < word.length / 2; i++) {
        if (word.charAt(i) != word.charAt(word.length - i - 1)) {
            return false;
        }
    }

    return true;
}